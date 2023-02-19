
namespace StarCitizen_ShowLocation
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
            this.txtCoordX = new System.Windows.Forms.TextBox();
            this.txtCoordY = new System.Windows.Forms.TextBox();
            this.txtCoordZ = new System.Windows.Forms.TextBox();
            this.txtFromClipboard = new System.Windows.Forms.TextBox();
            this.txtCoordZLast = new System.Windows.Forms.TextBox();
            this.txtCoordYLast = new System.Windows.Forms.TextBox();
            this.txtCoordXLast = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeltaZ = new System.Windows.Forms.TextBox();
            this.txtDeltaY = new System.Windows.Forms.TextBox();
            this.txtDeltaX = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCoordXTarget = new System.Windows.Forms.TextBox();
            this.txtCoordYTarget = new System.Windows.Forms.TextBox();
            this.txtCoordZTarget = new System.Windows.Forms.TextBox();
            this.btnTargetSet = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDistanceToTarget = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRateOfChange = new System.Windows.Forms.Label();
            this.btnMakeTarget = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblBearingToTarget = new System.Windows.Forms.Label();
            this.lblElevationToTarget = new System.Windows.Forms.Label();
            this.lblCurrentBearing = new System.Windows.Forms.Label();
            this.lblCurrentElevation = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtElevOffX = new System.Windows.Forms.TextBox();
            this.txtElevOffY = new System.Windows.Forms.TextBox();
            this.dispXY = new System.Windows.Forms.PictureBox();
            this.displayZoomIn = new System.Windows.Forms.Button();
            this.displayZoomOut = new System.Windows.Forms.Button();
            this.lblDisplayZoomLevel = new System.Windows.Forms.Label();
            this.dispXZ = new System.Windows.Forms.PictureBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCurrentZ = new System.Windows.Forms.Label();
            this.lblTargetZ = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispXZ)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCoordX
            // 
            this.txtCoordX.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordX.Location = new System.Drawing.Point(116, 1258);
            this.txtCoordX.Name = "txtCoordX";
            this.txtCoordX.Size = new System.Drawing.Size(375, 31);
            this.txtCoordX.TabIndex = 0;
            // 
            // txtCoordY
            // 
            this.txtCoordY.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordY.Location = new System.Drawing.Point(117, 1295);
            this.txtCoordY.Name = "txtCoordY";
            this.txtCoordY.Size = new System.Drawing.Size(374, 31);
            this.txtCoordY.TabIndex = 1;
            // 
            // txtCoordZ
            // 
            this.txtCoordZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordZ.Location = new System.Drawing.Point(117, 1332);
            this.txtCoordZ.Name = "txtCoordZ";
            this.txtCoordZ.Size = new System.Drawing.Size(374, 31);
            this.txtCoordZ.TabIndex = 2;
            // 
            // txtFromClipboard
            // 
            this.txtFromClipboard.BackColor = System.Drawing.Color.Gray;
            this.txtFromClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromClipboard.Location = new System.Drawing.Point(165, 1);
            this.txtFromClipboard.Name = "txtFromClipboard";
            this.txtFromClipboard.Size = new System.Drawing.Size(990, 31);
            this.txtFromClipboard.TabIndex = 3;
            // 
            // txtCoordZLast
            // 
            this.txtCoordZLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordZLast.Location = new System.Drawing.Point(1033, 1248);
            this.txtCoordZLast.Name = "txtCoordZLast";
            this.txtCoordZLast.Size = new System.Drawing.Size(105, 38);
            this.txtCoordZLast.TabIndex = 7;
            this.txtCoordZLast.Visible = false;
            // 
            // txtCoordYLast
            // 
            this.txtCoordYLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordYLast.Location = new System.Drawing.Point(1033, 1211);
            this.txtCoordYLast.Name = "txtCoordYLast";
            this.txtCoordYLast.Size = new System.Drawing.Size(105, 38);
            this.txtCoordYLast.TabIndex = 6;
            this.txtCoordYLast.Visible = false;
            // 
            // txtCoordXLast
            // 
            this.txtCoordXLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordXLast.Location = new System.Drawing.Point(1033, 1179);
            this.txtCoordXLast.Name = "txtCoordXLast";
            this.txtCoordXLast.Size = new System.Drawing.Size(105, 38);
            this.txtCoordXLast.TabIndex = 5;
            this.txtCoordXLast.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 1261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 1298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 37);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 1332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 37);
            this.label3.TabIndex = 10;
            this.label3.Text = "Z:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(110, 1218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 37);
            this.label5.TabIndex = 12;
            this.label5.Text = "New Coords";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Clipboard";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1156, 1143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 51);
            this.label7.TabIndex = 14;
            this.label7.Text = "Delta";
            // 
            // txtDeltaZ
            // 
            this.txtDeltaZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaZ.Location = new System.Drawing.Point(1300, 1258);
            this.txtDeltaZ.Name = "txtDeltaZ";
            this.txtDeltaZ.Size = new System.Drawing.Size(544, 56);
            this.txtDeltaZ.TabIndex = 17;
            // 
            // txtDeltaY
            // 
            this.txtDeltaY.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaY.Location = new System.Drawing.Point(1300, 1196);
            this.txtDeltaY.Name = "txtDeltaY";
            this.txtDeltaY.Size = new System.Drawing.Size(544, 56);
            this.txtDeltaY.TabIndex = 16;
            // 
            // txtDeltaX
            // 
            this.txtDeltaX.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaX.Location = new System.Drawing.Point(1300, 1134);
            this.txtDeltaX.Name = "txtDeltaX";
            this.txtDeltaX.Size = new System.Drawing.Size(544, 56);
            this.txtDeltaX.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StarCitizen_ShowLocation.Properties.Resources.panda;
            this.pictureBox1.Location = new System.Drawing.Point(-6, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // txtTarget
            // 
            this.txtTarget.BackColor = System.Drawing.Color.Gray;
            this.txtTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarget.Location = new System.Drawing.Point(165, 38);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(990, 31);
            this.txtTarget.TabIndex = 19;
            this.txtTarget.Text = "Coordinates: x:-19015740021.120113 y:-2634733670.744523 z:7019.973256";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(55, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Target";
            // 
            // txtCoordXTarget
            // 
            this.txtCoordXTarget.BackColor = System.Drawing.Color.Gray;
            this.txtCoordXTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordXTarget.Location = new System.Drawing.Point(168, 73);
            this.txtCoordXTarget.Name = "txtCoordXTarget";
            this.txtCoordXTarget.Size = new System.Drawing.Size(323, 31);
            this.txtCoordXTarget.TabIndex = 21;
            // 
            // txtCoordYTarget
            // 
            this.txtCoordYTarget.BackColor = System.Drawing.Color.Gray;
            this.txtCoordYTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordYTarget.Location = new System.Drawing.Point(497, 73);
            this.txtCoordYTarget.Name = "txtCoordYTarget";
            this.txtCoordYTarget.Size = new System.Drawing.Size(323, 31);
            this.txtCoordYTarget.TabIndex = 22;
            // 
            // txtCoordZTarget
            // 
            this.txtCoordZTarget.BackColor = System.Drawing.Color.Gray;
            this.txtCoordZTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordZTarget.Location = new System.Drawing.Point(826, 73);
            this.txtCoordZTarget.Name = "txtCoordZTarget";
            this.txtCoordZTarget.Size = new System.Drawing.Size(323, 31);
            this.txtCoordZTarget.TabIndex = 23;
            // 
            // btnTargetSet
            // 
            this.btnTargetSet.BackColor = System.Drawing.Color.Gray;
            this.btnTargetSet.Location = new System.Drawing.Point(1161, 38);
            this.btnTargetSet.Name = "btnTargetSet";
            this.btnTargetSet.Size = new System.Drawing.Size(171, 68);
            this.btnTargetSet.TabIndex = 24;
            this.btnTargetSet.Text = "Set";
            this.btnTargetSet.UseVisualStyleBackColor = false;
            this.btnTargetSet.Click += new System.EventHandler(this.btnTargetSet_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDistanceToTarget
            // 
            this.lblDistanceToTarget.AutoSize = true;
            this.lblDistanceToTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistanceToTarget.ForeColor = System.Drawing.Color.Lime;
            this.lblDistanceToTarget.Location = new System.Drawing.Point(216, 114);
            this.lblDistanceToTarget.Name = "lblDistanceToTarget";
            this.lblDistanceToTarget.Size = new System.Drawing.Size(51, 55);
            this.lblDistanceToTarget.TabIndex = 26;
            this.lblDistanceToTarget.Text = "0";
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(50, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 55);
            this.label9.TabIndex = 27;
            this.label9.Text = "Dist:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(571, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 55);
            this.label10.TabIndex = 28;
            this.label10.Text = "Rate:";
            // 
            // lblRateOfChange
            // 
            this.lblRateOfChange.AutoSize = true;
            this.lblRateOfChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateOfChange.ForeColor = System.Drawing.Color.Lime;
            this.lblRateOfChange.Location = new System.Drawing.Point(742, 114);
            this.lblRateOfChange.Name = "lblRateOfChange";
            this.lblRateOfChange.Size = new System.Drawing.Size(51, 55);
            this.lblRateOfChange.TabIndex = 29;
            this.lblRateOfChange.Text = "0";
            // 
            // btnMakeTarget
            // 
            this.btnMakeTarget.BackColor = System.Drawing.Color.Gray;
            this.btnMakeTarget.Location = new System.Drawing.Point(1161, 1);
            this.btnMakeTarget.Name = "btnMakeTarget";
            this.btnMakeTarget.Size = new System.Drawing.Size(171, 36);
            this.btnMakeTarget.TabIndex = 30;
            this.btnMakeTarget.Text = "Make Target";
            this.btnMakeTarget.UseVisualStyleBackColor = false;
            this.btnMakeTarget.Click += new System.EventHandler(this.btnMakeTarget_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(47, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 55);
            this.label11.TabIndex = 31;
            this.label11.Text = "Brg:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(74, 1128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 73);
            this.label12.TabIndex = 32;
            this.label12.Text = "Azm:";
            // 
            // lblBearingToTarget
            // 
            this.lblBearingToTarget.AutoSize = true;
            this.lblBearingToTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBearingToTarget.ForeColor = System.Drawing.Color.Lime;
            this.lblBearingToTarget.Location = new System.Drawing.Point(452, 193);
            this.lblBearingToTarget.Name = "lblBearingToTarget";
            this.lblBearingToTarget.Size = new System.Drawing.Size(51, 55);
            this.lblBearingToTarget.TabIndex = 33;
            this.lblBearingToTarget.Text = "0";
            // 
            // lblElevationToTarget
            // 
            this.lblElevationToTarget.AutoSize = true;
            this.lblElevationToTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElevationToTarget.Location = new System.Drawing.Point(549, 1116);
            this.lblElevationToTarget.Name = "lblElevationToTarget";
            this.lblElevationToTarget.Size = new System.Drawing.Size(68, 73);
            this.lblElevationToTarget.TabIndex = 34;
            this.lblElevationToTarget.Text = "0";
            // 
            // lblCurrentBearing
            // 
            this.lblCurrentBearing.AutoSize = true;
            this.lblCurrentBearing.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBearing.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentBearing.Location = new System.Drawing.Point(213, 191);
            this.lblCurrentBearing.Name = "lblCurrentBearing";
            this.lblCurrentBearing.Size = new System.Drawing.Size(51, 55);
            this.lblCurrentBearing.TabIndex = 35;
            this.lblCurrentBearing.Text = "0";
            // 
            // lblCurrentElevation
            // 
            this.lblCurrentElevation.AutoSize = true;
            this.lblCurrentElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentElevation.Location = new System.Drawing.Point(249, 1128);
            this.lblCurrentElevation.Name = "lblCurrentElevation";
            this.lblCurrentElevation.Size = new System.Drawing.Size(68, 73);
            this.lblCurrentElevation.TabIndex = 36;
            this.lblCurrentElevation.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Green;
            this.label15.Location = new System.Drawing.Point(198, 169);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 25);
            this.label15.TabIndex = 37;
            this.label15.Text = "Current";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Green;
            this.label16.Location = new System.Drawing.Point(446, 171);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 25);
            this.label16.TabIndex = 38;
            this.label16.Text = "Target";
            // 
            // txtElevOffX
            // 
            this.txtElevOffX.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElevOffX.Location = new System.Drawing.Point(795, 1164);
            this.txtElevOffX.Name = "txtElevOffX";
            this.txtElevOffX.Size = new System.Drawing.Size(183, 62);
            this.txtElevOffX.TabIndex = 39;
            // 
            // txtElevOffY
            // 
            this.txtElevOffY.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElevOffY.Location = new System.Drawing.Point(795, 1249);
            this.txtElevOffY.Name = "txtElevOffY";
            this.txtElevOffY.Size = new System.Drawing.Size(183, 62);
            this.txtElevOffY.TabIndex = 40;
            // 
            // dispXY
            // 
            this.dispXY.BackColor = System.Drawing.Color.Black;
            this.dispXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dispXY.Location = new System.Drawing.Point(35, 248);
            this.dispXY.Name = "dispXY";
            this.dispXY.Size = new System.Drawing.Size(865, 865);
            this.dispXY.TabIndex = 41;
            this.dispXY.TabStop = false;
            this.dispXY.Paint += new System.Windows.Forms.PaintEventHandler(this.displayXY_Paint);
            // 
            // displayZoomIn
            // 
            this.displayZoomIn.BackColor = System.Drawing.Color.Gray;
            this.displayZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayZoomIn.Location = new System.Drawing.Point(906, 390);
            this.displayZoomIn.Name = "displayZoomIn";
            this.displayZoomIn.Size = new System.Drawing.Size(97, 89);
            this.displayZoomIn.TabIndex = 42;
            this.displayZoomIn.Text = "+";
            this.displayZoomIn.UseVisualStyleBackColor = false;
            this.displayZoomIn.Click += new System.EventHandler(this.displayZoomIn_Click);
            // 
            // displayZoomOut
            // 
            this.displayZoomOut.BackColor = System.Drawing.Color.Gray;
            this.displayZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayZoomOut.Location = new System.Drawing.Point(906, 485);
            this.displayZoomOut.Name = "displayZoomOut";
            this.displayZoomOut.Size = new System.Drawing.Size(97, 87);
            this.displayZoomOut.TabIndex = 43;
            this.displayZoomOut.Text = "-";
            this.displayZoomOut.UseVisualStyleBackColor = false;
            this.displayZoomOut.Click += new System.EventHandler(this.displayZoomOut_Click);
            // 
            // lblDisplayZoomLevel
            // 
            this.lblDisplayZoomLevel.AutoSize = true;
            this.lblDisplayZoomLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayZoomLevel.ForeColor = System.Drawing.Color.Lime;
            this.lblDisplayZoomLevel.Location = new System.Drawing.Point(932, 296);
            this.lblDisplayZoomLevel.Name = "lblDisplayZoomLevel";
            this.lblDisplayZoomLevel.Size = new System.Drawing.Size(46, 51);
            this.lblDisplayZoomLevel.TabIndex = 44;
            this.lblDisplayZoomLevel.Text = "1";
            this.lblDisplayZoomLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dispXZ
            // 
            this.dispXZ.BackColor = System.Drawing.Color.Black;
            this.dispXZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dispXZ.Location = new System.Drawing.Point(1009, 248);
            this.dispXZ.Name = "dispXZ";
            this.dispXZ.Size = new System.Drawing.Size(893, 865);
            this.dispXZ.TabIndex = 45;
            this.dispXZ.TabStop = false;
            this.dispXZ.Paint += new System.Windows.Forms.PaintEventHandler(this.displayXZ_Paint);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 10000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(999, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 55);
            this.label4.TabIndex = 49;
            this.label4.Text = "Elevation";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(1554, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 25);
            this.label13.TabIndex = 51;
            this.label13.Text = "Target";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Green;
            this.label14.Location = new System.Drawing.Point(1322, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 25);
            this.label14.TabIndex = 50;
            this.label14.Text = "Current";
            // 
            // lblCurrentZ
            // 
            this.lblCurrentZ.AutoSize = true;
            this.lblCurrentZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentZ.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentZ.Location = new System.Drawing.Point(1343, 190);
            this.lblCurrentZ.Name = "lblCurrentZ";
            this.lblCurrentZ.Size = new System.Drawing.Size(51, 55);
            this.lblCurrentZ.TabIndex = 52;
            this.lblCurrentZ.Text = "0";
            // 
            // lblTargetZ
            // 
            this.lblTargetZ.AutoSize = true;
            this.lblTargetZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetZ.ForeColor = System.Drawing.Color.Lime;
            this.lblTargetZ.Location = new System.Drawing.Point(1565, 190);
            this.lblTargetZ.Name = "lblTargetZ";
            this.lblTargetZ.Size = new System.Drawing.Size(51, 55);
            this.lblTargetZ.TabIndex = 53;
            this.lblTargetZ.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.ClientSize = new System.Drawing.Size(1941, 1127);
            this.Controls.Add(this.lblTargetZ);
            this.Controls.Add(this.lblCurrentZ);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dispXZ);
            this.Controls.Add(this.lblDisplayZoomLevel);
            this.Controls.Add(this.displayZoomOut);
            this.Controls.Add(this.displayZoomIn);
            this.Controls.Add(this.dispXY);
            this.Controls.Add(this.txtElevOffY);
            this.Controls.Add(this.txtElevOffX);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblCurrentElevation);
            this.Controls.Add(this.lblCurrentBearing);
            this.Controls.Add(this.lblElevationToTarget);
            this.Controls.Add(this.lblBearingToTarget);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnMakeTarget);
            this.Controls.Add(this.lblRateOfChange);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblDistanceToTarget);
            this.Controls.Add(this.btnTargetSet);
            this.Controls.Add(this.txtCoordZTarget);
            this.Controls.Add(this.txtCoordYTarget);
            this.Controls.Add(this.txtCoordXTarget);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDeltaZ);
            this.Controls.Add(this.txtDeltaY);
            this.Controls.Add(this.txtDeltaX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCoordZLast);
            this.Controls.Add(this.txtCoordYLast);
            this.Controls.Add(this.txtCoordXLast);
            this.Controls.Add(this.txtFromClipboard);
            this.Controls.Add(this.txtCoordZ);
            this.Controls.Add(this.txtCoordY);
            this.Controls.Add(this.txtCoordX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispXZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCoordX;
        private System.Windows.Forms.TextBox txtCoordY;
        private System.Windows.Forms.TextBox txtCoordZ;
        private System.Windows.Forms.TextBox txtFromClipboard;
        private System.Windows.Forms.TextBox txtCoordZLast;
        private System.Windows.Forms.TextBox txtCoordYLast;
        private System.Windows.Forms.TextBox txtCoordXLast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeltaZ;
        private System.Windows.Forms.TextBox txtDeltaY;
        private System.Windows.Forms.TextBox txtDeltaX;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCoordXTarget;
        private System.Windows.Forms.TextBox txtCoordYTarget;
        private System.Windows.Forms.TextBox txtCoordZTarget;
        private System.Windows.Forms.Button btnTargetSet;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDistanceToTarget;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRateOfChange;
        private System.Windows.Forms.Button btnMakeTarget;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblBearingToTarget;
        private System.Windows.Forms.Label lblElevationToTarget;
        private System.Windows.Forms.Label lblCurrentBearing;
        private System.Windows.Forms.Label lblCurrentElevation;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtElevOffX;
        private System.Windows.Forms.TextBox txtElevOffY;
        private System.Windows.Forms.PictureBox dispXY;
        private System.Windows.Forms.Button displayZoomIn;
        private System.Windows.Forms.Button displayZoomOut;
        private System.Windows.Forms.Label lblDisplayZoomLevel;
        private System.Windows.Forms.PictureBox dispXZ;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCurrentZ;
        private System.Windows.Forms.Label lblTargetZ;
    }
}

