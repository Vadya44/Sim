using System;
using Android.Graphics;
using System.Collections.Generic;
using System.Timers;


namespace Sim
{
    public static class Game_Solo
    {
        // With clicks
        private static string _winner;
        private static int _ind1, _ind2, _ind3;
        private static bool _endGameFlag = false;
        private static bool _blockFlag = false;
        public static Timer aTimer = new Timer();
        private static int _number;
        public static Line nLine = new Line(new Point(0, 0, Color.AliceBlue),
            new Point(0, 0, Color.AliceBlue));
        private static Line[] _plArr;
        private static Line[] _botArr;
        private static Line[] _usedArr;
        private static List<Line> _pllines;
        private static List<Line> _botLines;
        private static List<Line> _usedLines;
        private static Point[] _points;
        private static bool _isHard;
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Circle _circle = new Circle();
            _circle.Draw(canvas);
            Methods.DrawPoints(_points, canvas, _circle);
            Paints.DrawButton(canvas, 375, 1050, 690, 1150);
            Paints.DrawText(canvas, 385, 1120, "Concede", 75, 50);
            if (_plArr != null && _botArr != null)
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
            if (_endGameFlag)
            {
                Paints.DrawButtonM(canvas, 100, 40, 620, 200);
                Paints.DrawTextM(canvas, 140, 150, "Game over", 90, 70);
                if (_winner == "bot")
                {
                    for (int i = 0; i < _plArr.Length; i++)
                        if (i == _ind1 || i == _ind2 || i == _ind3)
                        canvas.DrawLine(_plArr[i].p1.X * GameView.Factor,
                          _plArr[i].p1.Y * GameView.Factor,
                         _plArr[i].p2.X * GameView.Factor,
                         GameView.Factor * _plArr[i].p2.Y, Paints.triangle);
                }
                if (_winner == "player")
                {
                    for (int j = 0; j < _botArr.Length; j++)
                        if (j == _ind1 || j == _ind2 || j == _ind3)
                        canvas.DrawLine(_botArr[j].p1.X * GameView.Factor,
                          _botArr[j].p1.Y * GameView.Factor,
                         _botArr[j].p2.X * GameView.Factor,
                         GameView.Factor * _botArr[j].p2.Y, Paints.triangle);
                }
            }
        }
        public static void Show(bool isHard, int number)
        {
            _number = number;
            _isHard = isHard;
            _pllines = new List<Line>();
            _botLines = new List<Line>();
            _usedLines = new List<Line>();
            Circle _circle = new Circle();
            _points = Methods.CreatePoints(number, _circle, 720);
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
            _endGameFlag = false;
            _blockFlag = false;
    }
        public static void JustTouch(float x, float y)
        {
            GameView.Instance.Invalidate();
            if (x > 375 && x < 690 && y > 1050 && y < 1150 && !_blockFlag)
            {
                Hide();
                Result_Solo.Show(false);
            }
        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            GameView.Instance.Invalidate();
            if (x1 > 375 && x1 < 690 && y1 > 1050 && y1 < 1150 &&
                x2 > 375 && x2 < 690 && y2 > 1050 && y2 < 1150 && !_blockFlag)
            {
                Hide();
                Result_Solo.Show(false);
            }
            Line buff = Methods.DrawLine(x1, y1, x2, y2, _points);
            if (buff != nLine && !_usedLines.Contains(buff) && !_blockFlag)
            {
                _pllines.Add(buff);
                _pllines.Add(ReverseLine(buff));
                _plArr = _pllines.ToArray();
                if (IsBotWin() && !_endGameFlag)
                {
                    _endGameFlag = true;
                    _blockFlag = true;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventFalse);
                    aTimer.Interval = 3000;
                    aTimer.Enabled = true;
                }
                if (IsPlayerWin() && !_endGameFlag)
                {
                    _endGameFlag = true;
                    _blockFlag = true;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventTrue);
                    aTimer.Interval = 3000;
                    aTimer.Enabled = true;
                }
                _usedLines.Add(buff);
                _usedLines.Add(ReverseLine(buff));
                TurnSender();
                if (IsBotWin() && _endGameFlag)
                {
                    _endGameFlag = true;
                    _blockFlag = true;
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventFalse);
                    aTimer.Interval = 3000;
                }
                if (IsPlayerWin() && !_endGameFlag)
                {
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
            Result_Solo.Show(true);
        }
        private static void OnTimedEventFalse(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            Hide();
            Result_Solo.Show(false);
        }
        public static void TurnSender()
        {
            Line buffBot;
            _usedArr = _usedLines.ToArray();
            if (_isHard == false)
            {
                for (int i = 0; i < _points.Length; i++)
                    for (int j = 0; j < _points.Length; j++)
                    {
                        bool isSuit = true;
                        bool rigthTurn = true;
                        if (i != j)
                        {
                            Line buff = new Line(_points[i],
                                         _points[j]);
                            if (_botArr != null)
                                for (int l = 0; l < _botArr.Length; l++)
                                    for (int z = 0; z < _botArr.Length; z++)
                                        if (IsTriangle(_botArr[z], _botArr[l], buff) &&
                                            l < _points.Length * 0.9) rigthTurn = false;
                            if (!rigthTurn) continue;
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
                                _usedLines.Add(ReverseLine(buffBot));
                                _botLines.Add(buffBot);
                                _botLines.Add(ReverseLine(buffBot));
                                _botArr = _botLines.ToArray();
                                return;
                            }
                        }
                    }
                return;
            }
            if (_isHard == true)
            {
                Random rnd = new Random();
                bool endFlag = false;
                int counter = 0;
                do
                {
                    counter++;
                    bool isSuit = true;
                    bool rigthTurn = true;
                    int i = rnd.Next(0, _points.Length - 1);
                    int j = rnd.Next(0, _points.Length - 1);
                    if (i != j)
                    {
                        Line buff = new Line(_points[i],
                                     _points[j]);
                        if (_botArr != null)
                            for (int l = 0; l < _botArr.Length; l++)
                                for (int z = 0; z < _botArr.Length; z++)
                                    if (IsTriangle(_botArr[z], _botArr[l], buff))
                                    {
                                        _isHard = false;
                                        TurnSender();
                                        _isHard = true;
                                        return;
                                    }
                        if (!rigthTurn) continue;
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
                            endFlag = true;
                            buffBot = buff;
                            _usedLines.Add(buffBot);
                            _usedLines.Add(ReverseLine(buffBot));
                            _botLines.Add(buffBot);
                            _botLines.Add(ReverseLine(buffBot));
                            _botArr = _botLines.ToArray();
                            return;
                        }
                    }
                } while (endFlag);
                return;
            }


        }
        public static bool IsBotWin()
        {
            if (_plArr != null)
                for (int i = 0; i < _plArr.Length; i++)
                    for (int j = 0; j < _plArr.Length; j++)
                        for (int k = 0; k < _plArr.Length; k++)
                            if (i != j && j != k && i != k)
                            {
                                if (IsTriangle(_plArr[i],
                                          _plArr[j], _plArr[k]))
                                {
                                    _winner = "bot";
                                    _ind1 = i;
                                    _ind2 = j;
                                    _ind3 = k;
                                    return true;
                                }
                            }
            return false;
        }
        public static bool IsPlayerWin()
        {
            if (_botArr != null)
                for (int i = 0; i < _botArr.Length; i++)
                    for (int j = 0; j < _botArr.Length; j++)
                        for (int k = 0; k < _botArr.Length; k++)
                            if (i != j && j != k && i != k)
                            {
                                if (IsTriangle(_botArr[i],
                                          _botArr[j], _botArr[k]))
                                {
                                    _winner = "player";
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
