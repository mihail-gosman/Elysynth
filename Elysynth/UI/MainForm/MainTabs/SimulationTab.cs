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

            // Draw grid before particles
            int cellSize = 20; // Adjust cell size as needed
            int width = ((Control)sender).ClientSize.Width;
            int height = ((Control)sender).ClientSize.Height;
            using (Pen gridPen = new Pen(Color.LightGray))
            {
                // Vertical lines
                for (int x = 0; x <= width; x += cellSize)
                {
                    g.DrawLine(gridPen, x, 0, x, height);
                }
                // Horizontal lines
                for (int y = 0; y <= height; y += cellSize)
                {
                    g.DrawLine(gridPen, 0, y, width, y);
                }
            }

            if (activeProject != null)
            {
                foreach (var entity in activeProject.Entities)
                {
                    if (entity is Particle p)
                    {
                        g.FillEllipse(Brushes.Red, (float)p.Position.X, (float)p.Position.Y, 10, 10);
                    }
                }
            }
        }

    }
}
