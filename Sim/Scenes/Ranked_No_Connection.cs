﻿using System;
using Android.Graphics;
namespace Sim
{
	public class Ranked_No_Connection
	{
		public static void OnDraw(Canvas canvas)
		{

		}
		public static void Show()
		{
            GameView.activeScene = "Ranked_No_Connection";
			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
