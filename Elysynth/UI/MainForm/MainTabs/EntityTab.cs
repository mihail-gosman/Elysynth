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
        private void UpdateEntityTab(object entity, int indent = 0)
        {
            if (indent == 0)
                panelEntity.Controls.Clear();

            if (entity == null)
                return;

            int yOffset = panelEntity.Controls.Count > 0
                ? panelEntity.Controls[panelEntity.Controls.Count - 1].Bottom + 5
                : 10;

            int labelWidth = 100;
            int controlWidth = panelEntity.Width - labelWidth - 30;

            var props = entity.GetType().GetProperties();

            foreach (var prop in props)
            {
                Label lbl = new Label
                {
                    Text = prop.Name,
                    Location = new Point(10 + indent, yOffset),
                    AutoSize = true
                };
                panelEntity.Controls.Add(lbl);

                object value = prop.GetValue(entity);
                Control inputControl = null;

                if (prop.PropertyType == typeof(bool))
                {
                    var chk = new CheckBox
                    {
                        Checked = value is bool b && b,
                        Location = new Point(labelWidth + 10 + indent, yOffset - 3),
                        Width = controlWidth
                    };

                    chk.CheckedChanged += (s, e) =>
                    {
                        prop.SetValue(entity, chk.Checked);
                    };

                    inputControl = chk;
                }
                else if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(double) || prop.PropertyType == typeof(float))
                {
                    var txt = new TextBox
                    {
                        Text = value?.ToString() ?? "",
                        Location = new Point(labelWidth + 10 + indent, yOffset),
                        Width = controlWidth
                    };

                    txt.TextChanged += (s, e) =>
                    {
                        // Try convert and set value
                        try
                        {
                            object convertedValue = Convert.ChangeType(txt.Text, prop.PropertyType);
                            prop.SetValue(entity, convertedValue);
                        }
                        catch
                        {
                            // Optionally: handle conversion errors or ignore
                        }
                        UpdateEntitiesPanel();
                    };

                    inputControl = txt;
                }
                else if (value != null)
                {
                    // Complex type — recurse with indent
                    yOffset += 25;
                    UpdateEntityTab(value, indent + 20);
                    continue;
                }

                if (inputControl != null)
                {
                    inputControl.Tag = prop;
                    panelEntity.Controls.Add(inputControl);
                    yOffset += 30;
                }
                else
                {
                    yOffset += 25;
                }
            }
        }

    }
}
