using System;
using Android.Graphics;
namespace Sim
{
	public static class Authentication
	{
		// With clicks
		public static void OnDraw(Canvas canvas)
		{

		}
		public static void Show()
		{
            GameView.activeScene = "Authentication";
			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
