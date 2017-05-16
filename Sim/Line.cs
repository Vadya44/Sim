namespace Sim
{
    public struct Line
    {
        private Point _p1;
        private Point _p2;
        public static bool operator !=(Line l1, Line l2)
        {
            if (l1 == null || l2 == null) return false;
            return !(l1 == l2);
        }
        public static bool operator ==(Line l1, Line l2)
        {
            if (l1 == null || l2 == null) return false;
            return ((l1._p1.X == l2._p1.X) &&
                (l1._p1.Y == l2._p1.Y) &&
                (l1._p2.X == l2._p2.X) &&
                (l1._p2.Y == l2._p2.Y));
        }
        public Line(Point p1, Point p2)
        {
            _p1 = p1;
            _p2 = p2;

        }
        public Point p1
        {
            get
            {
                return _p1;
            }
            set
            {
                _p1 = value;
            }
        }
        public Point p2
        {
            get
            {
                return _p2;
            }
            set
            {
                _p2 = value;
            }
        }
    }
}