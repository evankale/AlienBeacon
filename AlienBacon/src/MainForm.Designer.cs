namespace AlienBacon
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.videoLink = new System.Windows.Forms.LinkLabel();
			this.srcLabel = new System.Windows.Forms.Label();
			this.imgSrcBtn = new System.Windows.Forms.Button();
			this.folderSrcBtn = new System.Windows.Forms.Button();
			this.delayLabel = new System.Windows.Forms.Label();
			this.previewLabel = new System.Windows.Forms.Label();
			this.playBtn = new System.Windows.Forms.Button();
			this.saveBtn = new System.Windows.Forms.Button();
			this.colorBox = new System.Windows.Forms.TextBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.delayUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.delayUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// videoLink
			// 
			this.videoLink.AutoSize = true;
			this.videoLink.Location = new System.Drawing.Point(11, 16);
			this.videoLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.videoLink.Name = "videoLink";
			this.videoLink.Size = new System.Drawing.Size(138, 13);
			this.videoLink.TabIndex = 0;
			this.videoLink.TabStop = true;
			this.videoLink.Text = "> Instructional Video Here <";
			this.videoLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.videoLink_LinkClicked);
			// 
			// srcLabel
			// 
			this.srcLabel.AutoSize = true;
			this.srcLabel.Location = new System.Drawing.Point(11, 46);
			this.srcLabel.Name = "srcLabel";
			this.srcLabel.Size = new System.Drawing.Size(107, 13);
			this.srcLabel.TabIndex = 1;
			this.srcLabel.Text = "Choose color source:";
			// 
			// imgSrcBtn
			// 
			this.imgSrcBtn.Location = new System.Drawing.Point(14, 69);
			this.imgSrcBtn.Name = "imgSrcBtn";
			this.imgSrcBtn.Size = new System.Drawing.Size(93, 38);
			this.imgSrcBtn.TabIndex = 2;
			this.imgSrcBtn.Text = "Image colors";
			this.imgSrcBtn.UseVisualStyleBackColor = true;
			this.imgSrcBtn.Click += new System.EventHandler(this.imgSrcBtn_Click);
			// 
			// folderSrcBtn
			// 
			this.folderSrcBtn.Location = new System.Drawing.Point(124, 69);
			this.folderSrcBtn.Name = "folderSrcBtn";
			this.folderSrcBtn.Size = new System.Drawing.Size(93, 38);
			this.folderSrcBtn.TabIndex = 3;
			this.folderSrcBtn.Text = "Color sequence";
			this.folderSrcBtn.UseVisualStyleBackColor = true;
			this.folderSrcBtn.Click += new System.EventHandler(this.folderSrcBtn_Click);
			// 
			// delayLabel
			// 
			this.delayLabel.AutoSize = true;
			this.delayLabel.Location = new System.Drawing.Point(138, 166);
			this.delayLabel.Name = "delayLabel";
			this.delayLabel.Size = new System.Drawing.Size(67, 13);
			this.delayLabel.TabIndex = 4;
			this.delayLabel.Text = "Frame delay:";
			// 
			// previewLabel
			// 
			this.previewLabel.AutoSize = true;
			this.previewLabel.Location = new System.Drawing.Point(12, 166);
			this.previewLabel.Name = "previewLabel";
			this.previewLabel.Size = new System.Drawing.Size(48, 13);
			this.previewLabel.TabIndex = 5;
			this.previewLabel.Text = "Preview:";
			// 
			// playBtn
			// 
			this.playBtn.Location = new System.Drawing.Point(30, 277);
			this.playBtn.Name = "playBtn";
			this.playBtn.Size = new System.Drawing.Size(73, 30);
			this.playBtn.TabIndex = 7;
			this.playBtn.Text = "Play";
			this.playBtn.UseVisualStyleBackColor = true;
			this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(141, 265);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(76, 42);
			this.saveBtn.TabIndex = 8;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// colorBox
			// 
			this.colorBox.BackColor = System.Drawing.Color.Black;
			this.colorBox.Enabled = false;
			this.colorBox.Location = new System.Drawing.Point(15, 185);
			this.colorBox.Multiline = true;
			this.colorBox.Name = "colorBox";
			this.colorBox.Size = new System.Drawing.Size(103, 78);
			this.colorBox.TabIndex = 9;
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(14, 127);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(203, 23);
			this.progressBar.TabIndex = 10;
			// 
			// delayUpDown
			// 
			this.delayUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.delayUpDown.Location = new System.Drawing.Point(141, 186);
			this.delayUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
			this.delayUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.delayUpDown.Name = "delayUpDown";
			this.delayUpDown.Size = new System.Drawing.Size(76, 20);
			this.delayUpDown.TabIndex = 11;
			this.delayUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(235, 331);
			this.Controls.Add(this.delayUpDown);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.colorBox);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.playBtn);
			this.Controls.Add(this.previewLabel);
			this.Controls.Add(this.delayLabel);
			this.Controls.Add(this.folderSrcBtn);
			this.Controls.Add(this.imgSrcBtn);
			this.Controls.Add(this.srcLabel);
			this.Controls.Add(this.videoLink);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.Text = "AlienBacon";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.delayUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel videoLink;
        private System.Windows.Forms.Label srcLabel;
        private System.Windows.Forms.Button imgSrcBtn;
        private System.Windows.Forms.Button folderSrcBtn;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox colorBox;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.NumericUpDown delayUpDown;
	}
}

