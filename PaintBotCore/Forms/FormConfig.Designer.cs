namespace PaintBot.Core.Forms
{
	partial class FormConfig
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
			this.buttonStart = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.playerConfigPanel1 = new PaintBot.Core.Forms.Components.PlayerConfigPanel();
			this.playerConfigPanel2 = new PaintBot.Core.Forms.Components.PlayerConfigPanel();
			this.playerConfigPanel3 = new PaintBot.Core.Forms.Components.PlayerConfigPanel();
			this.playerConfigPanel4 = new PaintBot.Core.Forms.Components.PlayerConfigPanel();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(376, 329);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(133, 50);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "開始";
			this.buttonStart.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(135, 22);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(43, 16);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "２人";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(201, 22);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(43, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "３人";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(262, 22);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(43, 16);
			this.radioButton3.TabIndex = 1;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "４人";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "プレイヤー";
			// 
			// playerConfigPanel1
			// 
			this.playerConfigPanel1.CanChangeColor = false;
			this.playerConfigPanel1.Location = new System.Drawing.Point(12, 57);
			this.playerConfigPanel1.Name = "playerConfigPanel1";
			this.playerConfigPanel1.Size = new System.Drawing.Size(508, 62);
			this.playerConfigPanel1.TabIndex = 3;
			// 
			// playerConfigPanel2
			// 
			this.playerConfigPanel2.CanChangeColor = false;
			this.playerConfigPanel2.Location = new System.Drawing.Point(12, 125);
			this.playerConfigPanel2.Name = "playerConfigPanel2";
			this.playerConfigPanel2.Size = new System.Drawing.Size(508, 62);
			this.playerConfigPanel2.TabIndex = 3;
			// 
			// playerConfigPanel3
			// 
			this.playerConfigPanel3.CanChangeColor = false;
			this.playerConfigPanel3.Location = new System.Drawing.Point(12, 193);
			this.playerConfigPanel3.Name = "playerConfigPanel3";
			this.playerConfigPanel3.Size = new System.Drawing.Size(508, 62);
			this.playerConfigPanel3.TabIndex = 3;
			// 
			// playerConfigPanel4
			// 
			this.playerConfigPanel4.CanChangeColor = false;
			this.playerConfigPanel4.Location = new System.Drawing.Point(12, 261);
			this.playerConfigPanel4.Name = "playerConfigPanel4";
			this.playerConfigPanel4.Size = new System.Drawing.Size(508, 62);
			this.playerConfigPanel4.TabIndex = 3;
			// 
			// FormConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(532, 395);
			this.Controls.Add(this.playerConfigPanel4);
			this.Controls.Add(this.playerConfigPanel3);
			this.Controls.Add(this.playerConfigPanel2);
			this.Controls.Add(this.playerConfigPanel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.buttonStart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormConfig";
			this.Text = "設定";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label label1;
		private Components.PlayerConfigPanel playerConfigPanel1;
		private Components.PlayerConfigPanel playerConfigPanel2;
		private Components.PlayerConfigPanel playerConfigPanel3;
		private Components.PlayerConfigPanel playerConfigPanel4;
	}
}