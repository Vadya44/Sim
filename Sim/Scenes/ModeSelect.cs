using System;
using Android.App;
using Android.Graphics;
using Android.OS;
namespace Sim
{
    public static class ModeSelect
    {
        static int _number;
        static Bitmap _golden, _silver;
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Paints.DrawCircle(canvas, 360, 300, 200); // Easy
            Paints.DrawCircle(canvas, 360, 900, 200); // Hard
            canvas.DrawBitmap(_silver, 173 * GameView.Factor,
                45 * GameView.Factor, null);
            canvas.DrawBitmap(_golden, 173 * GameView.Factor,
               645 * GameView.Factor, null);
            Paints.DrawTextMode(canvas, 215, 340, "Easy", 130, 100);
            Paints.DrawTextMode(canvas, 215, 940, "Hard", 130, 100);
        }
        public static void Show(int numb)
        {
            _number = numb;
            _silver = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Application.Context.Resources,
                Resource.Drawable.silver), (int)(0.7 * GameView.mainWidth * GameView.Factor),
            (int)(0.3 * GameView.mainHidth * GameView.Factor), false);
            _golden = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Application.Context.Resources,
                Resource.Drawable.golden),(int)(0.7 * GameView.mainWidth * GameView.Factor),
            (int)(0.3 * GameView.mainHidth * GameView.Factor), false);
            GameView.activeScene = "ModeSelect";
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            GameView.DrawEvent -= OnDraw;
        }
        public static void JustTouch(float x, float y)
        {
            if (IsEasy(x,y))
            {
                Hide();
                Game_Solo.Show(false, _number);
            }
            if (IsHard(x,y))
            {
                Hide();
                Game_Solo.Show(true, _number);
            }

        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            if (IsEasy(x1, y1) && IsEasy(x2,y2))
            {
                Hide();
                Game_Solo.Show(false, _number);
            }
            if (IsHard(x1, y1) && IsHard(x2,y2))
            {
                Hide();
                Game_Solo.Show(true, _number);
            }
        }
        public static bool IsEasy(float x, float y)
        {
            if (200 > (Math.Sqrt((360 - x) * (360 - x) + (300 - y) * (300 - y))))
                return true;
            else return false;
        }
        public static bool IsHard(float x, float y)
        {
            if (200 > (Math.Sqrt((360 - x) * (360 - x) + (900 - y) * (900 - y))))
                return true;
            else return false;
        }
    }
}
