namespace Elysynth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblInvalidName = new System.Windows.Forms.Label();
            this.btnFileExplorer = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblInvalidLocation = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Name = "panel1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.lblInvalidName);
            this.panel2.Controls.Add(this.btnFileExplorer);
            this.panel2.Controls.Add(this.txtLocation);
            this.panel2.Controls.Add(this.txtProjectName);
            this.panel2.Controls.Add(this.lblLocation);
            this.panel2.Controls.Add(this.lblProjectName);
            this.panel2.Name = "panel2";
            // 
            // lblInvalidName
            // 
            resources.ApplyResources(this.lblInvalidName, "lblInvalidName");
            this.lblInvalidName.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidName.Name = "lblInvalidName";
            // 
            // btnFileExplorer
            // 
            resources.ApplyResources(this.btnFileExplorer, "btnFileExplorer");
            this.btnFileExplorer.Name = "btnFileExplorer";
            this.btnFileExplorer.UseVisualStyleBackColor = true;
            this.btnFileExplorer.Click += new System.EventHandler(this.btnFileExplorer_Click);
            // 
            // txtLocation
            // 
            resources.ApplyResources(this.txtLocation, "txtLocation");
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Leave += new System.EventHandler(this.txtLocation_Leave);
            // 
            // txtProjectName
            // 
            resources.ApplyResources(this.txtProjectName, "txtProjectName");
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Leave += new System.EventHandler(this.txtProjectName_Leave);
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // lblProjectName
            // 
            resources.ApplyResources(this.lblProjectName, "lblProjectName");
            this.lblProjectName.Name = "lblProjectName";
            // 
            // lblInvalidLocation
            // 
            resources.ApplyResources(this.lblInvalidLocation, "lblInvalidLocation");
            this.lblInvalidLocation.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidLocation.Name = "lblInvalidLocation";
            // 
            // NewProjectForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.lblInvalidLocation);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NewProjectForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.NewProjectForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnFileExplorer;
        private System.Windows.Forms.Label lblInvalidName;
        private System.Windows.Forms.Label lblInvalidLocation;
    }
}