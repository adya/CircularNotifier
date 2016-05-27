namespace CircularNotifierControl
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
            this.bAddEvent = new System.Windows.Forms.Button();
            this.nudRings = new System.Windows.Forms.NumericUpDown();
            this.nudSectors = new System.Windows.Forms.NumericUpDown();
            this.nudLineThickness = new System.Windows.Forms.NumericUpDown();
            this.nudLineThickFactor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbNotifierProperties = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudRotation = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudPeriod = new System.Windows.Forms.NumericUpDown();
            this.gbDrawingProperties = new System.Windows.Forms.GroupBox();
            this.nudRingThickness = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.cbOuterOnly = new System.Windows.Forms.CheckBox();
            this.bAdd10 = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bAddRingsEvents = new System.Windows.Forms.Button();
            this.gbPeriod = new System.Windows.Forms.GroupBox();
            this.cbAutoStop = new System.Windows.Forms.CheckBox();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.bTimer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAutoRingWidth = new System.Windows.Forms.CheckBox();
            this.nudRingsWidth = new System.Windows.Forms.NumericUpDown();
            this.nudMinInner = new System.Windows.Forms.NumericUpDown();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbThickLines = new System.Windows.Forms.GroupBox();
            this.clbThickLines = new System.Windows.Forms.CheckedListBox();
            this.cn = new CircularNotifierControl.CircularNotifier();
            ((System.ComponentModel.ISupportInitialize)(this.nudRings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineThickFactor)).BeginInit();
            this.gbNotifierProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).BeginInit();
            this.gbDrawingProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRingThickness)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbAdd.SuspendLayout();
            this.gbPeriod.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRingsWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinInner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            this.gbThickLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAddEvent
            // 
            this.bAddEvent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddEvent.Location = new System.Drawing.Point(10, 19);
            this.bAddEvent.Name = "bAddEvent";
            this.bAddEvent.Size = new System.Drawing.Size(71, 35);
            this.bAddEvent.TabIndex = 0;
            this.bAddEvent.Text = "Add Event";
            this.bAddEvent.UseVisualStyleBackColor = false;
            this.bAddEvent.Click += new System.EventHandler(this.bAddEvent_Click);
            // 
            // nudRings
            // 
            this.nudRings.Location = new System.Drawing.Point(131, 28);
            this.nudRings.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudRings.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRings.Name = "nudRings";
            this.nudRings.Size = new System.Drawing.Size(60, 20);
            this.nudRings.TabIndex = 3;
            this.nudRings.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRings.ValueChanged += new System.EventHandler(this.nudRings_ValueChanged);
            // 
            // nudSectors
            // 
            this.nudSectors.Location = new System.Drawing.Point(131, 56);
            this.nudSectors.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudSectors.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSectors.Name = "nudSectors";
            this.nudSectors.Size = new System.Drawing.Size(60, 20);
            this.nudSectors.TabIndex = 4;
            this.nudSectors.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSectors.ValueChanged += new System.EventHandler(this.nudSectors_ValueChanged);
            // 
            // nudLineThickness
            // 
            this.nudLineThickness.DecimalPlaces = 2;
            this.nudLineThickness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLineThickness.Location = new System.Drawing.Point(131, 29);
            this.nudLineThickness.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudLineThickness.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudLineThickness.Name = "nudLineThickness";
            this.nudLineThickness.Size = new System.Drawing.Size(60, 20);
            this.nudLineThickness.TabIndex = 5;
            this.nudLineThickness.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudLineThickness.ValueChanged += new System.EventHandler(this.nudLineThickness_ValueChanged);
            // 
            // nudLineThickFactor
            // 
            this.nudLineThickFactor.DecimalPlaces = 2;
            this.nudLineThickFactor.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudLineThickFactor.Location = new System.Drawing.Point(131, 61);
            this.nudLineThickFactor.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudLineThickFactor.Minimum = new decimal(new int[] {
            105,
            0,
            0,
            131072});
            this.nudLineThickFactor.Name = "nudLineThickFactor";
            this.nudLineThickFactor.Size = new System.Drawing.Size(60, 20);
            this.nudLineThickFactor.TabIndex = 6;
            this.nudLineThickFactor.Value = new decimal(new int[] {
            105,
            0,
            0,
            131072});
            this.nudLineThickFactor.ValueChanged += new System.EventHandler(this.nudLineThickFactor_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rings:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sectors:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Line Thickness:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Line Thick Factor:";
            // 
            // gbNotifierProperties
            // 
            this.gbNotifierProperties.Controls.Add(this.label6);
            this.gbNotifierProperties.Controls.Add(this.nudRotation);
            this.gbNotifierProperties.Controls.Add(this.label1);
            this.gbNotifierProperties.Controls.Add(this.nudRings);
            this.gbNotifierProperties.Controls.Add(this.label2);
            this.gbNotifierProperties.Controls.Add(this.nudSectors);
            this.gbNotifierProperties.Location = new System.Drawing.Point(14, 115);
            this.gbNotifierProperties.Name = "gbNotifierProperties";
            this.gbNotifierProperties.Size = new System.Drawing.Size(210, 116);
            this.gbNotifierProperties.TabIndex = 11;
            this.gbNotifierProperties.TabStop = false;
            this.gbNotifierProperties.Text = "Notifier Properties";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Rotation:";
            // 
            // nudRotation
            // 
            this.nudRotation.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudRotation.Location = new System.Drawing.Point(131, 84);
            this.nudRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudRotation.Name = "nudRotation";
            this.nudRotation.Size = new System.Drawing.Size(60, 20);
            this.nudRotation.TabIndex = 9;
            this.nudRotation.ValueChanged += new System.EventHandler(this.nudRotation_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Period:";
            // 
            // nudPeriod
            // 
            this.nudPeriod.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPeriod.Location = new System.Drawing.Point(131, 14);
            this.nudPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPeriod.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPeriod.Name = "nudPeriod";
            this.nudPeriod.Size = new System.Drawing.Size(60, 20);
            this.nudPeriod.TabIndex = 11;
            this.nudPeriod.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPeriod.ValueChanged += new System.EventHandler(this.nudPeriod_ValueChanged);
            // 
            // gbDrawingProperties
            // 
            this.gbDrawingProperties.Controls.Add(this.nudRingThickness);
            this.gbDrawingProperties.Controls.Add(this.label5);
            this.gbDrawingProperties.Controls.Add(this.nudLineThickness);
            this.gbDrawingProperties.Controls.Add(this.nudLineThickFactor);
            this.gbDrawingProperties.Controls.Add(this.label4);
            this.gbDrawingProperties.Controls.Add(this.label3);
            this.gbDrawingProperties.Location = new System.Drawing.Point(14, 376);
            this.gbDrawingProperties.Name = "gbDrawingProperties";
            this.gbDrawingProperties.Size = new System.Drawing.Size(210, 127);
            this.gbDrawingProperties.TabIndex = 12;
            this.gbDrawingProperties.TabStop = false;
            this.gbDrawingProperties.Text = "Drawing Properties";
            // 
            // nudRingThickness
            // 
            this.nudRingThickness.DecimalPlaces = 2;
            this.nudRingThickness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRingThickness.Location = new System.Drawing.Point(131, 96);
            this.nudRingThickness.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudRingThickness.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudRingThickness.Name = "nudRingThickness";
            this.nudRingThickness.Size = new System.Drawing.Size(60, 20);
            this.nudRingThickness.TabIndex = 11;
            this.nudRingThickness.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudRingThickness.ValueChanged += new System.EventHandler(this.nudRingThickness_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Rings Thickness:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbAdd);
            this.panel1.Controls.Add(this.gbPeriod);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gbThickLines);
            this.panel1.Controls.Add(this.gbDrawingProperties);
            this.panel1.Controls.Add(this.gbNotifierProperties);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(856, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 835);
            this.panel1.TabIndex = 13;
            // 
            // gbAdd
            // 
            this.gbAdd.Controls.Add(this.cbOuterOnly);
            this.gbAdd.Controls.Add(this.bAddEvent);
            this.gbAdd.Controls.Add(this.bAdd10);
            this.gbAdd.Controls.Add(this.bClear);
            this.gbAdd.Controls.Add(this.bAddRingsEvents);
            this.gbAdd.Location = new System.Drawing.Point(15, 12);
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.Size = new System.Drawing.Size(209, 100);
            this.gbAdd.TabIndex = 20;
            this.gbAdd.TabStop = false;
            this.gbAdd.Text = "Adding events";
            // 
            // cbOuterOnly
            // 
            this.cbOuterOnly.Checked = true;
            this.cbOuterOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOuterOnly.Location = new System.Drawing.Point(10, 60);
            this.cbOuterOnly.Name = "cbOuterOnly";
            this.cbOuterOnly.Size = new System.Drawing.Size(89, 34);
            this.cbOuterOnly.TabIndex = 19;
            this.cbOuterOnly.Text = "Add only to outer ring";
            this.cbOuterOnly.UseVisualStyleBackColor = true;
            // 
            // bAdd10
            // 
            this.bAdd10.BackColor = System.Drawing.SystemColors.Highlight;
            this.bAdd10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdd10.Location = new System.Drawing.Point(90, 19);
            this.bAdd10.Name = "bAdd10";
            this.bAdd10.Size = new System.Drawing.Size(42, 35);
            this.bAdd10.TabIndex = 16;
            this.bAdd10.Text = "x10";
            this.bAdd10.UseVisualStyleBackColor = false;
            this.bAdd10.Click += new System.EventHandler(this.bAdd10_Click);
            // 
            // bClear
            // 
            this.bClear.BackColor = System.Drawing.Color.IndianRed;
            this.bClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClear.Location = new System.Drawing.Point(107, 58);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(93, 36);
            this.bClear.TabIndex = 18;
            this.bClear.Text = "Remove Events";
            this.bClear.UseVisualStyleBackColor = false;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bAddRingsEvents
            // 
            this.bAddRingsEvents.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bAddRingsEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddRingsEvents.Location = new System.Drawing.Point(138, 19);
            this.bAddRingsEvents.Name = "bAddRingsEvents";
            this.bAddRingsEvents.Size = new System.Drawing.Size(62, 35);
            this.bAddRingsEvents.TabIndex = 17;
            this.bAddRingsEvents.Text = "x Sectors";
            this.bAddRingsEvents.UseVisualStyleBackColor = false;
            this.bAddRingsEvents.Click += new System.EventHandler(this.bAddSectorsEvents_Click);
            // 
            // gbPeriod
            // 
            this.gbPeriod.Controls.Add(this.cbAutoStop);
            this.gbPeriod.Controls.Add(this.cbAutoStart);
            this.gbPeriod.Controls.Add(this.bTimer);
            this.gbPeriod.Controls.Add(this.nudPeriod);
            this.gbPeriod.Controls.Add(this.label10);
            this.gbPeriod.Location = new System.Drawing.Point(14, 237);
            this.gbPeriod.Name = "gbPeriod";
            this.gbPeriod.Size = new System.Drawing.Size(210, 122);
            this.gbPeriod.TabIndex = 19;
            this.gbPeriod.TabStop = false;
            this.gbPeriod.Text = "Tick Properties";
            // 
            // cbAutoStop
            // 
            this.cbAutoStop.Location = new System.Drawing.Point(108, 40);
            this.cbAutoStop.Name = "cbAutoStop";
            this.cbAutoStop.Size = new System.Drawing.Size(83, 32);
            this.cbAutoStop.TabIndex = 14;
            this.cbAutoStop.Text = "Auto stop";
            this.cbAutoStop.UseVisualStyleBackColor = true;
            this.cbAutoStop.CheckedChanged += new System.EventHandler(this.cbAutoStop_CheckedChanged);
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.Location = new System.Drawing.Point(14, 40);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(79, 32);
            this.cbAutoStart.TabIndex = 14;
            this.cbAutoStart.Text = "Auto start";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            this.cbAutoStart.CheckedChanged += new System.EventHandler(this.cbAutoStart_CheckedChanged);
            // 
            // bTimer
            // 
            this.bTimer.BackColor = System.Drawing.Color.LimeGreen;
            this.bTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTimer.Location = new System.Drawing.Point(14, 78);
            this.bTimer.Name = "bTimer";
            this.bTimer.Size = new System.Drawing.Size(177, 34);
            this.bTimer.TabIndex = 13;
            this.bTimer.Text = "Start";
            this.bTimer.UseVisualStyleBackColor = false;
            this.bTimer.Click += new System.EventHandler(this.bTimer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAutoRingWidth);
            this.groupBox1.Controls.Add(this.nudRingsWidth);
            this.groupBox1.Controls.Add(this.nudMinInner);
            this.groupBox1.Controls.Add(this.nudOffset);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(14, 518);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 144);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement Properties";
            // 
            // cbAutoRingWidth
            // 
            this.cbAutoRingWidth.AutoSize = true;
            this.cbAutoRingWidth.Location = new System.Drawing.Point(72, 117);
            this.cbAutoRingWidth.Name = "cbAutoRingWidth";
            this.cbAutoRingWidth.Size = new System.Drawing.Size(119, 17);
            this.cbAutoRingWidth.TabIndex = 7;
            this.cbAutoRingWidth.Text = "Autosize Rings to fit";
            this.cbAutoRingWidth.UseVisualStyleBackColor = true;
            this.cbAutoRingWidth.CheckedChanged += new System.EventHandler(this.cbAutoRingWidth_CheckedChanged);
            // 
            // nudRingsWidth
            // 
            this.nudRingsWidth.Location = new System.Drawing.Point(131, 91);
            this.nudRingsWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRingsWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRingsWidth.Name = "nudRingsWidth";
            this.nudRingsWidth.Size = new System.Drawing.Size(60, 20);
            this.nudRingsWidth.TabIndex = 6;
            this.nudRingsWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRingsWidth.ValueChanged += new System.EventHandler(this.nudRingsWidth_ValueChanged);
            // 
            // nudMinInner
            // 
            this.nudMinInner.Location = new System.Drawing.Point(131, 53);
            this.nudMinInner.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMinInner.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMinInner.Name = "nudMinInner";
            this.nudMinInner.Size = new System.Drawing.Size(60, 20);
            this.nudMinInner.TabIndex = 5;
            this.nudMinInner.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMinInner.ValueChanged += new System.EventHandler(this.nudMinInner_ValueChanged);
            // 
            // nudOffset
            // 
            this.nudOffset.Location = new System.Drawing.Point(131, 18);
            this.nudOffset.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(60, 20);
            this.nudOffset.TabIndex = 4;
            this.nudOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOffset.ValueChanged += new System.EventHandler(this.nudOffset_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Rings Width:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Min Inner Width:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Offset:";
            // 
            // gbThickLines
            // 
            this.gbThickLines.Controls.Add(this.clbThickLines);
            this.gbThickLines.Location = new System.Drawing.Point(14, 679);
            this.gbThickLines.Name = "gbThickLines";
            this.gbThickLines.Size = new System.Drawing.Size(210, 144);
            this.gbThickLines.TabIndex = 14;
            this.gbThickLines.TabStop = false;
            this.gbThickLines.Text = "Thick Lines";
            // 
            // clbThickLines
            // 
            this.clbThickLines.CheckOnClick = true;
            this.clbThickLines.FormattingEnabled = true;
            this.clbThickLines.Location = new System.Drawing.Point(14, 19);
            this.clbThickLines.Name = "clbThickLines";
            this.clbThickLines.Size = new System.Drawing.Size(187, 109);
            this.clbThickLines.TabIndex = 13;
            this.clbThickLines.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbThickLines_ItemCheck);
            // 
            // cn
            // 
            this.cn.AutoStart = true;
            this.cn.AutoStop = true;
            this.cn.BackColor = System.Drawing.Color.Transparent;
            this.cn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cn.LinesColor = System.Drawing.Color.Black;
            this.cn.LinesThickColor = System.Drawing.Color.Black;
            this.cn.LinesThickFactor = 1.75F;
            this.cn.LinesThickness = 1F;
            this.cn.Location = new System.Drawing.Point(12, 12);
            this.cn.MinimumSize = new System.Drawing.Size(200, 200);
            this.cn.Name = "cn";
            this.cn.Offset = 10;
            this.cn.Period = 500;
            this.cn.RingsColor = System.Drawing.Color.Black;
            this.cn.RingsCount = 8;
            this.cn.RingsMinInnerDiameter = 100;
            this.cn.RingsThickness = 1F;
            this.cn.RingsWidth = 43;
            this.cn.RingsWidthAuto = true;
            this.cn.Rotation = 0;
            this.cn.Sectors = 12;
            this.cn.Size = new System.Drawing.Size(811, 811);
            this.cn.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1083, 835);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(500, 870);
            this.Name = "Form1";
            this.Text = "Circular Notifier Demo";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudRings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineThickFactor)).EndInit();
            this.gbNotifierProperties.ResumeLayout(false);
            this.gbNotifierProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).EndInit();
            this.gbDrawingProperties.ResumeLayout(false);
            this.gbDrawingProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRingThickness)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbAdd.ResumeLayout(false);
            this.gbPeriod.ResumeLayout(false);
            this.gbPeriod.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRingsWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinInner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            this.gbThickLines.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAddEvent;
        private CircularNotifier cn;
        private System.Windows.Forms.NumericUpDown nudRings;
        private System.Windows.Forms.NumericUpDown nudSectors;
        private System.Windows.Forms.NumericUpDown nudLineThickness;
        private System.Windows.Forms.NumericUpDown nudLineThickFactor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbNotifierProperties;
        private System.Windows.Forms.GroupBox gbDrawingProperties;
        private System.Windows.Forms.NumericUpDown nudRingThickness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudRotation;
        private System.Windows.Forms.GroupBox gbThickLines;
        private System.Windows.Forms.CheckedListBox clbThickLines;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudRingsWidth;
        private System.Windows.Forms.NumericUpDown nudMinInner;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbAutoRingWidth;
        private System.Windows.Forms.Button bAddRingsEvents;
        private System.Windows.Forms.Button bAdd10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudPeriod;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.GroupBox gbPeriod;
        private System.Windows.Forms.Button bTimer;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.CheckBox cbOuterOnly;
        private System.Windows.Forms.CheckBox cbAutoStop;



    }
}

