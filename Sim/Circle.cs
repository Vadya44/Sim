using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace Sim
{
	public class Circle
	{
		int _x;
		int _y;
		public Circle()
		{
			_x = 720 / 2;
			_y = 1280 / 2;
		}
		public int X
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
			}
		}
		public int Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}
		public int Radius
		{
			get
			{
				int res = 360 - (int)(720 * 0.06);
				return res;
			}
		}
		public void Draw(Canvas canvas)
		{
			
			Paint p = new Paint();
			p.SetStyle(Paint.Style.Fill);
			p.AntiAlias = true;
			p.Color = new Color(228, 253, 225);
			p.StrokeWidth = 2;
			canvas.DrawCircle(_x * GameView.Factor,
			                  _y *GameView.Factor, Radius * GameView.Factor, p);
		}
	}
}
