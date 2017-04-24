using System;
using Android.Graphics;
namespace Sim
{
	public static class Result_Solo
	{
		// With clicks
		public static void OnDraw(Canvas canvas)
		{
			Paints.DrawRes(canvas, true);
			Paints.DrawButton(canvas, 135, 1000, 585, 1150);
			Paints.DrawText(canvas, 138, 1100, "Main menu", 90, 60);
			Paints.DrawButton(canvas, 135, 800, 585, 950);
			Paints.DrawText(canvas, 148, 900, "New game", 90, 60);
		}
		public static void Show()
		{
            GameView.activeScene = "Result_Solo";
			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
