using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elysynth.Properties;
using MetroFramework.Forms;
using Models;

namespace Elysynth.Forms
{
    public partial class OptionsWindow: MetroForm
    {
        public Models.Settings settings;



        public OptionsWindow(Models.Settings settings)
        {
            InitializeComponent();
            this.settings = settings;
        }

        private Dictionary<string, Control> _controlMap = new Dictionary<string, Control>();

        private void OptionsWindow_Load(object sender, EventArgs e)
        {
            int verticalSpacing = 35;
            int currentY = 20;

            foreach (var prop in typeof(Models.Settings).GetProperties())
            {
                if (prop.Name == "AppName" || prop.Name == "AppVersion")
                    continue;

                Label label = new Label();
                label.Text = prop.Name;
                label.Location = new Point(20, currentY + 5);
                label.AutoSize = true;
                Controls.Add(label);

                Control inputControl = null;

                if (prop.PropertyType == typeof(string))
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = (string)prop.GetValue(settings) ?? "";
                    textBox.Location = new Point(150, currentY);
                    textBox.Width = 200;
                    inputControl = textBox;
                }
                else if (prop.PropertyType == typeof(int))
                {
                    NumericUpDown numUpDown = new NumericUpDown();
                    numUpDown.Value = Convert.ToDecimal(prop.GetValue(settings));
                    numUpDown.Location = new Point(150, currentY);
                    numUpDown.Width = 100;
                    numUpDown.Maximum = 1000000;
                    inputControl = numUpDown;
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Checked = (bool)prop.GetValue(settings);
                    checkBox.Location = new Point(150, currentY);
                    checkBox.AutoSize = true;
                    inputControl = checkBox;
                }

                if (inputControl != null)
                {
                    Controls.Add(inputControl);
                    _controlMap[prop.Name] = inputControl;
                    currentY += verticalSpacing;
                }
            }

            Button btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(150, currentY + 10);
            btnSave.Width = 100;
            btnSave.Click += new EventHandler((s, ea) =>
            {
                foreach (var prop in typeof(Models.Settings).GetProperties())
                {
                    Control ctrl;
                    if (_controlMap.TryGetValue(prop.Name, out ctrl))
                    {
                        if (prop.PropertyType == typeof(string))
                            prop.SetValue(settings, ((TextBox)ctrl).Text);
                        else if (prop.PropertyType == typeof(int))
                            prop.SetValue(settings, (int)((NumericUpDown)ctrl).Value);
                        else if (prop.PropertyType == typeof(bool))
                            prop.SetValue(settings, ((CheckBox)ctrl).Checked);
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            });

            Controls.Add(btnSave);
        }


    }
}
