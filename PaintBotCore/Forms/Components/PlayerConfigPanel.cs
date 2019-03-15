﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaintBot.Core.Model;
using PaintBot.Core.Utils;

namespace PaintBot.Core.Forms.Components
{
	/// <summary>
	/// 
	/// </summary>
	public partial class PlayerConfigPanel : UserControl
	{
		/// <summary>
		/// プレイヤー色
		/// </summary>
		private Color PlayerColor { set; get; } = Color.White;

		/// <summary>
		/// 色の変更を可能とするか
		/// </summary>
		public bool CanChangeColor { set; get; } = false;

		/// <summary>
		/// Botメタ情報のリスト
		/// </summary>
		private List<BotMeta> botMetaList = null;


		/// <summary>
		/// プレイヤー設定パネルを生成する
		/// </summary>
		public PlayerConfigPanel()
		{
			// コンポーネントを初期化
			InitializeComponent();

			// パネルの背景色を初期化
			panelColor.BackColor = PlayerColor;
		}

		/// <summary>
		/// Bot リストを初期化する
		/// </summary>
		/// <param name="metaList">Bot メタ情報のリスト</param>
		public void InitBotList(List<BotMeta> metaList)
		{
			Assert.IsNotNull(metaList, nameof(metaList));

			// 保持
			this.botMetaList = new List<BotMeta>(metaList);
			// ソート
			this.botMetaList.Sort((a, b) => a.BotId.CompareTo(b.BotId));

			// クリア
			comboBoxBotName.Items.Clear();
			// ComboBox に Item 追加
			botMetaList.ForEach(m => comboBoxBotName.Items.Add(new ComboBoxItemBot(m)));
		}

		/// <summary>
		/// プレイヤー情報を取得する
		/// </summary>
		/// <returns>プレイヤー情報</returns>
		public Player GetPlayer()
		{
			// コンボボックスのアイテムを取得
			var comboItem = comboBoxBotName.SelectedValue as ComboBoxItemBot;

			// 入力された情報を取得する
			var playerName = textBoxName.Text;
			var botId = comboItem?.BotId;
			var colorCode = String.Format("{0:x2}{1:x2}{2:x2}", PlayerColor.R, PlayerColor.G, PlayerColor.B);

			// 無効なデータの場合
			if (string.IsNullOrEmpty(playerName) || botId == null)
			{
				return null;
			}

			// プレイヤー情報を生成
			var ret = new Player(playerName, botId, colorCode);

			// 結果を返す
			return ret;
		}

		private void panelColor_Click(object sender, EventArgs e)
		{
			// 色変更不可の場合
			if (!CanChangeColor)
			{
				// 何もしない
				return;
			}

			// 色選択ダイアログを生成
			var colorDialog = new ColorDialog();
			// 初期色を設定
			colorDialog.Color = PlayerColor;

			// ダイアログを表示して、OK以外だった場合
			if (colorDialog.ShowDialog() != DialogResult.OK)
			{
				// 何もしない
				return;
			}

			// 黒色の場合
			if (colorDialog.Color == Color.Black)
			{
				MessageBox.Show("黒色は指定できません", "注意", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// 色を変更
			PlayerColor = colorDialog.Color;
			panelColor.BackColor = PlayerColor;
		}

		/// <summary>
		/// ComboBox 用アイテムクラス
		/// </summary>
		private class ComboBoxItemBot
		{
			/// <summary>
			/// Bot メタ情報
			/// </summary>
			private BotMeta meta = null;

			/// <summary>
			/// Bot Id
			/// </summary>
			public string BotId => meta.BotId;

			/// <summary>
			/// コンボボックスに表示するテキスト
			/// </summary>
			public string Text => $"{meta.BotId} - {meta.Author}";

			/// <summary>
			/// ComboBox のアイテムを生成する
			/// </summary>
			/// <param name="meta">Bot メタ情報</param>
			public ComboBoxItemBot(BotMeta meta)
			{
				Assert.IsNotNull(meta, nameof(meta));

				this.meta = meta;
			}

			/// <summary>
			/// 文字列化
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return Text;
			}
		}
	}
}
