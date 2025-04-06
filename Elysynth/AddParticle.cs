using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Models;

namespace Elysynth
{
    public partial class AddParticle: Form
    {
        public Particle particle;
        public bool Safe = false;

        public AddParticle()
        {
            InitializeComponent();
        }

        private void AddParticle_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Safe)
            {
                float.TryParse(txtPosX.Text, out float x);
                float.TryParse(txtPosY.Text, out float y);
                double.TryParse(txtMass.Text, out double mass);
                double.TryParse(txtCharge.Text, out double charge);

                particle = new Particle();
                particle.Position = new Vector2(x, y);
                particle.Mass = mass;
                particle.Charge = charge;
                particle.Name = "test";
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
        }

        private void txtPosX_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPosX_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtPosX.Text, out double x))
            {
                lblPosX.ForeColor = Color.Red;
                Safe = false;
            }
            else
            {
                lblPosX.ForeColor = Color.Black;
                Safe = true;
            }
        }

        private void txtPosY_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtPosY.Text, out double x))
            {
                lblPosY.ForeColor = Color.Red;
                Safe= false;
            }
            else
            {
                lblPosY.ForeColor = Color.Black;
                Safe = true;
            }
        }

        private void txtMass_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtMass.Text, out double x))
            {
                lblMass.ForeColor = Color.Red;
                Safe = false;
            }
            else
            {
                lblMass.ForeColor = Color.Black;
                Safe = false;
            }
        }

        private void txtCharge_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtCharge.Text, out double x))
            {
                lblCharge.ForeColor = Color.Red;
                Safe = false;
            }
            else
            {
                lblCharge.ForeColor = Color.Black;
                Safe = true;
            }
        }
    }
}
