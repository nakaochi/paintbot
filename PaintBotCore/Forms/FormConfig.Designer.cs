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
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioButtonPlayerCount4 = new System.Windows.Forms.RadioButton();
			this.radioButtonPlayerCount3 = new System.Windows.Forms.RadioButton();
			this.radioButtonPlayerCount2 = new System.Windows.Forms.RadioButton();
			this.playerConfigPanel4 = new PaintBot.Core.Forms.Components.PlayerConfigPanel();
			this.playerConfigPanel3 = new PaintBot.Core.Forms.Components.PlayerConfigPanel();
			this.playerConfigPanel2 = new PaintBot.Core.Forms.Components.PlayerConfigPanel();
			this.playerConfigPanel1 = new PaintBot.Core.Forms.Components.PlayerConfigPanel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonStart.Location = new System.Drawing.Point(376, 329);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(133, 50);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "開始";
			this.buttonStart.UseVisualStyleBackColor = true;
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
			// panel1
			// 
			this.panel1.Controls.Add(this.radioButtonPlayerCount4);
			this.panel1.Controls.Add(this.radioButtonPlayerCount3);
			this.panel1.Controls.Add(this.radioButtonPlayerCount2);
			this.panel1.Location = new System.Drawing.Point(108, 15);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(224, 34);
			this.panel1.TabIndex = 4;
			// 
			// radioButtonPlayerCount4
			// 
			this.radioButtonPlayerCount4.AutoSize = true;
			this.radioButtonPlayerCount4.Location = new System.Drawing.Point(141, 9);
			this.radioButtonPlayerCount4.Name = "radioButtonPlayerCount4";
			this.radioButtonPlayerCount4.Size = new System.Drawing.Size(43, 16);
			this.radioButtonPlayerCount4.TabIndex = 2;
			this.radioButtonPlayerCount4.TabStop = true;
			this.radioButtonPlayerCount4.Tag = "4";
			this.radioButtonPlayerCount4.Text = "４人";
			this.radioButtonPlayerCount4.UseVisualStyleBackColor = true;
			this.radioButtonPlayerCount4.CheckedChanged += new System.EventHandler(this.radioButtonPlayerCount_CheckedChanged);
			// 
			// radioButtonPlayerCount3
			// 
			this.radioButtonPlayerCount3.AutoSize = true;
			this.radioButtonPlayerCount3.Location = new System.Drawing.Point(77, 9);
			this.radioButtonPlayerCount3.Name = "radioButtonPlayerCount3";
			this.radioButtonPlayerCount3.Size = new System.Drawing.Size(43, 16);
			this.radioButtonPlayerCount3.TabIndex = 3;
			this.radioButtonPlayerCount3.TabStop = true;
			this.radioButtonPlayerCount3.Tag = "3";
			this.radioButtonPlayerCount3.Text = "３人";
			this.radioButtonPlayerCount3.UseVisualStyleBackColor = true;
			this.radioButtonPlayerCount3.CheckedChanged += new System.EventHandler(this.radioButtonPlayerCount_CheckedChanged);
			// 
			// radioButtonPlayerCount2
			// 
			this.radioButtonPlayerCount2.AutoSize = true;
			this.radioButtonPlayerCount2.Location = new System.Drawing.Point(11, 9);
			this.radioButtonPlayerCount2.Name = "radioButtonPlayerCount2";
			this.radioButtonPlayerCount2.Size = new System.Drawing.Size(43, 16);
			this.radioButtonPlayerCount2.TabIndex = 4;
			this.radioButtonPlayerCount2.TabStop = true;
			this.radioButtonPlayerCount2.Tag = "2";
			this.radioButtonPlayerCount2.Text = "２人";
			this.radioButtonPlayerCount2.UseVisualStyleBackColor = true;
			this.radioButtonPlayerCount2.CheckedChanged += new System.EventHandler(this.radioButtonPlayerCount_CheckedChanged);
			// 
			// playerConfigPanel4
			// 
			this.playerConfigPanel4.CanChangeColor = false;
			this.playerConfigPanel4.Location = new System.Drawing.Point(12, 261);
			this.playerConfigPanel4.Name = "playerConfigPanel4";
			this.playerConfigPanel4.PanelNumber = "No.4";
			this.playerConfigPanel4.PlayerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.playerConfigPanel4.Size = new System.Drawing.Size(508, 62);
			this.playerConfigPanel4.TabIndex = 3;
			// 
			// playerConfigPanel3
			// 
			this.playerConfigPanel3.CanChangeColor = false;
			this.playerConfigPanel3.Location = new System.Drawing.Point(12, 193);
			this.playerConfigPanel3.Name = "playerConfigPanel3";
			this.playerConfigPanel3.PanelNumber = "No.3";
			this.playerConfigPanel3.PlayerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.playerConfigPanel3.Size = new System.Drawing.Size(508, 62);
			this.playerConfigPanel3.TabIndex = 3;
			// 
			// playerConfigPanel2
			// 
			this.playerConfigPanel2.CanChangeColor = false;
			this.playerConfigPanel2.Location = new System.Drawing.Point(12, 125);
			this.playerConfigPanel2.Name = "playerConfigPanel2";
			this.playerConfigPanel2.PanelNumber = "No.2";
			this.playerConfigPanel2.PlayerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.playerConfigPanel2.Size = new System.Drawing.Size(508, 62);
			this.playerConfigPanel2.TabIndex = 3;
			// 
			// playerConfigPanel1
			// 
			this.playerConfigPanel1.CanChangeColor = false;
			this.playerConfigPanel1.Location = new System.Drawing.Point(12, 57);
			this.playerConfigPanel1.Name = "playerConfigPanel1";
			this.playerConfigPanel1.PanelNumber = "No.1";
			this.playerConfigPanel1.PlayerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.playerConfigPanel1.Size = new System.Drawing.Size(508, 62);
			this.playerConfigPanel1.TabIndex = 3;
			// 
			// FormConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(532, 395);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.playerConfigPanel4);
			this.Controls.Add(this.playerConfigPanel3);
			this.Controls.Add(this.playerConfigPanel2);
			this.Controls.Add(this.playerConfigPanel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonStart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConfig";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "設定";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label label1;
		private Components.PlayerConfigPanel playerConfigPanel1;
		private Components.PlayerConfigPanel playerConfigPanel2;
		private Components.PlayerConfigPanel playerConfigPanel3;
		private Components.PlayerConfigPanel playerConfigPanel4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioButtonPlayerCount4;
		private System.Windows.Forms.RadioButton radioButtonPlayerCount3;
		private System.Windows.Forms.RadioButton radioButtonPlayerCount2;
	}
}