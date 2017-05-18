using System;
using Android.Graphics;
using System.Collections.Generic;
using System.Timers;


namespace Sim
{
    public static class Multiplayer
    {
        // With clicks
        private static bool _redWinner;
        private static bool _bluesTurn;
        private static bool _blueWinner;
        private static int _ind1, _ind2, _ind3;
        private static bool _endGameFlag = false;
        private static bool _blockFlag = false;
        public static Timer aTimer = new Timer();
        public static Line nLine = new Line(new Point(0, 0, Color.AliceBlue),
            new Point(0, 0, Color.AliceBlue));
        private static Line[] _firstArr;
        private static Line[] _secondArr;
        private static List<Line> _firstLines;
        private static List<Line> _secondLines;
        private static List<Line> _usedLines;
        private static Point[] _points;
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Circle _circle = new Circle();
            _circle.Draw(canvas);
            Methods.DrawPoints(_points, canvas, _circle);
            if (_firstArr != null)
            
                for (int i = 0; i < _firstArr.Length; i++)
                    canvas.DrawLine(_firstArr[i].p1.X * GameView.Factor,
                      _firstArr[i].p1.Y * GameView.Factor,
                     _firstArr[i].p2.X * GameView.Factor,
                     GameView.Factor * _firstArr[i].p2.Y, Paints.plSoloLine);
             if (_secondArr != null)
                for (int j = 0; j < _secondArr.Length; j++)
                    canvas.DrawLine(_secondArr[j].p1.X * GameView.Factor,
                      _secondArr[j].p1.Y * GameView.Factor,
                     _secondArr[j].p2.X * GameView.Factor,
                     GameView.Factor * _secondArr[j].p2.Y, Paints.botSoloLine);

            
            if (_endGameFlag)
            {
                Paints.DrawButtonM(canvas, 100, 40, 620, 200);
                if (_blueWinner && _firstArr != null)
                {
                    for (int i = 0; i < _firstArr.Length; i++)
                        if (i == _ind1 || i == _ind2 || i == _ind3)
                            canvas.DrawLine(_firstArr[i].p1.X * GameView.Factor,
                              _firstArr[i].p1.Y * GameView.Factor,
                             _firstArr[i].p2.X * GameView.Factor,
                             GameView.Factor * _firstArr[i].p2.Y, Paints.triangle);
                    Paints.DrawTextM(canvas, 180, 150, "Red win", 90, 70);
                }
                if (_redWinner && _secondArr != null)
                {
                    for (int j = 0; j < _secondArr.Length; j++)
                        if (j == _ind1 || j == _ind2 || j == _ind3)
                            canvas.DrawLine(_secondArr[j].p1.X * GameView.Factor,
                              _secondArr[j].p1.Y * GameView.Factor,
                             _secondArr[j].p2.X * GameView.Factor,
                             GameView.Factor * _secondArr[j].p2.Y, Paints.triangle);
                    Paints.DrawTextM(canvas, 180, 150, "Blue win", 90, 70);
                }
            }
        }
        public static void Show()
        {
            Circle _circle = new Circle();
            _points = Methods.CreatePoints(8, _circle, 720);
            _redWinner = false;
            _blueWinner = false;
            _bluesTurn = true;
            _firstLines = new List<Line>();
            _secondLines = new List<Line>();
            _usedLines = new List<Line>();
            GameView.activeScene = "Multiplayer";
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            GameView.DrawEvent -= OnDraw;
            _firstLines.Clear();
            _firstArr = null;
            _secondLines.Clear();
            _secondArr = null;
            _usedLines.Clear();
            _endGameFlag = false;
            _blockFlag = false;
        }
        public static void JustTouch(float x, float y)
        {
            GameView.Instance.Invalidate();
        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            GameView.Instance.Invalidate();
            Line buff = Methods.DrawLine(x1, y1, x2, y2, _points);
            if (buff != nLine && !_usedLines.Contains(buff) && !_blockFlag)
            {
                if (_bluesTurn)
                {
                    _firstLines.Add(buff);
                    _firstLines.Add(ReverseLine(buff));
                    _firstArr = _firstLines.ToArray();
                    _bluesTurn = false;
                    GameView.Instance.Invalidate();
                }
                else
                {
                    _secondLines.Add(buff);
                    _secondLines.Add(ReverseLine(buff));
                    _secondArr = _secondLines.ToArray();
                    _bluesTurn = true;
                    GameView.Instance.Invalidate();
                };
                if (IsSecondWin() && !_endGameFlag)
                {
                    GameView.Instance.Invalidate();
                    _endGameFlag = true;
                    _blockFlag = true;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventFalse);
                    aTimer.Interval = 3000;
                    aTimer.Enabled = true;
                }
                if (IsFirstWin() && !_endGameFlag)
                {
                    GameView.Instance.Invalidate();
                    _endGameFlag = true;
                    _blockFlag = true;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventTrue);
                    aTimer.Interval = 3000;
                    aTimer.Enabled = true;
                }
                _usedLines.Add(buff);
                _usedLines.Add(ReverseLine(buff));
                if (IsSecondWin() && _endGameFlag)
                {
                    GameView.Instance.Invalidate();
                    _endGameFlag = true;
                    _blockFlag = true;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventFalse);
                    aTimer.Interval = 3000;
                }
                if (IsFirstWin() && !_endGameFlag)
                {
                    GameView.Instance.Invalidate();
                    _endGameFlag = true;
                    _blockFlag = true;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventTrue);
                    aTimer.Interval = 3000;
                    aTimer.Enabled = true;
                }
            }
            GameView.Instance.Invalidate();
        }
        private static void OnTimedEventTrue(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            Hide();
            MainMenu.Show();
        }
        private static void OnTimedEventFalse(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            Hide();
            MainMenu.Show();
        }
        public static bool IsSecondWin()
        {
            if (_firstArr != null)
                for (int i = 0; i < _firstArr.Length; i++)
                    for (int j = 0; j < _firstArr.Length; j++)
                        for (int k = 0; k < _firstArr.Length; k++)
                            if (i != j && j != k && i != k)
                            {
                                if (IsTriangle(_firstArr[i],
                                          _firstArr[j], _firstArr[k]))
                                {
                                    _blueWinner = true;
                                    _ind1 = i;
                                    _ind2 = j;
                                    _ind3 = k;
                                    return true;
                                }
                            }
            return false;
        }
        public static bool IsFirstWin()
        {
            if (_secondArr != null)
                for (int i = 0; i < _secondArr.Length; i++)
                    for (int j = 0; j < _secondArr.Length; j++)
                        for (int k = 0; k < _secondArr.Length; k++)
                            if (i != j && j != k && i != k)
                            {
                                if (IsTriangle(_secondArr[i],
                                          _secondArr[j], _secondArr[k]))
                                {
                                    _redWinner = true;
                                    _ind1 = i;
                                    _ind2 = j;
                                    _ind3 = k;
                                    return true;
                                }
                            }
            return false;
        }
        public static bool IsTriangle(Line l1, Line l2, Line l3)
        {
            if (TriangleCheck(l1, l2, l3)) return true;
            if (TriangleCheck(l1, l3, l2)) return true;
            if (TriangleCheck(l2, l1, l3)) return true;
            if (TriangleCheck(l2, l3, l1)) return true;
            if (TriangleCheck(l3, l1, l2)) return true;
            if (TriangleCheck(l3, l2, l1)) return true;
            return false;
        }

        public static bool TriangleCheck(Line l1, Line l2, Line l3)
        {
            return (l1.p2.X == l2.p1.X &&
                l1.p2.Y == l2.p1.Y &&
                l2.p2.X == l3.p1.X &&
                l2.p2.Y == l3.p1.Y &&
                l3.p2.X == l1.p1.X &&
                l3.p2.Y == l1.p1.Y);
        }

        public static Line ReverseLine(Line line)
        {
            if (line != nLine)
                return new Line(line.p2, line.p1);
            else return nLine;
        }
    }
}
