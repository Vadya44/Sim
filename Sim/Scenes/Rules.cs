using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
namespace Sim
{
	public class Rules

	{
		
		static void OnDraw(Canvas canvas)
		{
			
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
