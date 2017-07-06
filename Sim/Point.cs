using Android.Graphics;


namespace Sim
{
    public class Point
    {
        bool _used;
        int _x;
        int _y;
        Color _color;
        public Point(int px, int py, Color color)
        {
            _x = px;
            _y = py;
            _color = color;
            _used = false;
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
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
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
        public bool Used
        {
            get
            {
                return _used;
            }
            set
            {
                _used = value;
            }
        }
        public void Draw(Canvas canvas)
        {

            Paint p = new Paint();
            p.SetStyle(Paint.Style.Fill);
            p.AntiAlias = true;
            p.Color = _color;
            p.StrokeWidth = 2;
            canvas.DrawCircle(_x * GameView.Factor,
                              GameView.Factor * _y,
                              720 / 50 * GameView.Factor, p);
        }

    }
}
