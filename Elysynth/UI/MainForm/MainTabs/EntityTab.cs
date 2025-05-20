using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elysynth.UI.MainForm
{
    public partial class MainForm
    { 
        private void UpdateEntityTab(object entity)
        {
            int xOffset = 10;
            int yOffset = 10;

            panelEntity.Controls.Clear();

            if (entity is Particle)
            {
                Label lbl_name = new Label()
                {
                    Text = "Name",
                    Location = new Point(xOffset, yOffset),
                    Size = new Size(50, 20),
                    ForeColor = Color.Black,
                };

                TextBox txt_name = new TextBox()
                {
                    Location = new Point(xOffset + 50 + 10, yOffset - 2),
                    Text = ((Particle)entity).Name,
                    Size = new Size(60, 20),
                    ForeColor = Color.Black,
                };

                txt_name.TextChanged += (s, e) =>
                {
                    if (txt_name.Text.Length > 0)
                    {
                       lbl_name.BackColor = Color.White;
                        ((Particle)entity).Name = txt_name.Text;
                    }
                    else
                    {
                        lbl_name.ForeColor = Color.Red;
                    }
                        UpdateEntitiesPanel();
                };

                yOffset += 30;
                Label lbl_posX = new Label()
                {
                    Text = "Position X",
                    Location = new Point(xOffset, yOffset),
                    Size = new Size(50, 20),
                    ForeColor = Color.Black,
                };

                TextBox txt_posY = new TextBox()
                {
                    Location = new Point(xOffset + 50 + 10, yOffset - 2),
                    Text = ((Particle)entity).Name,
                    Size = new Size(60, 20),
                    ForeColor = Color.Black,
                };

                txt_name.TextChanged += (s, e) =>
                {
                    if (txt_name.Text.Length > 0)
                    {
                        lbl_name.BackColor = Color.White;
                        ((Particle)entity).Name = txt_name.Text;
                    }
                    else
                    {
                        lbl_name.ForeColor = Color.Red;
                    }
                    UpdateEntitiesPanel();
                };

                panelEntity.Controls.Add(lbl_name);
                panelEntity.Controls.Add(txt_name);
                panelEntity.Controls.Add(lbl_posX);
                panelEntity.Controls.Add(txt_posY);
            }
        }

    }
}
