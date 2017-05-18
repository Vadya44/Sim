using Android.Graphics;
using Android.Animation;


namespace Sim
{
    public class MainMenu
    {


        private static double animTime;
        private static Ring ring1, ring2;
        private static ValueAnimator tanim = ValueAnimator.OfFloat(1, 2);
        // With clicks
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            GameView.Instance.Invalidate();
            Paints.DrawButton(canvas, 420, 60, 700, 200); // Solo
            Paints.DrawText(canvas, 490, 155, "Solo", 70, 40);
            Paints.DrawButton(canvas, 20, 60, 300, 200); // PvP
            Paints.DrawText(canvas, 105, 155, "PvP", 70, 40);
            Paints.DrawButton(canvas, 20, 1050, 275, 1150); // About
            Paints.DrawText(canvas, 50, 1120, "About", 70, 40);
            Paints.DrawButton(canvas, 445, 1050, 700, 1150); // Rules
            Paints.DrawText(canvas, 490, 1120, "Rules", 70, 40);
            ring1.Draw(canvas, animTime, 300);
            ring2.Draw(canvas, animTime, 210);
            tanim.Start();
            GameView.Instance.Invalidate();
        }
        public static double AnimTime
        {
            get
            {
                return animTime;
            }
            set
            {
                animTime = value;
                GameView.Instance.Invalidate();
            }
        }
        public static void Show()
        {
            GameView.activeScene = "MainMenu";
            GameView.DrawEvent += OnDraw;
            ring1 = new Ring((int)(20 * GameView.Factor), (int)(GameView.Factor * 1));
            ring2 = new Ring((int)(GameView.Factor * 15), (int)(GameView.Factor * -1));
            ValueAnimator tanim = ValueAnimator.OfFloat(1, 2);
            tanim.SetDuration(5000);
            tanim.RepeatCount = -1;
            tanim.RepeatMode = ValueAnimatorRepeatMode.Reverse;
            tanim.Update += (sender, e) => AnimTime = (double)e.Animation.AnimatedValue;
            tanim.Start();
        }
        public static void Hide()
        {
            tanim.Pause();
            GameView.DrawEvent -= OnDraw;
        }
        public static void JustTouch(float x, float y)
        {
            if (x > 380 && x < 700 && y > 60 && y < 200)
            {
                Hide();
                NumberSelect.Show();
            }
            if (x > 20 && x < 300 && y > 60 && y < 200)
            {
                Hide();
                Multiplayer.Show();
            }
            if (x > 20 && x < 275 && y > 1050 && y < 1150)
            {
                Hide();
                About.Show();
            }
            if (x > 445 && x < 700 && y > 1050 && y < 1150)
            {
                Hide();
                Rules.Show();
            }

        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            if (x1 > 380 && x1 < 700 && y1 > 60 && y1 < 200 &&
                x2 > 380 && x2 < 700 && y2 > 60 && y2 < 200)
            {
                Hide();
                NumberSelect.Show();
            }
            if (x1 > 20 && x1 < 300 && y1 > 60 && y1 < 200 &&
                x2 > 20 && x2 < 300 && y2 > 60 && y2 < 200)
            {
                Hide();
                Multiplayer.Show();
            }
            else
            if (x1 > 20 && x1 < 275 && y1 > 1050 && y1 < 1150 &&
                x2 > 20 && x2 < 275 && y2 > 1050 && y2 < 1150)
            {
                Hide();
                About.Show();
            }
            else
            if (x1 > 445 && x1 < 700 && y1 > 1050 && y1 < 1150 &&
                x2 > 445 && x2 < 700 && y2 > 1050 && y2 < 1150)
            {
                Hide();
                Rules.Show();
            }
            else return;
        }
    }
}