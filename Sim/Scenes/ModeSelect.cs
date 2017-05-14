using System;
using Android.App;
using Android.Graphics;
namespace Sim
{
    public static class ModeSelect
    {
        static Bitmap _golden, _silver;
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Paints.DrawCircle(canvas, 360, 300, 200);
            Paints.DrawCircle(canvas, 360, 900, 200);
            canvas.DrawBitmap(_silver, 173 * GameView.Factor,
                45 * GameView.Factor, null);
            canvas.DrawBitmap(_golden, 173 * GameView.Factor,
               645 * GameView.Factor, null);
            Paints.DrawText(canvas, 360, 300, "Easy", 70, 40);
            Paints.DrawText(canvas, 360, 900, "Hard", 70, 40);
        }
        public static void Show()
        {
            _silver = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Application.Context.Resources,
                Resource.Drawable.silver), (int)(0.7 * GameView.mainWidth * GameView.Factor),
            (int)(0.3 * GameView.mainHidth * GameView.Factor), false);
            _golden = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Application.Context.Resources,
                Resource.Drawable.vadya),(int)(0.7 * GameView.mainWidth * GameView.Factor),
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
            Hide();
            Game_Solo.Show();
            if (x > 135 && x < 585 && y > 1000 && y < 1150)
            {
                Hide();
                MainMenu.Show();
            }

        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            if (x1 > 135 && x1 < 585 && y1 > 1000 && y1 < 1150 &&
                x2 > 135 && x2 < 585 && y2 > 1000 && y2 < 1150)
            {
                Hide();
                MainMenu.Show();
            }
        }
    }
}
