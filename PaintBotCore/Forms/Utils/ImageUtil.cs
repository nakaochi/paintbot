using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Forms.Utils
{
	/// <summary>
	/// イメージのユーティリティクラス
	/// </summary>
	public static class ImageUtil
	{

		/// <summary>
		/// 矩形のセルイメージを生成する
		/// </summary>
		/// <param name="cellSize">セルサイズ（一辺のピクセル数）</param>
		/// <param name="colorFill">背景色</param>
		/// <param name="borderSize">ボーダーサイズ</param>
		/// <param name="colorBorder">ボーダー色</param>
		/// <returns></returns>
		public static Bitmap CreateRectCellImage(int cellSize, Color colorFill, int borderSize, Color colorBorder)
		{
			// 結果を返す
			return CreateCellImage(cellSize, g =>
			{
				// マージンサイズ
				int margin = 1;

				// リソースを準備
				using (var brushFill = new SolidBrush(colorFill))
				using (var penBorder = new Pen(colorBorder, borderSize))
				{
					// 塗りつぶし
					g.FillRectangle(brushFill, margin, margin, cellSize - margin * 2, cellSize - margin * 2);
					// ボーダー描画
					g.DrawRectangle(penBorder, margin, margin, cellSize - margin * 2, cellSize - margin * 2);
				}
			});
		}

		/// <summary>
		/// 矩形（メッシュ）のセルイメージを生成する
		/// </summary>
		/// <param name="cellSize">セルサイズ（一辺のピクセル数）</param>
		/// <param name="colorFill">背景色</param>
		/// <param name="borderSize">ボーダーサイズ</param>
		/// <param name="colorBorder">ボーダー色</param>
		/// <returns></returns>
		public static Bitmap CreateMeshRectCellImage(int cellSize, Color colorFill, int borderSize, Color colorBorder)
		{
			// 結果を返す
			return CreateCellImage(cellSize, g =>
			{
				// マージンサイズ
				int margin = 1;

				// リソースを準備
				using (var brushFill = new HatchBrush(HatchStyle.OutlinedDiamond, Color.Black, colorFill))
				using (var penBorder = new Pen(colorBorder, borderSize))
				{
					// 塗りつぶし
					g.FillRectangle(brushFill, margin, margin, cellSize - margin * 2, cellSize - margin * 2);
					// ボーダー描画
					g.DrawRectangle(penBorder, margin, margin, cellSize - margin * 2, cellSize - margin * 2);
				}
			});
		}

		/// <summary>
		/// 円形のセルイメージを生成する
		/// </summary>
		/// <param name="cellSize">セルサイズ（一辺のピクセル数）</param>
		/// <param name="colorFill">背景色</param>
		/// <param name="colorBorder">ボーダー色</param>
		/// <returns></returns>
		public static Bitmap CreateCircleCellImage(int cellSize, Color colorFill, Color colorBorder)
		{
			// 結果を返す
			return CreateCellImage(cellSize, g =>
			{
				// マージンサイズ
				int margin = 8;
				// ボーダーサイズ
				int borderSize = 4;

				// リソースを準備
				using (var brushFill = new SolidBrush(colorFill))
				using (var penBorder = new Pen(colorBorder, borderSize))
				{
					// 塗りつぶし
					g.FillEllipse(brushFill, margin, margin, cellSize - margin * 2, cellSize - margin * 2);
					// ボーダー描画
					g.DrawEllipse(penBorder, margin, margin, cellSize - margin * 2, cellSize - margin * 2);
				}
			});
		}

		/// <summary>
		/// セルイメージを生成する
		/// </summary>
		/// <param name="cellSize">セルサイズ（一辺のピクセル数）</param>
		/// <param name="act">Graphics に描画する処理</param>
		/// <returns>Bitmap</returns>
		public static Bitmap CreateCellImage(int cellSize, Action<Graphics> act)
		{
			// 画像を生成
			var bmp = new Bitmap(cellSize, cellSize);

			// リソースの準備
			using (var brushTrans = new SolidBrush(Color.Transparent))
			using (var g = Graphics.FromImage(bmp))
			{
				// 透過色で塗りつぶし
				g.FillRectangle(brushTrans, 0, 0, cellSize, cellSize);

				// 描画処理
				act(g);
			}

			// 結果を返す
			return bmp;
		}
	}
}
