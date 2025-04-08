using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elysynth
{
    public partial class AddParticleForm: Form
    {
        private Label lblName;
        private Label lblPosX;
        private TextBox txtPosX;
        private TextBox txtPosY;
        private Label lblPosY;
        private TextBox txtMass;
        private Label lblMass;
        private TextBox txtCharge;
        private Label lblCharge;
        private Button btnAdd;
        private Button btnCancel;
        private TextBox txtName;

        public AddParticleForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.lblPosY = new System.Windows.Forms.Label();
            this.txtMass = new System.Windows.Forms.TextBox();
            this.lblMass = new System.Windows.Forms.Label();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.lblCharge = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 16);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Location = new System.Drawing.Point(12, 54);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(66, 16);
            this.lblPosX.TabIndex = 4;
            this.lblPosX.Text = "Position X";
            // 
            // txtPosX
            // 
            this.txtPosX.Location = new System.Drawing.Point(88, 51);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(100, 22);
            this.txtPosX.TabIndex = 5;
            this.txtPosX.TextChanged += new System.EventHandler(this.txtPosX_TextChanged);
            // 
            // txtPosY
            // 
            this.txtPosY.Location = new System.Drawing.Point(88, 79);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(100, 22);
            this.txtPosY.TabIndex = 7;
            this.txtPosY.TextChanged += new System.EventHandler(this.txtPosY_TextChanged);
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Location = new System.Drawing.Point(12, 85);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(67, 16);
            this.lblPosY.TabIndex = 6;
            this.lblPosY.Text = "Position Y";
            // 
            // txtMass
            // 
            this.txtMass.Location = new System.Drawing.Point(88, 107);
            this.txtMass.Name = "txtMass";
            this.txtMass.Size = new System.Drawing.Size(100, 22);
            this.txtMass.TabIndex = 9;
            this.txtMass.TextChanged += new System.EventHandler(this.txtMass_TextChanged);
            // 
            // lblMass
            // 
            this.lblMass.AutoSize = true;
            this.lblMass.Location = new System.Drawing.Point(12, 107);
            this.lblMass.Name = "lblMass";
            this.lblMass.Size = new System.Drawing.Size(40, 16);
            this.lblMass.TabIndex = 8;
            this.lblMass.Text = "Mass";
            // 
            // txtCharge
            // 
            this.txtCharge.Location = new System.Drawing.Point(88, 135);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(100, 22);
            this.txtCharge.TabIndex = 11;
            this.txtCharge.TextChanged += new System.EventHandler(this.txtCharge_TextChanged);
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Location = new System.Drawing.Point(12, 135);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(51, 16);
            this.lblCharge.TabIndex = 10;
            this.lblCharge.Text = "Charge";
            this.lblCharge.Click += new System.EventHandler(this.lblCharge_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdd.Location = new System.Drawing.Point(15, 194);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddParticleForm
            // 
            this.AcceptButton = this.btnAdd;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(206, 233);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.lblCharge);
            this.Controls.Add(this.txtMass);
            this.Controls.Add(this.lblMass);
            this.Controls.Add(this.txtPosY);
            this.Controls.Add(this.lblPosY);
            this.Controls.Add(this.txtPosX);
            this.Controls.Add(this.lblPosX);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddParticleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public string ParticleName;
        public double ParticlePosX;
        public double ParticlePosY;
        public double ParticleMass;
        public double ParticleCharge;

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ParticleName = txtName.Text;
        }

        private void txtPosX_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtPosX.Text, out double mass))
            {
                ParticlePosX = mass;
                txtPosX.ForeColor = Color.Black;
            }
            else
            {
                ParticlePosX = 0;
                txtPosX.ForeColor = Color.Red;
            }
        }

        private void txtPosY_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtPosY.Text, out double mass))
            {
                ParticlePosY = mass;
                txtPosY.ForeColor = Color.Black;
            }
            else
            {
                ParticlePosY = 0;
                txtPosY.ForeColor = Color.Red;
            }
        }

        private void txtMass_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtMass.Text, out double mass))
            {
                ParticleMass = mass;
                txtMass.ForeColor = Color.Black;
            }
            else
            {
                ParticleMass = 0;
                txtMass.ForeColor = Color.Red;
            }
        }

        private void txtCharge_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtCharge.Text, out double charge))
            {
                ParticleCharge = charge;
                txtCharge.ForeColor = Color.Black; 
            }
            else
            {
                ParticleCharge = 0; 
                txtCharge.ForeColor = Color.Red; 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void lblCharge_Click(object sender, EventArgs e)
        {

        }
    }
}
