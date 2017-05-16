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
        static Point _isRightnow;
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
        public static Point[] CreatePoints(int number, Circle circle, int px)
        {
            Color clr = new Color(47, 6, 1);
            _arr = new Point[number];
            for (int i = 0, alpha = 0; i < number; i++)
            {
                alpha += 360 / number;
                int rx = circle.X - circle.X;
                int ry = circle.Y + circle.Radius - circle.Y;
                double c = Math.Cos(Methods.DegreeToRadian(alpha));
                double s = Math.Sin(Methods.DegreeToRadian(alpha));
                int x1 = (int)(circle.X + rx * c - ry * s);
                int y1 = (int)(circle.Y + rx * s + ry * c);
                _arr[i] = new Point(x1, y1, clr);
            }
            return _arr;
        }
        public static void DrawPoints(Point[] arr, Canvas canvas, Circle circle)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Draw(canvas);
            }
        }
        public static Line DrawLine(float x1, float y1, float x2,
            float y2, Point[] arr)
        {
            Line res;
            Point buf1 = null;
            Point buf2 = null;
            for (int i = 0; i < arr.Length; i++)
            {
                if (buf1 == null &&
                    x1 >= (arr[i].X - 60) &&
                    x1 <= (arr[i].X + 60) &&
                    y1 >= (arr[i].Y - 60) &&
                    y1 <= (arr[i].Y + 60))
                    buf1 = arr[i];
            }
            for (int i = 0; i < arr.Length; i++)
                if (buf1 != null && buf2 == null &&
                    x2 >= (arr[i].X - 60) &&
                    x2 <= (arr[i].X + 60) &&
                    y2 >= (arr[i].Y - 60) &&
                    y2 <= (arr[i].Y + 60))
                {
                    buf2 = arr[i];
                    break;
                }


            if (buf1 != null && buf2 != null 
                && (buf1.X != buf2.X || buf1.Y != buf2.Y))
            {
                res = new Line(buf1, buf2);
                return res;
            }

            else return Game_Solo.nLine;
        }
    }
}
