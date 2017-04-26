using System;

using Android.Animation;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
namespace Sim
{
	public static class Methods
	{
		static int _counter;
		static Point _isRightnow;
		static Point _buff;
		static Point[] _arr;
		private static bool Validate(int x, int y)
		{
			for (int i = 0; i < _arr.Length; i++)
			{
				double d = Math.Sqrt(Math.Pow(_arr[i].X - x, 2) + Math.Pow(_arr[i].Y - y, 2));
				if (d >= 100)
				{
					_isRightnow = _arr[i];
					return true;
				}
			}
			return false;
		}
		private static double DegreeToRadian(double angle)
		{
			return Math.PI * angle / 180.0;
		}
		static Random rnd = new Random();
		public static Point[] CreatePoints(int number, Circle circle,int px)
		{
			if (_counter != 0) return _arr;
			var clr1 = new Color(244, 91, 105);
			var clr2 = new Color(69, 105, 144);
			_arr = new Point[number];
			int max_delta = 360 / number;
			int min_delta = 30;
			for (int i = 0, alpha = 0; i < number; i++)
			{
				alpha += rnd.Next(min_delta, max_delta);
				int rx = circle.X - circle.X;
				int ry = circle.Y + circle.Radius - circle.Y;
				double c = Math.Cos(Methods.DegreeToRadian(alpha));
				double s = Math.Sin(Methods.DegreeToRadian(alpha));
				int x1 = (int)(circle.X + rx * c - ry * s);
				int y1 = (int)(circle.Y + rx * s + ry * c);
				Color clr = i % 2 == 0 ? clr1 : clr2;
				_arr[i] = new Point(x1, y1, clr);
			}
			return _arr;
		}
		public static void DrawPoints(int numb, Canvas canvas,Circle circle)
		{
			var arr = Methods.CreatePoints(numb, circle, 720);
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Draw(canvas);
			}
		}
		public static void DrawLine(int x, int y, Canvas canvas)
		{
			if (Validate(x, y))
			{
				Paint p = new Paint();
				p.StrokeWidth = 8;
				if (++_counter % 2 == 1)
				{
					_buff = _isRightnow;
					return;
				}
				if (_counter % 4 == 2) p.Color = Color.Red;
				p.Color = Color.Blue;
				canvas.DrawLine(_buff.X, _buff.Y, _isRightnow.X, _isRightnow.Y, p);
			}
			else return;
		}
	}
}
