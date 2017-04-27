using System;
using Android.Graphics;
using System.Collections.Generic;
using Android.Graphics.Drawables;
namespace Sim
{
    public static class Game_Solo
    {
        // With clicks
        private static Line[] _lArr;
        private static List<Line> _lines;
        static Point[] _points;
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Circle _circle = new Circle();
            _circle.Draw(canvas);
            Methods.DrawPoints(_points, canvas, _circle);
            Paints.DrawButton(canvas, 375, 1050, 690, 1150);
            Paints.DrawText(canvas, 385, 1120, "Concede", 75, 50);
            if (_lArr != null) 
            {
                for (int i = 0; i < _lArr.Length; i++)
                canvas.DrawLine(_lArr[i].p1.X * GameView.Factor, 
                  _lArr[i].p1.Y * GameView.Factor,
                 _lArr[i].p2.X * GameView.Factor, 
                 GameView.Factor * _lArr[i].p2.Y, Paints.Circ);
            }
        }
        public static void Show()
        {
            _lines = new List<Line>();
            Circle _circle = new Circle();
            _points = Methods.CreatePoints(10, _circle, 720);
            GameView.activeScene = "Game_Solo";
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            _lines.Clear();
            _lArr = null;
            GameView.DrawEvent -= OnDraw;
        }
        public static void JustTouch(float x, float y)
        {
            if (x > 375 && x < 690 && y > 1050 && y < 1150)
            {
                Hide();
                Result_Solo.Show();
            }
        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            if (x1 > 375 && x1 < 690 && y1 > 1050 && y1 < 1150 &&
                x2 > 375 && x2 < 690 && y2 > 1050 && y2 < 1150)
            {
                Hide();
                Result_Solo.Show();
            }
            Line buff = Methods.DrawLine(x1, y1, x2, y2, _points);
            if (buff != null)
            {
                _lines.Add(buff);
                _lArr = _lines.ToArray();
            }
            GameView.Instance.Invalidate();
        }
    }
}
