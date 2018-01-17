namespace com.amtec.forms
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.lblLoginTime = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel9 = new System.Windows.Forms.Panel();
            this.picUserSkill = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSet = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picNet = new System.Windows.Forms.PictureBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.lblStationNO = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new CSharpWin.TabControlEx();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.messageControl1 = new MessageControl.MessageControl();
            this.txtIPAndPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSocket = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSocket = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.notifyIconPortal = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridEquipment = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnImportEquipment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSocket.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabEquipment.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipment)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // lblLoginTime
            // 
            this.lblLoginTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginTime.AutoSize = true;
            this.lblLoginTime.Location = new System.Drawing.Point(867, 28);
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new System.Drawing.Size(108, 17);
            this.lblLoginTime.TabIndex = 26;
            this.lblLoginTime.Text = "10.10.13 00:00:00";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(867, 8);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(135, 17);
            this.lblUser.TabIndex = 24;
            this.lblUser.Text = "User Name / [Station]";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // panel9
            // 
            this.panel9.BackgroundImage = global::TTEInterface.Properties.Resources.Station_icon_32x32;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Location = new System.Drawing.Point(115, 11);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(32, 32);
            this.panel9.TabIndex = 37;
            this.toolTip1.SetToolTip(this.panel9, "Station ID");
            // 
            // picUserSkill
            // 
            this.picUserSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUserSkill.BackgroundImage = global::TTEInterface.Properties.Resources.UserSkill_Green_32x32;
            this.picUserSkill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUserSkill.Location = new System.Drawing.Point(791, 11);
            this.picUserSkill.Name = "picUserSkill";
            this.picUserSkill.Size = new System.Drawing.Size(32, 32);
            this.picUserSkill.TabIndex = 36;
            this.toolTip1.SetToolTip(this.picUserSkill, "Skill Level: xx");
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImage = global::TTEInterface.Properties.Resources.Info_Gray_40x40;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(750, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 32);
            this.panel2.TabIndex = 36;
            this.toolTip1.SetToolTip(this.panel2, "Information");
            // 
            // panelSet
            // 
            this.panelSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSet.BackgroundImage = global::TTEInterface.Properties.Resources.Setting_Gray_40x40;
            this.panelSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSet.Location = new System.Drawing.Point(709, 11);
            this.panelSet.Name = "panelSet";
            this.panelSet.Size = new System.Drawing.Size(32, 32);
            this.panelSet.TabIndex = 35;
            this.toolTip1.SetToolTip(this.panelSet, "Configuration");
            this.panelSet.Click += new System.EventHandler(this.panelSet_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImage = global::TTEInterface.Properties.Resources.User_Green_32x32;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(829, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Double Click to Logout...");
            // 
            // picNet
            // 
            this.picNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picNet.BackgroundImage = global::TTEInterface.Properties.Resources.NetWorkConnectedGreen24x24;
            this.picNet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picNet.Location = new System.Drawing.Point(975, 660);
            this.picNet.Name = "picNet";
            this.picNet.Size = new System.Drawing.Size(24, 24);
            this.picNet.TabIndex = 29;
            this.picNet.TabStop = false;
            this.toolTip1.SetToolTip(this.picNet, "Network Connected");
            // 
            // lblStationNO
            // 
            this.lblStationNO.AutoSize = true;
            this.lblStationNO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationNO.Location = new System.Drawing.Point(153, 18);
            this.lblStationNO.Name = "lblStationNO";
            this.lblStationNO.Size = new System.Drawing.Size(82, 21);
            this.lblStationNO.TabIndex = 38;
            this.lblStationNO.Text = "00110010";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(79)))), ((int)(((byte)(125)))));
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(164)))), ((int)(((byte)(201)))));
            this.tabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(164)))), ((int)(((byte)(201)))));
            this.tabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(164)))), ((int)(((byte)(201)))));
            this.tabControl1.Controls.Add(this.tabDetail);
            this.tabControl1.Controls.Add(this.tabSocket);
            this.tabControl1.Controls.Add(this.tabEquipment);
            this.tabControl1.ItemSize = new System.Drawing.Size(85, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 603);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 39;
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.panel3);
            this.tabDetail.Location = new System.Drawing.Point(4, 26);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetail.Size = new System.Drawing.Size(1000, 573);
            this.tabDetail.TabIndex = 0;
            this.tabDetail.Text = "Detail";
            this.tabDetail.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.messageControl1);
            this.panel3.Controls.Add(this.txtIPAndPort);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.txtUser);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtSID);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 567);
            this.panel3.TabIndex = 0;
            // 
            // messageControl1
            // 
            this.messageControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageControl1.Content = "";
            this.messageControl1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageControl1.Location = new System.Drawing.Point(517, 7);
            this.messageControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messageControl1.MsgBackColor = System.Drawing.Color.Empty;
            this.messageControl1.Name = "messageControl1";
            this.messageControl1.PicType = "";
            this.messageControl1.Size = new System.Drawing.Size(472, 97);
            this.messageControl1.TabIndex = 57;
            this.messageControl1.Title = "";
            // 
            // txtIPAndPort
            // 
            this.txtIPAndPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPAndPort.Location = new System.Drawing.Point(299, 79);
            this.txtIPAndPort.Name = "txtIPAndPort";
            this.txtIPAndPort.Size = new System.Drawing.Size(212, 25);
            this.txtIPAndPort.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "IP/Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 30);
            this.label3.TabIndex = 54;
            this.label3.Text = "Database Connected :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtConsole);
            this.groupBox1.Location = new System.Drawing.Point(0, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(994, 456);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Console";
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(3, 21);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(988, 432);
            this.txtConsole.TabIndex = 2;
            this.txtConsole.Text = "";
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Location = new System.Drawing.Point(299, 41);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(212, 25);
            this.txtUser.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 48;
            this.label2.Text = "User";
            // 
            // txtSID
            // 
            this.txtSID.BackColor = System.Drawing.Color.White;
            this.txtSID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSID.Location = new System.Drawing.Point(299, 7);
            this.txtSID.Name = "txtSID";
            this.txtSID.Size = new System.Drawing.Size(212, 25);
            this.txtSID.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "SID";
            // 
            // tabSocket
            // 
            this.tabSocket.Controls.Add(this.panel1);
            this.tabSocket.Location = new System.Drawing.Point(4, 26);
            this.tabSocket.Name = "tabSocket";
            this.tabSocket.Size = new System.Drawing.Size(1000, 573);
            this.tabSocket.TabIndex = 1;
            this.tabSocket.Text = "Socket";
            this.tabSocket.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSocket);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 573);
            this.panel1.TabIndex = 0;
            // 
            // txtSocket
            // 
            this.txtSocket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSocket.Location = new System.Drawing.Point(0, 0);
            this.txtSocket.Name = "txtSocket";
            this.txtSocket.ReadOnly = true;
            this.txtSocket.Size = new System.Drawing.Size(1000, 573);
            this.txtSocket.TabIndex = 3;
            this.txtSocket.Text = "";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TTEInterface.Properties.Resources.Bar_Gray_100x12;
            this.pictureBox5.Location = new System.Drawing.Point(0, 49);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(100, 5);
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox7.BackgroundImage = global::TTEInterface.Properties.Resources.Caption_Orange;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(83, 49);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(949, 5);
            this.pictureBox7.TabIndex = 34;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::TTEInterface.Properties.Resources.DMS_100x50;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(0, -2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // notifyIconPortal
            // 
            this.notifyIconPortal.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconPortal.Icon")));
            this.notifyIconPortal.Text = "Portal01";
            this.notifyIconPortal.Visible = true;
            this.notifyIconPortal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconPortal_MouseDoubleClick);
            this.notifyIconPortal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIconPortal_MouseDown);
            // 
            // tabEquipment
            // 
            this.tabEquipment.Controls.Add(this.tableLayoutPanel1);
            this.tabEquipment.Location = new System.Drawing.Point(4, 26);
            this.tabEquipment.Name = "tabEquipment";
            this.tabEquipment.Size = new System.Drawing.Size(1000, 573);
            this.tabEquipment.TabIndex = 2;
            this.tabEquipment.Text = "Equipment";
            this.tabEquipment.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridEquipment, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 573);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridEquipment
            // 
            this.gridEquipment.AllowUserToAddRows = false;
            this.gridEquipment.AllowUserToDeleteRows = false;
            this.gridEquipment.AllowUserToResizeRows = false;
            this.gridEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.gridEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEquipment.Location = new System.Drawing.Point(175, 3);
            this.gridEquipment.Name = "gridEquipment";
            this.gridEquipment.ReadOnly = true;
            this.gridEquipment.RowHeadersVisible = false;
            this.gridEquipment.RowTemplate.Height = 23;
            this.gridEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEquipment.Size = new System.Drawing.Size(822, 567);
            this.gridEquipment.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Equipment_Number";
            this.Column1.HeaderText = "设备编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Equipment_Description";
            this.Column2.HeaderText = "设备描述";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "Equipmemnt_Part_Number";
            this.Column3.HeaderText = "设备料号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Valid_To";
            this.Column4.HeaderText = "有效日期至";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "Next_Maintenance_Time";
            this.Column5.HeaderText = "下次维护日期";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "Max_Usage";
            this.Column6.HeaderText = "最大使用次数";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnImportEquipment);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(172, 573);
            this.panel4.TabIndex = 2;
            // 
            // btnImportEquipment
            // 
            this.btnImportEquipment.Location = new System.Drawing.Point(3, 30);
            this.btnImportEquipment.Name = "btnImportEquipment";
            this.btnImportEquipment.Size = new System.Drawing.Size(166, 32);
            this.btnImportEquipment.TabIndex = 0;
            this.btnImportEquipment.Text = "导入设备";
            this.btnImportEquipment.UseVisualStyleBackColor = true;
            this.btnImportEquipment.Click += new System.EventHandler(this.btnImportEquipment_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1008, 682);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblStationNO);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.picUserSkill);
            this.Controls.Add(this.lblLoginTime);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSet);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picNet);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal Interface (v1.0.0.1)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.Shown += new System.EventHandler(this.MainView_Shown);
            this.SizeChanged += new System.EventHandler(this.MainView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDetail.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabSocket.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabEquipment.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipment)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblLoginTime;
        private System.Windows.Forms.PictureBox picNet;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSet;
        private System.Windows.Forms.Panel picUserSkill;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblStationNO;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private CSharpWin.TabControlEx tabControl1;
        private System.Windows.Forms.TabPage tabDetail;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.TextBox txtIPAndPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSID;
        private System.Windows.Forms.Label label1;
        private MessageControl.MessageControl messageControl1;
        private System.Windows.Forms.TabPage tabSocket;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtSocket;
        private System.Windows.Forms.NotifyIcon notifyIconPortal;
        private System.Windows.Forms.TabPage tabEquipment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView gridEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnImportEquipment;
    }
}

