namespace CompareLoggingCode
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnFindCSV = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnTestsound = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblCode2 = new System.Windows.Forms.Label();
            this.lblOKNG = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Label();
            this.txtAlwayFocus = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSCVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFindCSV
            // 
            this.btnFindCSV.Location = new System.Drawing.Point(843, 327);
            this.btnFindCSV.Name = "btnFindCSV";
            this.btnFindCSV.Size = new System.Drawing.Size(84, 25);
            this.btnFindCSV.TabIndex = 0;
            this.btnFindCSV.Text = "Find All";
            this.btnFindCSV.UseVisualStyleBackColor = true;
            this.btnFindCSV.Click += new System.EventHandler(this.btnFindCSV_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.btnTestsound);
            this.pnlMain.Controls.Add(this.lblResult);
            this.pnlMain.Controls.Add(this.lblCode2);
            this.pnlMain.Controls.Add(this.lblOKNG);
            this.pnlMain.Controls.Add(this.lblCode);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.txtAlwayFocus);
            this.pnlMain.Controls.Add(this.btnFindCSV);
            this.pnlMain.Controls.Add(this.menuStrip1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(727, 633);
            this.pnlMain.TabIndex = 1;
            // 
            // btnTestsound
            // 
            this.btnTestsound.Location = new System.Drawing.Point(12, 37);
            this.btnTestsound.Name = "btnTestsound";
            this.btnTestsound.Size = new System.Drawing.Size(75, 23);
            this.btnTestsound.TabIndex = 4;
            this.btnTestsound.Text = "OK Sound";
            this.btnTestsound.UseVisualStyleBackColor = true;
            this.btnTestsound.Visible = false;
            this.btnTestsound.Click += new System.EventHandler(this.btnTestsound_Click);
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.DarkGreen;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(8, 32);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(712, 535);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Wait";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCode2
            // 
            this.lblCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCode2.Location = new System.Drawing.Point(7, 604);
            this.lblCode2.Name = "lblCode2";
            this.lblCode2.Size = new System.Drawing.Size(657, 23);
            this.lblCode2.TabIndex = 3;
            this.lblCode2.Text = "QR Code";
            this.lblCode2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOKNG
            // 
            this.lblOKNG.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOKNG.ForeColor = System.Drawing.Color.White;
            this.lblOKNG.Location = new System.Drawing.Point(670, 579);
            this.lblOKNG.Name = "lblOKNG";
            this.lblOKNG.Size = new System.Drawing.Size(50, 48);
            this.lblOKNG.TabIndex = 3;
            this.lblOKNG.Text = "NG";
            this.lblOKNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCode
            // 
            this.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCode.Location = new System.Drawing.Point(7, 579);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(657, 23);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "QR Code";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(695, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 13);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtAlwayFocus
            // 
            this.txtAlwayFocus.Location = new System.Drawing.Point(843, 371);
            this.txtAlwayFocus.Name = "txtAlwayFocus";
            this.txtAlwayFocus.Size = new System.Drawing.Size(111, 20);
            this.txtAlwayFocus.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSCVToolStripMenuItem,
            this.queryToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // exportSCVToolStripMenuItem
            // 
            this.exportSCVToolStripMenuItem.Name = "exportSCVToolStripMenuItem";
            this.exportSCVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportSCVToolStripMenuItem.Text = "Export SCV";
            this.exportSCVToolStripMenuItem.Click += new System.EventHandler(this.exportSCVToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnlMain;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.menuStrip1;
            this.bunifuDragControl2.Vertical = true;
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.queryToolStripMenuItem.Text = "Query";
            this.queryToolStripMenuItem.Click += new System.EventHandler(this.queryToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 633);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "QRCode Data Compare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFindCSV;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox txtAlwayFocus;
        private System.Windows.Forms.Label btnExit;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblCode2;
        private System.Windows.Forms.Label lblOKNG;
        private System.Windows.Forms.Button btnTestsound;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSCVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
    }
}

