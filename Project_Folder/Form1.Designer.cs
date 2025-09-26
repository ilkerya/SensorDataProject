﻿

namespace SensorData
{
    partial class Form1
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
            this.SP1_serialPort = new System.IO.Ports.SerialPort(this.components);
            this.Base_Timer1mSec = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SP1_SendtextBox = new System.Windows.Forms.TextBox();
            this.SP1_DisConnectButton = new System.Windows.Forms.Button();
            this.SP1_IO_Serial_lstCOMPorts = new System.Windows.Forms.ComboBox();
            this.SP1_ConnectButton = new System.Windows.Forms.Button();
            this.SP1_textBox_PortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SP1_SendButton = new System.Windows.Forms.Button();
            this.SP1_DatatextBox = new System.Windows.Forms.TextBox();
            this.SP1_richTextBox = new System.Windows.Forms.RichTextBox();
            this.checkBox_Temperature = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comPortListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataLoggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotSurface2D1 = new NPlot.Windows.PlotSurface2D();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_Humidity = new System.Windows.Forms.CheckBox();
            this.SP1_textBox_Device = new System.Windows.Forms.TextBox();
            this.checkBox_Light = new System.Windows.Forms.CheckBox();
            this.checkBox_InfraLight = new System.Windows.Forms.CheckBox();
            this.checkBox_FanSpeed = new System.Windows.Forms.CheckBox();
            this.checkBox_AccX = new System.Windows.Forms.CheckBox();
            this.checkBox_AccY = new System.Windows.Forms.CheckBox();
            this.checkBox_AccZ = new System.Windows.Forms.CheckBox();
            this.checkBox_GyrZ = new System.Windows.Forms.CheckBox();
            this.checkBox_GyrY = new System.Windows.Forms.CheckBox();
            this.checkBox_GyrX = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SP1_serialPort
            // 
            this.SP1_serialPort.BaudRate = 115200;
            this.SP1_serialPort.PortName = "COM2";
            this.SP1_serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SP1_serialPort_DataReceived);
            // 
            // Base_Timer1mSec
            // 
            this.Base_Timer1mSec.Enabled = true;
            this.Base_Timer1mSec.Interval = 16;
            this.Base_Timer1mSec.Tick += new System.EventHandler(this.Base_Timer1mSec_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(258, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 736;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SP1_SendtextBox
            // 
            this.SP1_SendtextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_SendtextBox.Location = new System.Drawing.Point(11, 179);
            this.SP1_SendtextBox.Multiline = true;
            this.SP1_SendtextBox.Name = "SP1_SendtextBox";
            this.SP1_SendtextBox.Size = new System.Drawing.Size(329, 55);
            this.SP1_SendtextBox.TabIndex = 729;
            this.SP1_SendtextBox.Text = "Send Log";
            // 
            // SP1_DisConnectButton
            // 
            this.SP1_DisConnectButton.BackColor = System.Drawing.Color.Transparent;
            this.SP1_DisConnectButton.Enabled = false;
            this.SP1_DisConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SP1_DisConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.SP1_DisConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SP1_DisConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_DisConnectButton.ForeColor = System.Drawing.Color.Black;
            this.SP1_DisConnectButton.Location = new System.Drawing.Point(452, 48);
            this.SP1_DisConnectButton.Name = "SP1_DisConnectButton";
            this.SP1_DisConnectButton.Size = new System.Drawing.Size(102, 29);
            this.SP1_DisConnectButton.TabIndex = 732;
            this.SP1_DisConnectButton.Text = "Close";
            this.SP1_DisConnectButton.UseVisualStyleBackColor = false;
            this.SP1_DisConnectButton.Visible = false;
            this.SP1_DisConnectButton.Click += new System.EventHandler(this.SP1_DisConnectButton_Click);
            // 
            // SP1_IO_Serial_lstCOMPorts
            // 
            this.SP1_IO_Serial_lstCOMPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SP1_IO_Serial_lstCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SP1_IO_Serial_lstCOMPorts.ForeColor = System.Drawing.Color.Black;
            this.SP1_IO_Serial_lstCOMPorts.Items.AddRange(new object[] {
            "COM56"});
            this.SP1_IO_Serial_lstCOMPorts.Location = new System.Drawing.Point(595, 53);
            this.SP1_IO_Serial_lstCOMPorts.Name = "SP1_IO_Serial_lstCOMPorts";
            this.SP1_IO_Serial_lstCOMPorts.Size = new System.Drawing.Size(129, 24);
            this.SP1_IO_Serial_lstCOMPorts.TabIndex = 731;
            this.SP1_IO_Serial_lstCOMPorts.Visible = false;
            // 
            // SP1_ConnectButton
            // 
            this.SP1_ConnectButton.BackColor = System.Drawing.Color.Transparent;
            this.SP1_ConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SP1_ConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.SP1_ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SP1_ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_ConnectButton.ForeColor = System.Drawing.Color.Black;
            this.SP1_ConnectButton.Location = new System.Drawing.Point(13, 86);
            this.SP1_ConnectButton.Name = "SP1_ConnectButton";
            this.SP1_ConnectButton.Size = new System.Drawing.Size(121, 85);
            this.SP1_ConnectButton.TabIndex = 730;
            this.SP1_ConnectButton.Text = "Connect";
            this.SP1_ConnectButton.UseVisualStyleBackColor = false;
            this.SP1_ConnectButton.Click += new System.EventHandler(this.SP1_ConnectButton_Click);
            // 
            // SP1_textBox_PortName
            // 
            this.SP1_textBox_PortName.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_textBox_PortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_textBox_PortName.Location = new System.Drawing.Point(142, 86);
            this.SP1_textBox_PortName.Multiline = true;
            this.SP1_textBox_PortName.Name = "SP1_textBox_PortName";
            this.SP1_textBox_PortName.Size = new System.Drawing.Size(108, 85);
            this.SP1_textBox_PortName.TabIndex = 735;
            this.SP1_textBox_PortName.Text = "COM23 \r\n57600 bps\r\nVID.AD4E \r\nPID.EEDE";
            this.SP1_textBox_PortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(81, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 24);
            this.label1.TabIndex = 733;
            this.label1.Text = "Interface Connection";
            this.label1.Visible = false;
            // 
            // SP1_SendButton
            // 
            this.SP1_SendButton.BackColor = System.Drawing.Color.Transparent;
            this.SP1_SendButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SP1_SendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.SP1_SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SP1_SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_SendButton.ForeColor = System.Drawing.Color.Black;
            this.SP1_SendButton.Location = new System.Drawing.Point(258, 134);
            this.SP1_SendButton.Name = "SP1_SendButton";
            this.SP1_SendButton.Size = new System.Drawing.Size(80, 40);
            this.SP1_SendButton.TabIndex = 734;
            this.SP1_SendButton.Text = "Send";
            this.SP1_SendButton.UseVisualStyleBackColor = false;
            this.SP1_SendButton.Click += new System.EventHandler(this.SP1_SendButton_Click);
            // 
            // SP1_DatatextBox
            // 
            this.SP1_DatatextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_DatatextBox.Location = new System.Drawing.Point(13, 251);
            this.SP1_DatatextBox.Multiline = true;
            this.SP1_DatatextBox.Name = "SP1_DatatextBox";
            this.SP1_DatatextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SP1_DatatextBox.Size = new System.Drawing.Size(329, 166);
            this.SP1_DatatextBox.TabIndex = 738;
            this.SP1_DatatextBox.Text = "Receive Log";
            // 
            // SP1_richTextBox
            // 
            this.SP1_richTextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_richTextBox.Location = new System.Drawing.Point(11, 423);
            this.SP1_richTextBox.Name = "SP1_richTextBox";
            this.SP1_richTextBox.Size = new System.Drawing.Size(329, 491);
            this.SP1_richTextBox.TabIndex = 737;
            this.SP1_richTextBox.Text = "Receive Log";
            // 
            // checkBox_Temperature
            // 
            this.checkBox_Temperature.AutoSize = true;
            this.checkBox_Temperature.Checked = true;
            this.checkBox_Temperature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Temperature.ForeColor = System.Drawing.Color.DarkOrange;
            this.checkBox_Temperature.Location = new System.Drawing.Point(390, 735);
            this.checkBox_Temperature.Name = "checkBox_Temperature";
            this.checkBox_Temperature.Size = new System.Drawing.Size(112, 21);
            this.checkBox_Temperature.TabIndex = 750;
            this.checkBox_Temperature.Text = "Temperature";
            this.checkBox_Temperature.UseVisualStyleBackColor = true;
            this.checkBox_Temperature.CheckedChanged += new System.EventHandler(this.checkBox_Temperature_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.communicationToolStripMenuItem,
            this.dataLoggerToolStripMenuItem,
            this.chartToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1539, 30);
            this.menuStrip1.TabIndex = 753;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.deviceManagerToolStripMenuItem,
            this.comPortListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.recordToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // deviceManagerToolStripMenuItem
            // 
            this.deviceManagerToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            this.deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.deviceManagerToolStripMenuItem.Text = "Device Manager";
            this.deviceManagerToolStripMenuItem.Click += new System.EventHandler(this.deviceManagerToolStripMenuItem_Click);
            // 
            // comPortListToolStripMenuItem
            // 
            this.comPortListToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.comPortListToolStripMenuItem.Name = "comPortListToolStripMenuItem";
            this.comPortListToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.comPortListToolStripMenuItem.Text = "Com Port List";
            this.comPortListToolStripMenuItem.Click += new System.EventHandler(this.comPortListToolStripMenuItem_Click);
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.communicationToolStripMenuItem.Text = "Simulator";
            this.communicationToolStripMenuItem.Click += new System.EventHandler(this.communicationToolStripMenuItem_Click);
            // 
            // dataLoggerToolStripMenuItem
            // 
            this.dataLoggerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.openLogFileToolStripMenuItem,
            this.systemTimeToolStripMenuItem});
            this.dataLoggerToolStripMenuItem.Name = "dataLoggerToolStripMenuItem";
            this.dataLoggerToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.dataLoggerToolStripMenuItem.Text = "Data Logger";
            this.dataLoggerToolStripMenuItem.Click += new System.EventHandler(this.dataLoggerToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // openLogFileToolStripMenuItem
            // 
            this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.openLogFileToolStripMenuItem.Text = "Open Log File";
            // 
            // systemTimeToolStripMenuItem
            // 
            this.systemTimeToolStripMenuItem.Name = "systemTimeToolStripMenuItem";
            this.systemTimeToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem});
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem2.Text = "10 Seconds";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem3.Text = "20 Seconds";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem4.Text = "1 Minute";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem5.Text = "2 Minutes";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem6.Text = "3 Minutes";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // plotSurface2D1
            // 
            this.plotSurface2D1.AutoScaleAutoGeneratedAxes = false;
            this.plotSurface2D1.AutoScaleTitle = false;
            this.plotSurface2D1.BackColor = System.Drawing.Color.AliceBlue;
            this.plotSurface2D1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.plotSurface2D1.DateTimeToolTip = false;
            this.plotSurface2D1.Legend = null;
            this.plotSurface2D1.LegendZOrder = -1;
            this.plotSurface2D1.Location = new System.Drawing.Point(344, 44);
            this.plotSurface2D1.Name = "plotSurface2D1";
            this.plotSurface2D1.RightMenu = null;
            this.plotSurface2D1.ShowCoordinates = true;
            this.plotSurface2D1.Size = new System.Drawing.Size(1400, 579);
            this.plotSurface2D1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.plotSurface2D1.TabIndex = 739;
            this.plotSurface2D1.Text = "plotSurface2D1";
            this.plotSurface2D1.Title = "";
            this.plotSurface2D1.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.plotSurface2D1.XAxis1 = null;
            this.plotSurface2D1.XAxis2 = null;
            this.plotSurface2D1.YAxis1 = null;
            this.plotSurface2D1.YAxis2 = null;
            // 
            // checkBox_Humidity
            // 
            this.checkBox_Humidity.AutoSize = true;
            this.checkBox_Humidity.Checked = true;
            this.checkBox_Humidity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Humidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Humidity.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.checkBox_Humidity.Location = new System.Drawing.Point(390, 766);
            this.checkBox_Humidity.Name = "checkBox_Humidity";
            this.checkBox_Humidity.Size = new System.Drawing.Size(84, 21);
            this.checkBox_Humidity.TabIndex = 757;
            this.checkBox_Humidity.Text = "Humidity";
            this.checkBox_Humidity.UseVisualStyleBackColor = true;
            // 
            // SP1_textBox_Device
            // 
            this.SP1_textBox_Device.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_textBox_Device.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SP1_textBox_Device.Location = new System.Drawing.Point(12, 53);
            this.SP1_textBox_Device.Multiline = true;
            this.SP1_textBox_Device.Name = "SP1_textBox_Device";
            this.SP1_textBox_Device.Size = new System.Drawing.Size(326, 27);
            this.SP1_textBox_Device.TabIndex = 763;
            // 
            // checkBox_Light
            // 
            this.checkBox_Light.AutoSize = true;
            this.checkBox_Light.Checked = true;
            this.checkBox_Light.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Light.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Light.ForeColor = System.Drawing.Color.BlueViolet;
            this.checkBox_Light.Location = new System.Drawing.Point(524, 735);
            this.checkBox_Light.Name = "checkBox_Light";
            this.checkBox_Light.Size = new System.Drawing.Size(106, 21);
            this.checkBox_Light.TabIndex = 767;
            this.checkBox_Light.Text = "Visible Light";
            this.checkBox_Light.UseVisualStyleBackColor = true;
            // 
            // checkBox_InfraLight
            // 
            this.checkBox_InfraLight.AutoSize = true;
            this.checkBox_InfraLight.Checked = true;
            this.checkBox_InfraLight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_InfraLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_InfraLight.ForeColor = System.Drawing.Color.IndianRed;
            this.checkBox_InfraLight.Location = new System.Drawing.Point(524, 762);
            this.checkBox_InfraLight.Name = "checkBox_InfraLight";
            this.checkBox_InfraLight.Size = new System.Drawing.Size(114, 21);
            this.checkBox_InfraLight.TabIndex = 769;
            this.checkBox_InfraLight.Text = "Infrared Light";
            this.checkBox_InfraLight.UseVisualStyleBackColor = true;
            // 
            // checkBox_FanSpeed
            // 
            this.checkBox_FanSpeed.AutoSize = true;
            this.checkBox_FanSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_FanSpeed.ForeColor = System.Drawing.Color.Maroon;
            this.checkBox_FanSpeed.Location = new System.Drawing.Point(1352, 762);
            this.checkBox_FanSpeed.Name = "checkBox_FanSpeed";
            this.checkBox_FanSpeed.Size = new System.Drawing.Size(99, 21);
            this.checkBox_FanSpeed.TabIndex = 771;
            this.checkBox_FanSpeed.Text = "Fan Speed";
            this.checkBox_FanSpeed.UseVisualStyleBackColor = true;
            this.checkBox_FanSpeed.Visible = false;
            this.checkBox_FanSpeed.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox_AccX
            // 
            this.checkBox_AccX.AutoSize = true;
            this.checkBox_AccX.Checked = true;
            this.checkBox_AccX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AccX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_AccX.ForeColor = System.Drawing.Color.DimGray;
            this.checkBox_AccX.Location = new System.Drawing.Point(661, 735);
            this.checkBox_AccX.Name = "checkBox_AccX";
            this.checkBox_AccX.Size = new System.Drawing.Size(121, 21);
            this.checkBox_AccX.TabIndex = 772;
            this.checkBox_AccX.Text = "Acceleration X";
            this.checkBox_AccX.UseVisualStyleBackColor = true;
            // 
            // checkBox_AccY
            // 
            this.checkBox_AccY.AutoSize = true;
            this.checkBox_AccY.Checked = true;
            this.checkBox_AccY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AccY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_AccY.ForeColor = System.Drawing.Color.DimGray;
            this.checkBox_AccY.Location = new System.Drawing.Point(811, 735);
            this.checkBox_AccY.Name = "checkBox_AccY";
            this.checkBox_AccY.Size = new System.Drawing.Size(121, 21);
            this.checkBox_AccY.TabIndex = 773;
            this.checkBox_AccY.Text = "Acceleration Y";
            this.checkBox_AccY.UseVisualStyleBackColor = true;
            // 
            // checkBox_AccZ
            // 
            this.checkBox_AccZ.AutoSize = true;
            this.checkBox_AccZ.Checked = true;
            this.checkBox_AccZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AccZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_AccZ.ForeColor = System.Drawing.Color.DimGray;
            this.checkBox_AccZ.Location = new System.Drawing.Point(958, 735);
            this.checkBox_AccZ.Name = "checkBox_AccZ";
            this.checkBox_AccZ.Size = new System.Drawing.Size(121, 21);
            this.checkBox_AccZ.TabIndex = 774;
            this.checkBox_AccZ.Text = "Acceleration Z";
            this.checkBox_AccZ.UseVisualStyleBackColor = true;
            // 
            // checkBox_GyrZ
            // 
            this.checkBox_GyrZ.AutoSize = true;
            this.checkBox_GyrZ.Checked = true;
            this.checkBox_GyrZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_GyrZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_GyrZ.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.checkBox_GyrZ.Location = new System.Drawing.Point(958, 766);
            this.checkBox_GyrZ.Name = "checkBox_GyrZ";
            this.checkBox_GyrZ.Size = new System.Drawing.Size(74, 21);
            this.checkBox_GyrZ.TabIndex = 777;
            this.checkBox_GyrZ.Text = "Gyro Z";
            this.checkBox_GyrZ.UseVisualStyleBackColor = true;
            // 
            // checkBox_GyrY
            // 
            this.checkBox_GyrY.AutoSize = true;
            this.checkBox_GyrY.Checked = true;
            this.checkBox_GyrY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_GyrY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_GyrY.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.checkBox_GyrY.Location = new System.Drawing.Point(811, 766);
            this.checkBox_GyrY.Name = "checkBox_GyrY";
            this.checkBox_GyrY.Size = new System.Drawing.Size(74, 21);
            this.checkBox_GyrY.TabIndex = 776;
            this.checkBox_GyrY.Text = "Gyro Y";
            this.checkBox_GyrY.UseVisualStyleBackColor = true;
            // 
            // checkBox_GyrX
            // 
            this.checkBox_GyrX.AutoSize = true;
            this.checkBox_GyrX.Checked = true;
            this.checkBox_GyrX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_GyrX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_GyrX.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.checkBox_GyrX.Location = new System.Drawing.Point(661, 766);
            this.checkBox_GyrX.Name = "checkBox_GyrX";
            this.checkBox_GyrX.Size = new System.Drawing.Size(74, 21);
            this.checkBox_GyrX.TabIndex = 775;
            this.checkBox_GyrX.Text = "Gyro X";
            this.checkBox_GyrX.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1539, 783);
            this.Controls.Add(this.checkBox_GyrZ);
            this.Controls.Add(this.checkBox_GyrY);
            this.Controls.Add(this.checkBox_GyrX);
            this.Controls.Add(this.checkBox_AccZ);
            this.Controls.Add(this.checkBox_AccY);
            this.Controls.Add(this.checkBox_AccX);
            this.Controls.Add(this.checkBox_FanSpeed);
            this.Controls.Add(this.checkBox_InfraLight);
            this.Controls.Add(this.checkBox_Light);
            this.Controls.Add(this.SP1_textBox_Device);
            this.Controls.Add(this.checkBox_Humidity);
            this.Controls.Add(this.checkBox_Temperature);
            this.Controls.Add(this.SP1_DatatextBox);
            this.Controls.Add(this.SP1_richTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SP1_SendtextBox);
            this.Controls.Add(this.SP1_DisConnectButton);
            this.Controls.Add(this.SP1_IO_Serial_lstCOMPorts);
            this.Controls.Add(this.SP1_ConnectButton);
            this.Controls.Add(this.SP1_textBox_PortName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SP1_SendButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.plotSurface2D1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SensorDataLogger";
            this.TransparencyKey = System.Drawing.Color.Goldenrod;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort SP1_serialPort;
        private System.Windows.Forms.Timer Base_Timer1mSec;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox SP1_SendtextBox;
        private System.Windows.Forms.Button SP1_DisConnectButton;
        public System.Windows.Forms.ComboBox SP1_IO_Serial_lstCOMPorts;
        private System.Windows.Forms.Button SP1_ConnectButton;
        public System.Windows.Forms.TextBox SP1_textBox_PortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SP1_SendButton;
        public System.Windows.Forms.TextBox SP1_DatatextBox;
        private System.Windows.Forms.RichTextBox SP1_richTextBox;
        private NPlot.Windows.PlotSurface2D plotSurface2D1;
        private System.Windows.Forms.CheckBox checkBox_Temperature;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataLoggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemTimeToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox_Humidity;
        private System.Windows.Forms.TextBox SP1_textBox_Device;
        private System.Windows.Forms.ToolStripMenuItem deviceManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comPortListToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_Light;
        private System.Windows.Forms.CheckBox checkBox_InfraLight;
        private System.Windows.Forms.CheckBox checkBox_FanSpeed;
        private System.Windows.Forms.CheckBox checkBox_AccX;
        private System.Windows.Forms.CheckBox checkBox_AccY;
        private System.Windows.Forms.CheckBox checkBox_AccZ;
        private System.Windows.Forms.CheckBox checkBox_GyrZ;
        private System.Windows.Forms.CheckBox checkBox_GyrY;
        private System.Windows.Forms.CheckBox checkBox_GyrX;
    }
}

