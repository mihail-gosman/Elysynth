namespace Elysynth
{
    partial class AddParticle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.brnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.lblPosY = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMass = new System.Windows.Forms.Label();
            this.lblCharge = new System.Windows.Forms.Label();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.txtMass = new System.Windows.Forms.TextBox();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(26, 202);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // brnCancel
            // 
            this.brnCancel.Location = new System.Drawing.Point(0, 0);
            this.brnCancel.Name = "brnCancel";
            this.brnCancel.Size = new System.Drawing.Size(75, 23);
            this.brnCancel.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Location = new System.Drawing.Point(12, 40);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(66, 16);
            this.lblPosX.TabIndex = 3;
            this.lblPosX.Text = "Position X";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Location = new System.Drawing.Point(11, 72);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(67, 16);
            this.lblPosY.TabIndex = 4;
            this.lblPosY.Text = "Position Y";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            // 
            // lblMass
            // 
            this.lblMass.AutoSize = true;
            this.lblMass.Location = new System.Drawing.Point(12, 106);
            this.lblMass.Name = "lblMass";
            this.lblMass.Size = new System.Drawing.Size(40, 16);
            this.lblMass.TabIndex = 5;
            this.lblMass.Text = "Mass";
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Location = new System.Drawing.Point(12, 138);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(51, 16);
            this.lblCharge.TabIndex = 6;
            this.lblCharge.Text = "Charge";
            // 
            // txtPosX
            // 
            this.txtPosX.Location = new System.Drawing.Point(94, 37);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(100, 22);
            this.txtPosX.TabIndex = 7;
            this.txtPosX.TextChanged += new System.EventHandler(this.txtPosX_TextChanged);
            this.txtPosX.Leave += new System.EventHandler(this.txtPosX_Leave);
            // 
            // txtPosY
            // 
            this.txtPosY.Location = new System.Drawing.Point(94, 66);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(100, 22);
            this.txtPosY.TabIndex = 8;
            // 
            // txtMass
            // 
            this.txtMass.Location = new System.Drawing.Point(94, 100);
            this.txtMass.Name = "txtMass";
            this.txtMass.Size = new System.Drawing.Size(100, 22);
            this.txtMass.TabIndex = 9;
            // 
            // txtCharge
            // 
            this.txtCharge.Location = new System.Drawing.Point(94, 129);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(100, 22);
            this.txtCharge.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 25);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddParticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 237);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.txtMass);
            this.Controls.Add(this.txtPosY);
            this.Controls.Add(this.txtPosX);
            this.Controls.Add(this.lblCharge);
            this.Controls.Add(this.lblMass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPosY);
            this.Controls.Add(this.lblPosX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.brnCancel);
            this.Controls.Add(this.btnAdd);
            this.Name = "AddParticle";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AddParticle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button brnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMass;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.TextBox txtPosX;
        private System.Windows.Forms.TextBox txtPosY;
        private System.Windows.Forms.TextBox txtMass;
        private System.Windows.Forms.TextBox txtCharge;
        private System.Windows.Forms.Button btnCancel;
    }
}