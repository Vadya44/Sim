using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Sim
{
    public class Line
    {
        private Point _p1;
        private Point _p2;
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