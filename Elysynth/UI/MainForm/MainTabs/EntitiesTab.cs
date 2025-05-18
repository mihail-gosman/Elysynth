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
        private void UpdateEntitiesPanel()
        {
            panelEntities.Controls.Clear();

            if (activeProject == null || activeProject.Entities == null)
                return;

            int yOffset = 10;

            foreach (var entity in activeProject.Entities)
            {
                if (entity == null) continue;

                var nameProp = entity.GetType().GetProperty("Name");
                if (nameProp == null) continue;

                string name = nameProp.GetValue(entity)?.ToString() ?? "Unnamed";

                Label label = new Label
                {
                    Text = name,
                    AutoSize = false,
                    Width = panelEntities.Width - 20,
                    Height = 30,
                    Location = new Point(10, yOffset),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = entity,
                    BorderStyle = System.Windows.Forms.BorderStyle.None
                };

                label.Click += (s, e) =>
                {
                    // Clear borders from all labels
                    foreach (Control ctrl in panelEntities.Controls)
                    {
                        if (ctrl is Label lbl)
                            lbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    }

                    // Highlight selected label
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    selectedEntity = label.Tag;
                    
                    UpdateEntityTab(selectedEntity);
                };

                panelEntities.Controls.Add(label);
                yOffset += label.Height + 5;
            }
        }
    }
}
