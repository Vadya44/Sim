using System;
using Android.Graphics;
namespace Sim
{
	public class Result_Ranked
	{
		static void OnDraw(Canvas canvas)
		{
			Paints.DrawRes(canvas, true);
			Paints.DrawButton(canvas, 235, 1000, 485, 1150);
			Paints.DrawText(canvas, 250, 1100, "Main menu", 90, 60);
			Paints.DrawButton(canvas, 235, 800, 485, 950);
			Paints.DrawText(canvas, 250, 900, "New game", 90, 60);
			Paints.DrawText(canvas, 380, 650, "CHANGE", 60, 40);
			Paints.DrawText(canvas, 380, 690, "NEW RANK", 60, 40);
		}
		static void Show()
		{
			GameView.DrawEvent += OnDraw;
		}
		static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
