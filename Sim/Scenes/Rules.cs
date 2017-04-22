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
			
			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
