using System;
using Android.App;
using Android.Graphics;
using Android.OS;
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
            Paints.DrawTextMode(canvas, 135, 440, "5", 130, 100);
            Paints.DrawTextMode(canvas, 135, 900, "9", 130, 100);
            Paints.DrawTextMode(canvas, 505, 440, "7", 130, 100);
            Paints.DrawTextMode(canvas, 475, 900, "11", 130, 100);
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
            if (Is5(x, y))
            {
                Hide();
                ModeSelect.Show(5);
            }
            if (Is7(x, y))
            {
                Hide();
                ModeSelect.Show(7);
            }
            if (Is9(x, y))
            {
                Hide();
                ModeSelect.Show(9);
            }
            if (Is11(x, y))
            {
                Hide();
                ModeSelect.Show(11);
            }

        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            if (Is5(x1, y1) && Is5(x2, y2))
            {
                Hide();
                ModeSelect.Show(5);
            }
            if (Is7(x1, y1) && Is7(x2, y2))
            {
                Hide();
                ModeSelect.Show(7);
            }
            if (Is9(x1, y1) && Is9(x2, y2))
            {
                Hide();
                ModeSelect.Show(9);
            }
            if (Is11(x1, y1) && Is11(x2, y2))
            {
                Hide();
                ModeSelect.Show(11);
            }

        }
        public static bool Is5(float x, float y)
        {
            if (120 > (Math.Sqrt((180 - x) * (180 - x) + (400 - y) * (400 - y))))
                return true;
            else return false;
        }
        public static bool Is7(float x, float y)
        {
            if (120 > (Math.Sqrt((540 - x) * (540 - x) + (400 - y) * (400 - y))))
                return true;
            else return false;
        }
        public static bool Is9(float x, float y)
        {
            if (120 > (Math.Sqrt((180 - x) * (180 - x) + (850 - y) * (850 - y))))
                return true;
            else return false;
        }
        public static bool Is11(float x, float y)
        {
            if (120 > (Math.Sqrt((540 - x) * (540 - x) + (850 - y) * (850 - y))))
                return true;
            else return false;
        }
    }
}
