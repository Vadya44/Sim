using System;
using Android.Graphics;
namespace Sim
{
	public static class Game_Solo
	{
		// With clicks
		private static Circle _circle;
		public static void OnDraw(Canvas canvas)
		{
			_circle = new Circle();
			_circle.Draw(canvas);
			Methods.DrawPoints(10, canvas, _circle);
		}
		public static void Show()
		{
           		GameView.activeScene = "Game_Solo";
			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
        public static void JustTouch(float x, float y)
        {

        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {

        }
    }
}
