using System;
using Android.Graphics;

namespace Sim
{
    public static class NumberSelect
    {

        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Paint ccir = new Paint();
            ccir.SetStyle(Paint.Style.Stroke);
            ccir.AntiAlias = true;
            ccir.Color = new Color(71, 106, 111);
            ccir.StrokeWidth = 30 * GameView.Factor;
            canvas.DrawCircle(360 * GameView.Factor, 640 * GameView.Factor,
                300 * GameView.Factor, ccir);
            Paints.DrawCircle(canvas, 180, 400, 120); //5 
            Paints.DrawCircle(canvas, 180, 850, 120); //9
            Paints.DrawCircle(canvas, 540, 400, 120); //7 
            Paints.DrawCircle(canvas, 540, 850, 120); //11
            Paints.DrawTextMode(canvas, 135, 440, "6", 130, 100);
            Paints.DrawTextMode(canvas, 110, 893, "10", 130, 100);
            Paints.DrawTextMode(canvas, 505, 440, "8", 130, 100);
            Paints.DrawTextMode(canvas, 470, 893, "12", 130, 100);
            Paints.DrawTextM(canvas, 80, 100, "Choose number", 80, 50);
            Paints.DrawTextM(canvas, 210, 200, "of points", 80, 50);
        }
        public static void Show()
        {
            GameView.activeScene = "NumberSelect";
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            GameView.DrawEvent -= OnDraw;
        }
        public static void JustTouch(float x, float y)
        {
            if (Is6(x, y))
            {
                Hide();
                ModeSelect.Show(6);
            }
            if (Is8(x, y))
            {
                Hide();
                ModeSelect.Show(8);
            }
            if (Is10(x, y))
            {
                Hide();
                ModeSelect.Show(10);
            }
            if (Is12(x, y))
            {
                Hide();
                ModeSelect.Show(12);
            }

        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            if (Is6(x1, y1) && Is6(x2, y2))
            {
                Hide();
                ModeSelect.Show(6);
            }
            if (Is8(x1, y1) && Is8(x2, y2))
            {
                Hide();
                ModeSelect.Show(8);
            }
            if (Is10(x1, y1) && Is10(x2, y2))
            {
                Hide();
                ModeSelect.Show(10);
            }
            if (Is12(x1, y1) && Is12(x2, y2))
            {
                Hide();
                ModeSelect.Show(12);
            }

        }
        public static bool Is6(float x, float y)
        {
            return (120 > (Math.Sqrt((180 - x) * (180 - x) + (400 - y) * (400 - y))));
        }
        public static bool Is8(float x, float y)
        {
            return (120 > (Math.Sqrt((540 - x) * (540 - x) + (400 - y) * (400 - y))));
        }
        public static bool Is10(float x, float y)
        {
            return (120 > (Math.Sqrt((180 - x) * (180 - x) + (850 - y) * (850 - y))));
        }
        public static bool Is12(float x, float y)
        {
            return (120 > (Math.Sqrt((540 - x) * (540 - x) + (850 - y) * (850 - y))));
        }
    }
}
