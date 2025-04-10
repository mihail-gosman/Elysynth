namespace Elysynth
{
    partial class NewProject
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
            this.metroButtonCreate = new MetroFramework.Controls.MetroButton();
            this.metroButtonCancel = new MetroFramework.Controls.MetroButton();
            this.metroLabelName = new MetroFramework.Controls.MetroLabel();
            this.metroLabelInvalidName = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxName = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxLocation = new MetroFramework.Controls.MetroTextBox();
            this.metroLabelLocation = new MetroFramework.Controls.MetroLabel();
            this.metroButtonFilesExplorer = new MetroFramework.Controls.MetroButton();
            this.metroLabelInvalidLocation = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroButtonCreate
            // 
            this.metroButtonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonCreate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButtonCreate.Location = new System.Drawing.Point(182, 207);
            this.metroButtonCreate.Name = "metroButtonCreate";
            this.metroButtonCreate.Size = new System.Drawing.Size(75, 23);
            this.metroButtonCreate.TabIndex = 0;
            this.metroButtonCreate.Text = "Create";
            this.metroButtonCreate.Click += new System.EventHandler(this.metroButtonCreate_Click);
            // 
            // metroButtonCancel
            // 
            this.metroButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButtonCancel.Location = new System.Drawing.Point(263, 207);
            this.metroButtonCancel.Name = "metroButtonCancel";
            this.metroButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.metroButtonCancel.TabIndex = 1;
            this.metroButtonCancel.Text = "Cancel";
            this.metroButtonCancel.Click += new System.EventHandler(this.metroButtonCancel_Click);
            // 
            // metroLabelName
            // 
            this.metroLabelName.AutoSize = true;
            this.metroLabelName.Location = new System.Drawing.Point(27, 86);
            this.metroLabelName.Name = "metroLabelName";
            this.metroLabelName.Size = new System.Drawing.Size(47, 20);
            this.metroLabelName.TabIndex = 2;
            this.metroLabelName.Text = "Name";
            this.metroLabelName.Click += new System.EventHandler(this.metroLabelName_Click);
            // 
            // metroLabelInvalidName
            // 
            this.metroLabelInvalidName.AutoSize = true;
            this.metroLabelInvalidName.CustomForeColor = true;
            this.metroLabelInvalidName.Enabled = false;
            this.metroLabelInvalidName.ForeColor = System.Drawing.Color.Red;
            this.metroLabelInvalidName.Location = new System.Drawing.Point(27, 109);
            this.metroLabelInvalidName.Name = "metroLabelInvalidName";
            this.metroLabelInvalidName.Size = new System.Drawing.Size(87, 20);
            this.metroLabelInvalidName.TabIndex = 3;
            this.metroLabelInvalidName.Text = "Invalid name";
            this.metroLabelInvalidName.Click += new System.EventHandler(this.metroLabelInvalidName_Click);
            // 
            // metroTextBoxName
            // 
            this.metroTextBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTextBoxName.Location = new System.Drawing.Point(133, 86);
            this.metroTextBoxName.Name = "metroTextBoxName";
            this.metroTextBoxName.Size = new System.Drawing.Size(176, 23);
            this.metroTextBoxName.TabIndex = 4;
            this.metroTextBoxName.Text = "NewProject";
            this.metroTextBoxName.TextChanged += new System.EventHandler(this.metroTextBoxName_TextChanged);
            this.metroTextBoxName.Click += new System.EventHandler(this.metroTextBoxName_Click);
            // 
            // metroTextBoxLocation
            // 
            this.metroTextBoxLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTextBoxLocation.Location = new System.Drawing.Point(133, 141);
            this.metroTextBoxLocation.Name = "metroTextBoxLocation";
            this.metroTextBoxLocation.Size = new System.Drawing.Size(176, 23);
            this.metroTextBoxLocation.TabIndex = 5;
            this.metroTextBoxLocation.Click += new System.EventHandler(this.metroTextBoxLocation_Click);
            // 
            // metroLabelLocation
            // 
            this.metroLabelLocation.AutoSize = true;
            this.metroLabelLocation.Location = new System.Drawing.Point(27, 144);
            this.metroLabelLocation.Name = "metroLabelLocation";
            this.metroLabelLocation.Size = new System.Drawing.Size(61, 20);
            this.metroLabelLocation.TabIndex = 6;
            this.metroLabelLocation.Text = "Location";
            this.metroLabelLocation.Click += new System.EventHandler(this.metroLabelLocation_Click);
            // 
            // metroButtonFilesExplorer
            // 
            this.metroButtonFilesExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonFilesExplorer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButtonFilesExplorer.Location = new System.Drawing.Point(315, 141);
            this.metroButtonFilesExplorer.Name = "metroButtonFilesExplorer";
            this.metroButtonFilesExplorer.Size = new System.Drawing.Size(23, 23);
            this.metroButtonFilesExplorer.TabIndex = 7;
            this.metroButtonFilesExplorer.Text = "...";
            this.metroButtonFilesExplorer.Click += new System.EventHandler(this.metroButtonFilesExplorer_Click);
            // 
            // metroLabelInvalidLocation
            // 
            this.metroLabelInvalidLocation.AutoSize = true;
            this.metroLabelInvalidLocation.CustomForeColor = true;
            this.metroLabelInvalidLocation.Enabled = false;
            this.metroLabelInvalidLocation.ForeColor = System.Drawing.Color.Red;
            this.metroLabelInvalidLocation.Location = new System.Drawing.Point(27, 164);
            this.metroLabelInvalidLocation.Name = "metroLabelInvalidLocation";
            this.metroLabelInvalidLocation.Size = new System.Drawing.Size(100, 20);
            this.metroLabelInvalidLocation.TabIndex = 8;
            this.metroLabelInvalidLocation.Text = "Invalid location";
            this.metroLabelInvalidLocation.Click += new System.EventHandler(this.metroLabelInvalidLocation_Click);
            // 
            // NewProject
            // 
            this.AcceptButton = this.metroButtonCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.CancelButton = this.metroButtonCancel;
            this.ClientSize = new System.Drawing.Size(363, 252);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabelInvalidLocation);
            this.Controls.Add(this.metroButtonFilesExplorer);
            this.Controls.Add(this.metroLabelLocation);
            this.Controls.Add(this.metroTextBoxLocation);
            this.Controls.Add(this.metroTextBoxName);
            this.Controls.Add(this.metroLabelInvalidName);
            this.Controls.Add(this.metroLabelName);
            this.Controls.Add(this.metroButtonCancel);
            this.Controls.Add(this.metroButtonCreate);
            this.Name = "NewProject";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "New Elysynth Project";
            this.Load += new System.EventHandler(this.NewProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButtonCreate;
        private MetroFramework.Controls.MetroButton metroButtonCancel;
        private MetroFramework.Controls.MetroLabel metroLabelName;
        private MetroFramework.Controls.MetroLabel metroLabelInvalidName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxLocation;
        private MetroFramework.Controls.MetroLabel metroLabelLocation;
        private MetroFramework.Controls.MetroButton metroButtonFilesExplorer;
        private MetroFramework.Controls.MetroLabel metroLabelInvalidLocation;
    }
}