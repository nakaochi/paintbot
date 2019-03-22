using PaintBot.Core.Common;
using PaintBot.Core.Forms.Utils;
using PaintBot.Core.Logic;
using PaintBot.Core.Model;
using PaintBot.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintBot.Core.Forms
{
	public partial class FormMain : Form
	{
		/// <summary>
		/// Botメタのリスト
		/// </summary>
		private List<BotMeta> _botMetaList = null;

		/// <summary>
		/// マップセット
		/// </summary>
		private Dictionary<string, Map> _mapSet = null;

		/// <summary>
		/// 経過時間計測用のストップウォッチ
		/// </summary>
		private Stopwatch _stopwatch = null;

		/// <summary>
		/// 経過時間（ミリ秒）
		/// </summary>
		private long _timerSpan = 0;

		/// <summary>
		/// 秒間フレーム数
		/// </summary>
		public long FramePerSecond { set; get; } = 20;

		/// <summary>
		/// １フレームごとのミリ秒
		/// </summary>
		public long MsPerFrame => 1000 / FramePerSecond;

		/// <summary>
		/// セルサイズ
		/// </summary>
		private int CellSize => 50;


		/// <summary>
		/// バックスクリーン
		/// </summary>
		private Bitmap _backScr = null;

		/// <summary>
		/// 処理中のロジック
		/// </summary>
		private Game _game = null;


		/// <summary>
		/// フォームステータスの列挙型
		/// </summary>
		public enum EFormStatus
		{
			/// <summary>
			/// 停止中
			/// </summary>
			STOPPED,

			/// <summary>
			/// プレイ中
			/// </summary>
			PLAYING,
		}

		/// <summary>
		/// フォームステータス
		/// </summary>
		public EFormStatus Status { private set; get; } = EFormStatus.STOPPED;


		/// <summary>
		/// セルイメージのインデックス列挙型
		/// </summary>
		private enum ECellImage
		{
			FLOOR_NONE,
			FLOOR_1,
			FLOOR_2,
			FLOOR_3,
			FLOOR_4,
			START_1,
			START_2,
			START_3,
			START_4,
			WALL,
			WIRE_MESH,
			PLAYER_1,
			PLAYER_2,
			PLAYER_3,
			PLAYER_4,
		}

		/// <summary>
		/// インデックスとセルイメージのマップ
		/// </summary>
		private Dictionary<ECellImage, Bitmap> _cellImageMap = null;

		/// <summary>
		/// カラーコードとカラーのマップ
		/// </summary>
		private Dictionary<string, Color> _colorMap = new Dictionary<string, Color>();



		public FormMain()
		{
			// コンポーネントを初期化
			InitializeComponent();
		}

		/// <summary>
		/// データを初期化する
		/// </summary>
		private void InitData()
		{
			// ストップウォッチを生成
			_stopwatch = new Stopwatch();

			// バックスクリーンを生成
			_backScr = new Bitmap(pictureBox.Width, pictureBox.Height);

			// ボットクラスを読み込む
			_botMetaList = GameLoader.ScanBots();
			// マップファイルを読み込む
			_mapSet = GameLoader.LoadMap(Consts.MAP_FILE);

			// セルイメージのマップを生成
			_cellImageMap = new Dictionary<ECellImage, Bitmap>();
		}

		/// <summary>
		/// 色コードを Color に変換する
		/// </summary>
		/// <param name="colorCode">色コード</param>
		/// <returns>Color</returns>
		private Color ConvColorCode(string colorCode)
		{
			// 色コードが登録されていなければ
			if (!_colorMap.ContainsKey(colorCode))
			{
				// 色に変換
				var colorValue = int.Parse(colorCode, System.Globalization.NumberStyles.AllowHexSpecifier);
				var color = Color.FromArgb(colorValue);
				// 登録
				_colorMap[colorCode] = color;
			}

			// 結果を返す
			return _colorMap[colorCode];
		}

		/// <summary>
		/// セルイメージを初期化する
		/// </summary>
		/// <param name="players">プレイヤー情報のリスト</param>
		private void InitCellImages(List<Player> players)
		{
			// クリア
			_cellImageMap.Clear();

			// 各プレイヤーの色
			var color1 = players.Count > 0 ? ConvColorCode(players[0].ColorCode) : Color.FromArgb(200, 200, 200);
			var color2 = players.Count > 1 ? ConvColorCode(players[1].ColorCode) : Color.FromArgb(200, 200, 200);
			var color3 = players.Count > 2 ? ConvColorCode(players[2].ColorCode) : Color.FromArgb(200, 200, 200);
			var color4 = players.Count > 3 ? ConvColorCode(players[3].ColorCode) : Color.FromArgb(200, 200, 200);

			// セルイメージを生成
			_cellImageMap[ECellImage.FLOOR_NONE]	= ImageUtil.CreateRectCellImage(CellSize, Color.White, 2, Color.Black);
			_cellImageMap[ECellImage.FLOOR_1]		= ImageUtil.CreateRectCellImage(CellSize, color1, 2, Color.Black);
			_cellImageMap[ECellImage.FLOOR_2]		= ImageUtil.CreateRectCellImage(CellSize, color2, 2, Color.Black);
			_cellImageMap[ECellImage.FLOOR_3]		= ImageUtil.CreateRectCellImage(CellSize, color3, 2, Color.Black);
			_cellImageMap[ECellImage.FLOOR_4]		= ImageUtil.CreateRectCellImage(CellSize, color4, 2, Color.Black);
			_cellImageMap[ECellImage.START_1]		= ImageUtil.CreateMeshRectCellImage(CellSize, color1, 2, Color.Black);
			_cellImageMap[ECellImage.START_2]		= ImageUtil.CreateMeshRectCellImage(CellSize, color2, 2, Color.Black);
			_cellImageMap[ECellImage.START_3]		= ImageUtil.CreateMeshRectCellImage(CellSize, color3, 2, Color.Black);
			_cellImageMap[ECellImage.START_4]		= ImageUtil.CreateMeshRectCellImage(CellSize, color4, 2, Color.Black);
			_cellImageMap[ECellImage.WALL]			= ImageUtil.CreateRectCellImage(CellSize, Color.DarkGray, 2, Color.Black);
			_cellImageMap[ECellImage.WIRE_MESH]		= ImageUtil.CreateMeshRectCellImage(CellSize, Color.DarkGray, 2, Color.Black);
			_cellImageMap[ECellImage.PLAYER_1]		= ImageUtil.CreateCircleCellImage(CellSize, Color.White, color1);
			_cellImageMap[ECellImage.PLAYER_2]		= ImageUtil.CreateCircleCellImage(CellSize, Color.White, color2);
			_cellImageMap[ECellImage.PLAYER_3]		= ImageUtil.CreateCircleCellImage(CellSize, Color.White, color3);
			_cellImageMap[ECellImage.PLAYER_4]		= ImageUtil.CreateCircleCellImage(CellSize, Color.White, color4);
		}

		/// <summary>
		/// フレームごとの処理
		/// </summary>
		/// <remarks>
		/// データ更新、およびバックスクリーンの更新を行う
		/// </remarks>
		private void OnFrame()
		{
			// バックスクリーンの Graphics を取得
			using (var brushBack = new SolidBrush(Color.White))
			using (var brushWall = new SolidBrush(Color.White))
			using (var brushPlayer1 = new SolidBrush(Color.White))
			using (var brushPlayer2 = new SolidBrush(Color.White))
			using (var brushFree = new SolidBrush(Color.White))
			using (var g = Graphics.FromImage(_backScr))
			{
				// 背景を塗りつぶし
				g.FillRectangle(brushBack, 0, 0, _backScr.Width, _backScr.Height);

				var map = _game.Map;

				map.Height.Times(y => {
					map.Width.Times(x => {
						var type = map[x, y];
						var colorCode = map.GetCellColor(x, y);

						g.FillRectangle(brushWall, 0, 0, 10, 10);
					});
				});
			}
		}

		/// <summary>
		/// 再描画
		/// </summary>
		private void Redraw()
		{
			// 描画先の Graphics を取得
			using (var g = Graphics.FromImage(pictureBox.Image))
			{
				// バックスクリーンを描画
				g.DrawImage(_backScr, 0, 0);
			}
		}

		/// <summary>
		/// スタートボタン押下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
			// マップ
			var map = _mapSet.First().Value;

			// セルイメージの初期化
			InitCellImages(players);

			// ロジックを生成
			_game = new Game();

			// ロジックを初期化
			_game.Init(_botMetaList, players, map);
			
			// 時間計測リセット
			_stopwatch.Reset();
			// 時間計測スタート（ステータス変更より前）
			_stopwatch.Start();
			// ステータスをプレイ中に変更
			Status = EFormStatus.PLAYING;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			// 初期化
			InitData();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			// プレイ中じゃなければ
			if (Status != EFormStatus.PLAYING)
			{
				// 何もしない
				return;
			}

			// ストップウォッチを止める
			_stopwatch.Stop();

			// 経過時間を取得して加算
			_timerSpan += _stopwatch.ElapsedMilliseconds;

			// リセットして再スタート
			_stopwatch.Reset();
			_stopwatch.Start();

			// フレーム時間を超えている場合
			while (_timerSpan >= MsPerFrame)
			{
				// フレーム処理
				OnFrame();

				// 再描画
				Redraw();

				// 時間を減らす
				_timerSpan -= MsPerFrame;
			}
		}
}
