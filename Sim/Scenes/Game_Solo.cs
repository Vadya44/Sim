using System;
using Android.Graphics;
using System.Collections.Generic;
using Android.Util;
namespace Sim
{
	public static class Game_Solo
	{
		// With clicks
		public static Line nLine = new Line(new Point(0, 0, Color.AliceBlue),
		    new Point(0, 0, Color.AliceBlue));
		public static Line[] _plArr;
		public static Line[] _botArr;
		public static Line[] _usedArr;
		public static List<Line> _pllines;
		public static List<Line> _botLines;
		public static List<Line> _usedLines;
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
				for (int j = 0; j < _botArr.Length; j++)
					canvas.DrawLine(_botArr[j].p1.X * GameView.Factor,
					  _botArr[j].p1.Y * GameView.Factor,
					 _botArr[j].p2.X * GameView.Factor,
					 GameView.Factor * _botArr[j].p2.Y, Paints.botSoloLine);
			}
		}
		public static void Show()
		{
			_pllines = new List<Line>();
			_botLines = new List<Line>();
			_usedLines = new List<Line>();
			Circle _circle = new Circle();
			_points = Methods.CreatePoints(5, _circle, 720);
			GameView.activeScene = "Game_Solo";
			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			_pllines.Clear();
			_plArr = null;
			_botLines.Clear();
			_botArr = null;
			_usedLines.Clear();
			GameView.DrawEvent -= OnDraw;
		}
		public static void JustTouch(float x, float y)
		{
			GameView.Instance.Invalidate();
			if (x > 375 && x < 690 && y > 1050 && y < 1150)
			{
				Hide();
				Result_Solo.Show(false);
			}
		}
		public static void MovedTouch(float x1, float y1, float x2, float y2)
		{
			GameView.Instance.Invalidate();
			if (x1 > 375 && x1 < 690 && y1 > 1050 && y1 < 1150 &&
			    x2 > 375 && x2 < 690 && y2 > 1050 && y2 < 1150)
			{
				Hide();
				Result_Solo.Show(false);
			}
			Line buff = Methods.DrawLine(x1, y1, x2, y2, _points);
			if (buff != nLine)
			{
				_pllines.Add(buff);
				_plArr = _pllines.ToArray();
				_usedLines.Add(buff);
				TurnSender();
				if(IsBotWin())
				{
					Hide();
					Result_Solo.Show(false);
				}
				if(IsPlayerWin())
				{
					Hide();
					Result_Solo.Show(true);
				}
			}
			GameView.Instance.Invalidate();
		}
		public static void TurnSender()
		{
			Line buffBot;
			_usedArr = _usedLines.ToArray();
			for (int i = 0; i < _points.Length; i++)
				for (int j = 0; j < _points.Length; j++)
				{
					bool isSuit = true;
					if (i != j)
					{
						Line buff = new Line(_points[i],
								     _points[j]);
						for (int k = 0; k < _usedArr.Length; k++)
						{
							if (buff == _usedArr[k])
							{
								isSuit = false;
								break;
							}
						}
						if (isSuit)
						{
							buffBot = buff;
							_usedLines.Add(buffBot);
							_botLines.Add(buffBot);
							_botArr = _botLines.ToArray();
							return;
						}
					}
				}
			return;

		}
		public static bool IsBotWin()
		{
			for (int i = 0; i < _plArr.Length; i++)
				for (int j = 0; j < _plArr.Length; j++)
					for (int k = 0; k < _plArr.Length;k++)
					if (i != j && j != k && i != k)
					{
							if (IsTriangle(_plArr[i],
								      _plArr[j], _plArr[k]))
								return true;
					}
			return false;
		}
		public static bool IsPlayerWin()
		{
			for (int i = 0; i < _botArr.Length; i++)
				for (int j = 0; j < _botArr.Length; j++)
					for (int k = 0; k < _botArr.Length; k++)
						if (i != j && j != k && i != k)
						{
							if (IsTriangle(_botArr[i],
									  _botArr[j], _botArr[k]))
								return true;
						}
			return false;
		}
		public static bool IsTriangle(Line l1, Line l2, Line l3)
		{
			if (l1.p2.X == l2.p1.X &&
			   l2.p2.Y == l3.p1.Y &&
			   l3.p2.X == l1.p1.X)
				return true;
			if (l1.p2.X == l3.p1.X &&
			   l3.p2.Y == l2.p1.Y &&
			   l2.p2.X == l1.p1.X)
				return true;
			if (l2.p2.X == l1.p1.X &&
			   l1.p2.Y == l3.p1.Y &&
			   l3.p2.X == l2.p1.X)
				return true;
			if (l2.p2.X == l3.p1.X &&
			   l3.p2.Y == l1.p1.Y &&
			   l1.p2.X == l2.p1.X)
				return true;
			if (l3.p2.X == l1.p1.X &&
			   l1.p2.Y == l2.p1.Y &&
			   l2.p2.X == l3.p1.X)
				return true;
			if (l3.p2.X == l2.p1.X &&
			   l2.p2.Y == l1.p1.Y &&
			   l1.p2.X == l3.p1.X)
				return true;
			return false;
		}
	}
}
