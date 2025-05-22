using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elysynth.UI.MainForm
{
    public partial class MainForm
    {
        private void UpdateEntitiesPanel(string keyword = null)
        {
            panelEntities.Controls.Clear();

            if (activeProject == null || activeProject.Entities == null)
                return;

            int yOffset = 5;

            foreach (var entity in activeProject.Entities)
            {
                var nameProp = entity.GetType().GetProperty("Name");
                if (nameProp == null) continue;

                string name = nameProp.GetValue(entity)?.ToString() ?? "Unnamed";

                if (keyword != null && !name.Contains(keyword))
                {
                    continue;
                }

                Label label = new Label
                {
                    Text = name,
                    AutoSize = false,
                    Width = panelEntities.Width - 20,
                    Height = 20,
                    Location = new Point(10, yOffset),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = entity,
                    BorderStyle = System.Windows.Forms.BorderStyle.None
                };

                label.MouseClick += (s, e) =>
                {
                    // Clear borders from all labels
                    foreach (Control ctrl in panelEntities.Controls)
                    {
                        if (ctrl is Label lbl)
                            lbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    }

                    // Highlight selected label
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                    if (e.Button == MouseButtons.Left)
                    {



                        selectedEntity = label.Tag;
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        selectedEntity = label.Tag;
                        contextEntities.Show(label, new Point(0, label.Height));
                    }
                    UpdateEntityTab(selectedEntity);
                };



                panelEntities.Controls.Add(label);
                yOffset += label.Height + 5;
            }
        }

        private void txt_entities_Enter(object sender, EventArgs e)
        {
            if (txt_entities.Text == "Search...")
            {
                txt_entities.Text = "";
                txt_entities.ForeColor = Color.Black;
            }

        }

        private void txt_entities_Leave(object sender, EventArgs e)
        {
            if (txt_entities.Text.Length == 0)
            {
                txt_entities.ForeColor = Color.Gray;
                txt_entities.Text = "Search...";
                UpdateEntitiesPanel(null); // <- Fix: show all when empty
            }
            else
            {
                txt_entities.ForeColor = Color.Black;
                UpdateEntitiesPanel(txt_entities.Text);
            }
        }

        private void txt_entities_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_entities.Text) && txt_entities.Text != "Search...")
            {
                UpdateEntitiesPanel(txt_entities.Text);
            }
            else
            {
                UpdateEntitiesPanel(null); // <- Fix: show all if empty or placeholder
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedEntity == null) return;

            activeProject.Entities.Remove(selectedEntity);
            UpdateEntitiesPanel(null);
            UpdateSimulationPanel();
        }

    }
}
