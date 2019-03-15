using PaintBot.Core.Forms.Components;
using PaintBot.Core.Model;
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
	public partial class FormConfig : Form
	{
		/// <summary>
		/// プレイヤー設定パネルのリスト
		/// </summary>
		private List<PlayerConfigPanel> _playerConfigPanelList;

		public FormConfig(List<BotMeta> botMetaList)
		{
			InitializeComponent();

			// 設定パネルをリスト化
			_playerConfigPanelList = new List<PlayerConfigPanel>
			{
				playerConfigPanel1,
				playerConfigPanel2,
				playerConfigPanel3,
				playerConfigPanel4,
			};

			// Botメタ情報を渡す
			_playerConfigPanelList.ForEach(p =>
			{
				p.InitBotList(botMetaList);
			});

			// ２人をチェック
			radioButtonPlayerCount2.Checked = true;
		}

		private void radioButtonPlayerCount_CheckedChanged(object sender, EventArgs e)
		{
			// プレイヤー人数を取得
			var playerCount = int.Parse((string)(sender as RadioButton).Tag);

			for (int i = 0; i < _playerConfigPanelList.Count; i ++)
			{
				_playerConfigPanelList[i].Visible = (i < playerCount);
			}
		}

		/// <summary>
		/// プレイヤー情報のリスト
		/// </summary>
		public List<Player> PlayerList
		{
			get
			{
				// 戻り値
				var ret = new List<Player>();

				// 表示されているプレイヤー設定パネルのプレイヤー情報を戻り値に追加
				ret.AddRange(_playerConfigPanelList
					.Where(p => p.Visible)
					.Select(p => p.GetPlayer())
				);

				// 結果を返す
				return ret;
			}
		}
	}
}
