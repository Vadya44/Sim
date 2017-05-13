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
using Android.Graphics;

namespace Sim
{
    class Ring
    {
        int cnt, dir;
        static Color[] colors;

        static Ring()
        {
            colors = new Color[3];
            colors[0] = new Color(136, 48, 78);
            colors[1] = new Color(82, 37, 70);
            colors[2] = new Color(49, 29, 63);
        }
        public Ring(int circlesCnt, int direction)
        {
            cnt = circlesCnt;
            dir = direction;
        }

        public void Draw(Canvas canvas, double animTime, double radius)
        {
            double littleRadius = 2 * Math.PI * radius / cnt / 2 * 0.8;
            Paint p = new Paint();
            p.SetStyle(Paint.Style.Fill);
            p.AntiAlias = true;
            for (int i = 0; i < cnt; ++i)
            {
                p.Color = colors[i % colors.Length];
                double angle = Math.PI * 2 * (animTime * dir + i / (double)cnt);
                double x = Math.Cos(angle) * radius + 360;
                double y = Math.Sin(angle) * radius + 640;
                canvas.DrawCircle((float)x * GameView.Factor,
                    GameView.Factor * (float)y, GameView.Factor * (float)littleRadius, p);
            }
        }
    }
}