namespace PaintBot.Core.Forms
{
	partial class FormMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelMain = new System.Windows.Forms.Panel();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.toolStripButtonNextStep = new System.Windows.Forms.ToolStripButton();
			this.panelInfo = new System.Windows.Forms.Panel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.textBoxInfo = new System.Windows.Forms.TextBox();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panelMain.SuspendLayout();
			this.panelInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonStop,
            this.toolStripButtonNextStep});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(1014, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// toolStripButtonStart
			// 
			this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
			this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonStart.Name = "toolStripButtonStart";
			this.toolStripButtonStart.Size = new System.Drawing.Size(51, 22);
			this.toolStripButtonStart.Text = "開始";
			this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
			// 
			// toolStripButtonStop
			// 
			this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
			this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonStop.Name = "toolStripButtonStop";
			this.toolStripButtonStop.Size = new System.Drawing.Size(51, 22);
			this.toolStripButtonStop.Text = "停止";
			this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 517);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1014, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(59, 17);
			this.toolStripStatusLabel.Text = "(ステータス)";
			// 
			// panelMain
			// 
			this.panelMain.BackColor = System.Drawing.SystemColors.Control;
			this.panelMain.Controls.Add(this.pictureBox);
			this.panelMain.Controls.Add(this.panelInfo);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 25);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1014, 492);
			this.panelMain.TabIndex = 2;
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 10;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// toolStripButtonNextStep
			// 
			this.toolStripButtonNextStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNextStep.Image")));
			this.toolStripButtonNextStep.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonNextStep.Name = "toolStripButtonNextStep";
			this.toolStripButtonNextStep.Size = new System.Drawing.Size(74, 22);
			this.toolStripButtonNextStep.Text = "次ステップ";
			this.toolStripButtonNextStep.Click += new System.EventHandler(this.toolStripButtonNextStep_Click);
			// 
			// panelInfo
			// 
			this.panelInfo.Controls.Add(this.textBoxInfo);
			this.panelInfo.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelInfo.Location = new System.Drawing.Point(814, 0);
			this.panelInfo.Name = "panelInfo";
			this.panelInfo.Size = new System.Drawing.Size(200, 492);
			this.panelInfo.TabIndex = 1;
			// 
			// pictureBox
			// 
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(814, 492);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// textBoxInfo
			// 
			this.textBoxInfo.Location = new System.Drawing.Point(6, 27);
			this.textBoxInfo.Multiline = true;
			this.textBoxInfo.Name = "textBoxInfo";
			this.textBoxInfo.ReadOnly = true;
			this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxInfo.Size = new System.Drawing.Size(182, 462);
			this.textBoxInfo.TabIndex = 0;
			this.textBoxInfo.WordWrap = false;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1014, 539);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.Text = "Paint Bot";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.panelMain.ResumeLayout(false);
			this.panelInfo.ResumeLayout(false);
			this.panelInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.ToolStripButton toolStripButtonStart;
		private System.Windows.Forms.ToolStripButton toolStripButtonStop;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ToolStripButton toolStripButtonNextStep;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Panel panelInfo;
		private System.Windows.Forms.TextBox textBoxInfo;
	}
}

