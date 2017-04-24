using System;
using Android.Graphics;
namespace Sim
{
	public static class LeaderBoard
	{
		// With clicks
		public static void OnDraw(Canvas canvas)
		{

		}
		public static void Show()
		{
            GameView.activeScene = "LeaderBoard";
			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
