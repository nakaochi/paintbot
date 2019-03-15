using PaintBot.Core.Common;
using PaintBot.Core.Logic;
using PaintBot.Core.Model;
using PaintBot.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintBot.Core.Forms
{
	public partial class FormMain : Form
	{
		private List<BotMeta> _botMetaList = null;

		private Dictionary<string, Map> _mapSet = null;

		public FormMain()
		{
			InitializeComponent();

			Init();
		}

		private void Init()
		{
			// ボットクラスを読み込む
			_botMetaList = GameLoader.ScanBots();
			// マップファイルを読み込む
			_mapSet = GameLoader.LoadMap(Consts.MAP_FILE);
		}

		private void toolStripButtonStart_Click(object sender, EventArgs e)
		{
			// 設定フォームを生成
			var formConfig = new FormConfig(_botMetaList);

			// ダイアログ表示して OK 以外の場合
			if (formConfig.ShowDialog() != DialogResult.OK)
			{
				// 何もしない
				return;
			}

			// プレイヤー情報を取得
			var players = formConfig.PlayerList;

			var game = new Game();

			game.Init(_botMetaList, players, _mapSet.First().Value);
		}
	}
}
