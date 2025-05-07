namespace Elysynth
{
    partial class NewProjectWindow
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
            this.lbl_projectName = new MetroFramework.Controls.MetroLabel();
            this.lbl_location = new MetroFramework.Controls.MetroLabel();
            this.txt_projectName = new MetroFramework.Controls.MetroTextBox();
            this.txt_location = new MetroFramework.Controls.MetroTextBox();
            this.btn_create = new MetroFramework.Controls.MetroButton();
            this.btn_cancel = new MetroFramework.Controls.MetroButton();
            this.lbl_invalidName = new MetroFramework.Controls.MetroLabel();
            this.lbl_invalidLocation = new MetroFramework.Controls.MetroLabel();
            this.btn_fileExplorer = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lbl_projectName
            // 
            this.lbl_projectName.AutoSize = true;
            this.lbl_projectName.Location = new System.Drawing.Point(23, 80);
            this.lbl_projectName.Name = "lbl_projectName";
            this.lbl_projectName.Size = new System.Drawing.Size(91, 20);
            this.lbl_projectName.TabIndex = 0;
            this.lbl_projectName.Text = "Project name";
            // 
            // lbl_location
            // 
            this.lbl_location.AutoSize = true;
            this.lbl_location.Location = new System.Drawing.Point(24, 165);
            this.lbl_location.Name = "lbl_location";
            this.lbl_location.Size = new System.Drawing.Size(61, 20);
            this.lbl_location.TabIndex = 1;
            this.lbl_location.Text = "Location";
            // 
            // txt_projectName
            // 
            this.txt_projectName.Location = new System.Drawing.Point(24, 104);
            this.txt_projectName.Name = "txt_projectName";
            this.txt_projectName.Size = new System.Drawing.Size(366, 23);
            this.txt_projectName.TabIndex = 2;
            this.txt_projectName.Text = "metroTextBox1";
            // 
            // txt_location
            // 
            this.txt_location.Location = new System.Drawing.Point(23, 188);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(366, 23);
            this.txt_location.TabIndex = 3;
            this.txt_location.Text = "metroTextBox2";
            // 
            // btn_create
            // 
            this.btn_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_create.Location = new System.Drawing.Point(255, 255);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(83, 32);
            this.btn_create.TabIndex = 4;
            this.btn_create.Text = "Create";
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(344, 255);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(83, 32);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            // 
            // lbl_invalidName
            // 
            this.lbl_invalidName.AutoSize = true;
            this.lbl_invalidName.CustomForeColor = true;
            this.lbl_invalidName.Enabled = false;
            this.lbl_invalidName.ForeColor = System.Drawing.Color.Red;
            this.lbl_invalidName.Location = new System.Drawing.Point(23, 130);
            this.lbl_invalidName.Name = "lbl_invalidName";
            this.lbl_invalidName.Size = new System.Drawing.Size(91, 20);
            this.lbl_invalidName.TabIndex = 6;
            this.lbl_invalidName.Text = "Invalid name!";
            this.lbl_invalidName.UseStyleColors = true;
            this.lbl_invalidName.Visible = false;
            // 
            // lbl_invalidLocation
            // 
            this.lbl_invalidLocation.AutoSize = true;
            this.lbl_invalidLocation.CustomForeColor = true;
            this.lbl_invalidLocation.Enabled = false;
            this.lbl_invalidLocation.ForeColor = System.Drawing.Color.Red;
            this.lbl_invalidLocation.Location = new System.Drawing.Point(23, 214);
            this.lbl_invalidLocation.Name = "lbl_invalidLocation";
            this.lbl_invalidLocation.Size = new System.Drawing.Size(104, 20);
            this.lbl_invalidLocation.TabIndex = 7;
            this.lbl_invalidLocation.Text = "Invalid location!";
            this.lbl_invalidLocation.UseStyleColors = true;
            this.lbl_invalidLocation.Visible = false;
            // 
            // btn_fileExplorer
            // 
            this.btn_fileExplorer.Location = new System.Drawing.Point(395, 188);
            this.btn_fileExplorer.Name = "btn_fileExplorer";
            this.btn_fileExplorer.Size = new System.Drawing.Size(35, 23);
            this.btn_fileExplorer.TabIndex = 8;
            this.btn_fileExplorer.Text = "...";
            this.btn_fileExplorer.Click += new System.EventHandler(this.btn_fileExplorer_Click);
            // 
            // NewProjectWindow
            // 
            this.AcceptButton = this.btn_create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(450, 310);
            this.ControlBox = false;
            this.Controls.Add(this.btn_fileExplorer);
            this.Controls.Add(this.lbl_invalidLocation);
            this.Controls.Add(this.lbl_invalidName);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.txt_projectName);
            this.Controls.Add(this.lbl_location);
            this.Controls.Add(this.lbl_projectName);
            this.Name = "NewProjectWindow";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Create a new project";
            this.Load += new System.EventHandler(this.NewProjectWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lbl_projectName;
        private MetroFramework.Controls.MetroLabel lbl_location;
        private MetroFramework.Controls.MetroTextBox txt_projectName;
        private MetroFramework.Controls.MetroTextBox txt_location;
        private MetroFramework.Controls.MetroButton btn_create;
        private MetroFramework.Controls.MetroButton btn_cancel;
        private MetroFramework.Controls.MetroLabel lbl_invalidName;
        private MetroFramework.Controls.MetroLabel lbl_invalidLocation;
        private MetroFramework.Controls.MetroButton btn_fileExplorer;
    }
}