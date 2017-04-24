using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
namespace Sim
{
	public static class Rules
	// With clicks
	{
		
		public static void OnDraw(Canvas canvas)
		{
			
		}
		public static void Show()
		{
            GameView.activeScene = "Rules";
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
