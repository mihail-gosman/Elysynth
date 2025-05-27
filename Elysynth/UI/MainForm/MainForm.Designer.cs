namespace Elysynth.UI.MainForm
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.particleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pic_stopSimulation = new System.Windows.Forms.PictureBox();
            this.pic_startSimulation = new System.Windows.Forms.PictureBox();
            this.pic_newProject = new System.Windows.Forms.PictureBox();
            this.pic_openProject = new System.Windows.Forms.PictureBox();
            this.pic_saveProject = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panelEntities = new System.Windows.Forms.Panel();
            this.toolStripEntities = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txt_entities = new System.Windows.Forms.ToolStripTextBox();
            this.panel_entity = new System.Windows.Forms.Panel();
            this.panelEntity = new System.Windows.Forms.Panel();
            this.grid_entity = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lbl_title = new System.Windows.Forms.Label();
            this.contextEntities = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_stopSimulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_startSimulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_newProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_openProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_saveProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.toolStripEntities.SuspendLayout();
            this.panel_entity.SuspendLayout();
            this.panelEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_entity)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextEntities.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem,
            this.projectToolStripMenuItem,
            this.simulationToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 30);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(907, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.projectToolStripMenuItem.Enabled = false;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.particleToolStripMenuItem,
            this.fieldToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // particleToolStripMenuItem
            // 
            this.particleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("particleToolStripMenuItem.Image")));
            this.particleToolStripMenuItem.Name = "particleToolStripMenuItem";
            this.particleToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.particleToolStripMenuItem.Text = "Particle";
            this.particleToolStripMenuItem.Click += new System.EventHandler(this.particleToolStripMenuItem_Click);
            // 
            // fieldToolStripMenuItem
            // 
            this.fieldToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fieldToolStripMenuItem.Image")));
            this.fieldToolStripMenuItem.Name = "fieldToolStripMenuItem";
            this.fieldToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.fieldToolStripMenuItem.Text = "Field";
            this.fieldToolStripMenuItem.Click += new System.EventHandler(this.fieldToolStripMenuItem_Click);
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItem.Image")));
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItem.Image")));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_status});
            this.statusStrip1.Location = new System.Drawing.Point(2, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(907, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip";
            // 
            // lbl_status
            // 
            this.lbl_status.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(50, 20);
            this.lbl_status.Text = "Ready";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(2, 58);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pic_stopSimulation);
            this.splitContainer1.Panel1.Controls.Add(this.pic_startSimulation);
            this.splitContainer1.Panel1.Controls.Add(this.pic_newProject);
            this.splitContainer1.Panel1.Controls.Add(this.pic_openProject);
            this.splitContainer1.Panel1.Controls.Add(this.pic_saveProject);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(907, 435);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 4;
            // 
            // pic_stopSimulation
            // 
            this.pic_stopSimulation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_stopSimulation.BackgroundImage")));
            this.pic_stopSimulation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_stopSimulation.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_stopSimulation.InitialImage")));
            this.pic_stopSimulation.Location = new System.Drawing.Point(130, 6);
            this.pic_stopSimulation.Name = "pic_stopSimulation";
            this.pic_stopSimulation.Size = new System.Drawing.Size(23, 20);
            this.pic_stopSimulation.TabIndex = 10;
            this.pic_stopSimulation.TabStop = false;
            this.pic_stopSimulation.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            this.pic_stopSimulation.MouseLeave += new System.EventHandler(this.pic_stopSimulation_MouseLeave);
            this.pic_stopSimulation.MouseHover += new System.EventHandler(this.pic_stopSimulation_MouseHover);
            // 
            // pic_startSimulation
            // 
            this.pic_startSimulation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_startSimulation.BackgroundImage")));
            this.pic_startSimulation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_startSimulation.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_startSimulation.InitialImage")));
            this.pic_startSimulation.Location = new System.Drawing.Point(101, 6);
            this.pic_startSimulation.Name = "pic_startSimulation";
            this.pic_startSimulation.Size = new System.Drawing.Size(23, 20);
            this.pic_startSimulation.TabIndex = 9;
            this.pic_startSimulation.TabStop = false;
            this.pic_startSimulation.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            this.pic_startSimulation.MouseLeave += new System.EventHandler(this.pic_startSimulation_MouseLeave);
            this.pic_startSimulation.MouseHover += new System.EventHandler(this.pic_startSimulation_MouseHover);
            // 
            // pic_newProject
            // 
            this.pic_newProject.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_newProject.BackgroundImage")));
            this.pic_newProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_newProject.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_newProject.InitialImage")));
            this.pic_newProject.Location = new System.Drawing.Point(0, 6);
            this.pic_newProject.Name = "pic_newProject";
            this.pic_newProject.Size = new System.Drawing.Size(23, 20);
            this.pic_newProject.TabIndex = 8;
            this.pic_newProject.TabStop = false;
            this.pic_newProject.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            this.pic_newProject.MouseLeave += new System.EventHandler(this.pic_newProject_MouseLeave);
            this.pic_newProject.MouseHover += new System.EventHandler(this.pic_newProject_MouseHover);
            // 
            // pic_openProject
            // 
            this.pic_openProject.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_openProject.BackgroundImage")));
            this.pic_openProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_openProject.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_openProject.InitialImage")));
            this.pic_openProject.Location = new System.Drawing.Point(29, 6);
            this.pic_openProject.Name = "pic_openProject";
            this.pic_openProject.Size = new System.Drawing.Size(23, 20);
            this.pic_openProject.TabIndex = 7;
            this.pic_openProject.TabStop = false;
            this.pic_openProject.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            this.pic_openProject.MouseLeave += new System.EventHandler(this.pic_openProject_MouseLeave);
            this.pic_openProject.MouseHover += new System.EventHandler(this.pic_openProject_MouseHover);
            // 
            // pic_saveProject
            // 
            this.pic_saveProject.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_saveProject.BackgroundImage")));
            this.pic_saveProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_saveProject.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_saveProject.InitialImage")));
            this.pic_saveProject.Location = new System.Drawing.Point(58, 6);
            this.pic_saveProject.Name = "pic_saveProject";
            this.pic_saveProject.Size = new System.Drawing.Size(23, 20);
            this.pic_saveProject.TabIndex = 6;
            this.pic_saveProject.TabStop = false;
            this.pic_saveProject.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            this.pic_saveProject.MouseLeave += new System.EventHandler(this.pic_saveProject_MouseLeave);
            this.pic_saveProject.MouseHover += new System.EventHandler(this.pic_saveProject_MouseHover);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(907, 406);
            this.splitContainer2.SplitterDistance = 527;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panelEntities);
            this.splitContainer3.Panel1.Controls.Add(this.toolStripEntities);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel_entity);
            this.splitContainer3.Size = new System.Drawing.Size(376, 406);
            this.splitContainer3.SplitterDistance = 203;
            this.splitContainer3.TabIndex = 0;
            // 
            // panelEntities
            // 
            this.panelEntities.AutoScroll = true;
            this.panelEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEntities.Location = new System.Drawing.Point(0, 27);
            this.panelEntities.Name = "panelEntities";
            this.panelEntities.Size = new System.Drawing.Size(374, 174);
            this.panelEntities.TabIndex = 1;
            // 
            // toolStripEntities
            // 
            this.toolStripEntities.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEntities.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripEntities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.txt_entities});
            this.toolStripEntities.Location = new System.Drawing.Point(0, 0);
            this.toolStripEntities.Name = "toolStripEntities";
            this.toolStripEntities.Size = new System.Drawing.Size(374, 27);
            this.toolStripEntities.TabIndex = 0;
            this.toolStripEntities.Text = "toolStripEntities";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(57, 24);
            this.toolStripLabel1.Text = "Entities";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // txt_entities
            // 
            this.txt_entities.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_entities.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txt_entities.Name = "txt_entities";
            this.txt_entities.Size = new System.Drawing.Size(70, 27);
            this.txt_entities.Text = "Search...";
            this.txt_entities.Enter += new System.EventHandler(this.txt_entities_Enter);
            this.txt_entities.Leave += new System.EventHandler(this.txt_entities_Leave);
            this.txt_entities.TextChanged += new System.EventHandler(this.txt_entities_TextChanged);
            // 
            // panel_entity
            // 
            this.panel_entity.Controls.Add(this.panelEntity);
            this.panel_entity.Controls.Add(this.toolStrip1);
            this.panel_entity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_entity.Location = new System.Drawing.Point(0, 0);
            this.panel_entity.Name = "panel_entity";
            this.panel_entity.Size = new System.Drawing.Size(374, 197);
            this.panel_entity.TabIndex = 0;
            // 
            // panelEntity
            // 
            this.panelEntity.AutoScroll = true;
            this.panelEntity.Controls.Add(this.grid_entity);
            this.panelEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEntity.Location = new System.Drawing.Point(0, 25);
            this.panelEntity.Name = "panelEntity";
            this.panelEntity.Size = new System.Drawing.Size(374, 172);
            this.panelEntity.TabIndex = 1;
            // 
            // grid_entity
            // 
            this.grid_entity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_entity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_entity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_entity.Location = new System.Drawing.Point(0, 0);
            this.grid_entity.Name = "grid_entity";
            this.grid_entity.RowHeadersWidth = 51;
            this.grid_entity.RowTemplate.Height = 24;
            this.grid_entity.Size = new System.Drawing.Size(374, 172);
            this.grid_entity.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(374, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel2.Text = "Proprieties";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(5, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(57, 16);
            this.lbl_title.TabIndex = 5;
            this.lbl_title.Text = "Elysynth";
            // 
            // contextEntities
            // 
            this.contextEntities.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextEntities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextEntities.Name = "contextMenuStrip1";
            this.contextEntities.Size = new System.Drawing.Size(123, 28);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 519);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DisplayHeader = false;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2, 30, 2, 0);
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_stopSimulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_startSimulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_newProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_openProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_saveProject)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.toolStripEntities.ResumeLayout(false);
            this.toolStripEntities.PerformLayout();
            this.panel_entity.ResumeLayout(false);
            this.panel_entity.PerformLayout();
            this.panelEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_entity)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextEntities.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status;
        private System.Windows.Forms.Panel panel_entity;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStripEntities;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox txt_entities;
        private System.Windows.Forms.Panel panelEntities;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panelEntity;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridView grid_entity;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextEntities;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem particleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem;
        private System.Windows.Forms.PictureBox pic_saveProject;
        private System.Windows.Forms.PictureBox pic_newProject;
        private System.Windows.Forms.PictureBox pic_openProject;
        private System.Windows.Forms.PictureBox pic_stopSimulation;
        private System.Windows.Forms.PictureBox pic_startSimulation;
    }
}