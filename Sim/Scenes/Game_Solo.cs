using System;
using Android.Graphics;
using System.Collections.Generic;
namespace Sim
{
    public static class Game_Solo
    {
        // With clicks
        public static Line[] _plArr;
		public static Line[] _botArr;
        public static List<Line> _pllines;
		public static List<Line> _botLines;
        public static Point[] _points;
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Circle _circle = new Circle();
            _circle.Draw(canvas);
            Methods.DrawPoints(_points, canvas, _circle);
            Paints.DrawButton(canvas, 375, 1050, 690, 1150);
            Paints.DrawText(canvas, 385, 1120, "Concede", 75, 50);
            if (_plArr != null) 
            {
                for (int i = 0; i < _plArr.Length; i++)
                canvas.DrawLine(_plArr[i].p1.X * GameView.Factor, 
                  _plArr[i].p1.Y * GameView.Factor,
                 _plArr[i].p2.X * GameView.Factor, 
                 GameView.Factor * _plArr[i].p2.Y, Paints.plSoloLine);
				for (int i = 0; i < _botArr.Length; i++)
					canvas.DrawLine(_botArr[i].p1.X * GameView.Factor,
					  _botArr[i].p1.Y * GameView.Factor,
					 _botArr[i].p2.X * GameView.Factor,
					 GameView.Factor * _botArr[i].p2.Y, Paints.botSoloLine);
            }
        }
        public static void Show()
        {
            _pllines = new List<Line>();
			_botLines = new List<Line>();
            Circle _circle = new Circle();
            _points = Methods.CreatePoints(10, _circle, 720);
            GameView.activeScene = "Game_Solo";
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            _pllines.Clear();
            _plArr = null;
			_botLines.Clear();
			_botArr = null;
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
                _pllines.Add(buff);
                _plArr = _pllines.ToArray();
		_botLines.Add(GameLogicSolo.turnSender(_points, _plArr));
				_botArr = _botLines.ToArray();
            }
            GameView.Instance.Invalidate();
        }
    }
}
