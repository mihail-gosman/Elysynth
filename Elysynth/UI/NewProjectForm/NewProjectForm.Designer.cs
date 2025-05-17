namespace Elysynth.UI.NewProjectForm
{
    partial class NewProjectForm
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_location = new System.Windows.Forms.Label();
            this.lbl_invalidName = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_location = new System.Windows.Forms.TextBox();
            this.btn_browseFolder = new MetroFramework.Controls.MetroButton();
            this.btn_create = new MetroFramework.Controls.MetroButton();
            this.btn_cancel = new MetroFramework.Controls.MetroButton();
            this.lbl_invalidLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(23, 92);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(44, 16);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name";
            // 
            // lbl_location
            // 
            this.lbl_location.AutoSize = true;
            this.lbl_location.Location = new System.Drawing.Point(23, 180);
            this.lbl_location.Name = "lbl_location";
            this.lbl_location.Size = new System.Drawing.Size(58, 16);
            this.lbl_location.TabIndex = 1;
            this.lbl_location.Text = "Location";
            // 
            // lbl_invalidName
            // 
            this.lbl_invalidName.AutoSize = true;
            this.lbl_invalidName.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_invalidName.Location = new System.Drawing.Point(23, 136);
            this.lbl_invalidName.Name = "lbl_invalidName";
            this.lbl_invalidName.Size = new System.Drawing.Size(86, 16);
            this.lbl_invalidName.TabIndex = 2;
            this.lbl_invalidName.Text = "Invalid name!";
            this.lbl_invalidName.Visible = false;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(23, 111);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(303, 22);
            this.txt_name.TabIndex = 3;
            // 
            // txt_location
            // 
            this.txt_location.Location = new System.Drawing.Point(23, 199);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(303, 22);
            this.txt_location.TabIndex = 4;
            // 
            // btn_browseFolder
            // 
            this.btn_browseFolder.Location = new System.Drawing.Point(332, 199);
            this.btn_browseFolder.Name = "btn_browseFolder";
            this.btn_browseFolder.Size = new System.Drawing.Size(30, 23);
            this.btn_browseFolder.TabIndex = 5;
            this.btn_browseFolder.Text = "...";
            this.btn_browseFolder.Click += new System.EventHandler(this.btn_files_Click);
            // 
            // btn_create
            // 
            this.btn_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_create.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_create.Location = new System.Drawing.Point(230, 259);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(63, 23);
            this.btn_create.TabIndex = 6;
            this.btn_create.Text = "Create";
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(299, 259);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(63, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "Cancel";
            // 
            // lbl_invalidLocation
            // 
            this.lbl_invalidLocation.AutoSize = true;
            this.lbl_invalidLocation.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_invalidLocation.Location = new System.Drawing.Point(23, 224);
            this.lbl_invalidLocation.Name = "lbl_invalidLocation";
            this.lbl_invalidLocation.Size = new System.Drawing.Size(86, 16);
            this.lbl_invalidLocation.TabIndex = 8;
            this.lbl_invalidLocation.Text = "Invalid name!";
            this.lbl_invalidLocation.Visible = false;
            // 
            // NewProjectForm
            // 
            this.AcceptButton = this.btn_create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(387, 294);
            this.Controls.Add(this.lbl_invalidLocation);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.btn_browseFolder);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_invalidName);
            this.Controls.Add(this.lbl_location);
            this.Controls.Add(this.lbl_name);
            this.Name = "NewProjectForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Create a new project";
            this.Load += new System.EventHandler(this.NewProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_location;
        private System.Windows.Forms.Label lbl_invalidName;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_location;
        private MetroFramework.Controls.MetroButton btn_browseFolder;
        private MetroFramework.Controls.MetroButton btn_create;
        private MetroFramework.Controls.MetroButton btn_cancel;
        private System.Windows.Forms.Label lbl_invalidLocation;
    }
}