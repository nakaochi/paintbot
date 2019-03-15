namespace PaintBot.Core.Forms.Components
{
	partial class PlayerConfigPanel
	{
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.comboBoxBotName = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panelColor = new System.Windows.Forms.Panel();
			this.labelNumber = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(61, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "プレイヤー名";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(156, 7);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(134, 19);
			this.textBoxName.TabIndex = 1;
			// 
			// comboBoxBotName
			// 
			this.comboBoxBotName.FormattingEnabled = true;
			this.comboBoxBotName.Location = new System.Drawing.Point(156, 32);
			this.comboBoxBotName.Name = "comboBoxBotName";
			this.comboBoxBotName.Size = new System.Drawing.Size(219, 20);
			this.comboBoxBotName.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(61, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "Bot 名";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(403, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "色";
			// 
			// panelColor
			// 
			this.panelColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panelColor.Location = new System.Drawing.Point(433, 7);
			this.panelColor.Name = "panelColor";
			this.panelColor.Size = new System.Drawing.Size(49, 44);
			this.panelColor.TabIndex = 3;
			this.panelColor.Click += new System.EventHandler(this.panelColor_Click);
			// 
			// labelNumber
			// 
			this.labelNumber.AutoSize = true;
			this.labelNumber.Location = new System.Drawing.Point(8, 25);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(13, 12);
			this.labelNumber.TabIndex = 4;
			this.labelNumber.Text = "１";
			// 
			// PlayerConfigPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelNumber);
			this.Controls.Add(this.panelColor);
			this.Controls.Add(this.comboBoxBotName);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "PlayerConfigPanel";
			this.Size = new System.Drawing.Size(508, 62);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.ComboBox comboBoxBotName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panelColor;
		private System.Windows.Forms.Label labelNumber;
	}
}
