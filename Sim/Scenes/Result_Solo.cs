using System;
using Android.Graphics;
namespace Sim
{
	public class Result_Solo
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
