using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Content.PM;
using Android.Content;
using Android.Graphics.Drawables.Shapes;
using System.IO;
using System.Threading;
using System.Timers;
namespace Sim
{
    public static class Intro
    {
		// No clicks
        public static System.Timers.Timer aTimer = new System.Timers.Timer();
        static Bitmap _b;
        static Bitmap _bb;
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Color.White);
            canvas.DrawBitmap(_bb, 0,
                (int)(GameView.mainHidth * 0.2 * GameView.Factor), null);
        }
        public static void Show()
        {

            _b = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.FKNV);
            _bb = Bitmap.CreateScaledBitmap(_b, (int)(GameView.mainWidth * GameView.Factor),
            (int)(0.6 * GameView.mainHidth * GameView.Factor), false);
            GameView.DrawEvent += OnDraw;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            Hide();
            MainMenu.Show();
        }
        public static void Hide()
        {
            GameView.DrawEvent -= OnDraw;
        }
    }
}