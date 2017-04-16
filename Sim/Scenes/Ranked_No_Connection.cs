using System;
using Android.Graphics;
namespace Sim
{
	public class Ranked_No_Connection
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
