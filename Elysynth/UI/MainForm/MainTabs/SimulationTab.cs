using Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elysynth.UI.MainForm
{
    public partial class MainForm
    {
        void UpdateSimulation(object sender, EventArgs e)
        {
            simulation.Update();
            UpdateSimulationPanel();
        }

        void UpdateSimulationPanel()
        {

            panelSimulation.Invalidate();
        }

        public void PanelSimulationPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            Control panel = (Control)sender;
            int panelWidth = panel.ClientSize.Width;
            int panelHeight = panel.ClientSize.Height;

            // Calculate screen center
            float centerX = panelWidth / 2f;
            float centerY = panelHeight / 2f;

            // Draw grid centered around (0,0)
            int cellSize = 20;
            using (Pen gridPen = new Pen(Color.LightGray))
            {
                for (int x = (int)-centerX; x < centerX; x += cellSize)
                {
                    float screenX = centerX + x;
                    g.DrawLine(gridPen, screenX, 0, screenX, panelHeight);
                }

                for (int y = (int)-centerY; y < centerY; y += cellSize)
                {
                    float screenY = centerY + y;
                    g.DrawLine(gridPen, 0, screenY, panelWidth, screenY);
                }
            }

            Project toBeRendered = null;

            if (isSimulationRunning)
            {
                toBeRendered = activeProjectCopy;
            }
            else
            {
                toBeRendered = activeProject;
            }

            if (toBeRendered != null)
            {
                foreach (var entity in toBeRendered.Entities)
                {
                    if (entity is Particle p)
                    {
                        float screenX = centerX + (float)p.Position.X;
                        float screenY = centerY + (float)p.Position.Y;
                        float size = 10;
                        g.FillEllipse(Brushes.Red, screenX - size / 2, screenY - size / 2, size, size);
                    }
                    else if (entity is Field f)
                    {

                        float screenX = centerX + (float)f.Position.X;
                        float screenY = centerY + (float)f.Position.Y;
                        float radius = 20f;
                        using (Pen fieldPen = new Pen(Color.Blue, 2))
                        {
                            g.DrawEllipse(fieldPen, screenX - radius / 2, screenY - radius / 2, radius, radius);
                        }
                    }
                }
            }
        }
    }


    public class FastPanel : Panel
    {
        public FastPanel()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.UpdateStyles();
        }
    }
}
