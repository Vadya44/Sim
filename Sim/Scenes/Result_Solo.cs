using Android.Graphics;


namespace Sim
{
    public static class Result_Solo
    {
        private static bool _isPlWin;
        // With clicks
        public static void OnDraw(Canvas canvas)
        {
            if (_isPlWin)
                Paints.DrawRes(canvas, true);
            else Paints.DrawRes(canvas, false);
            Paints.DrawButton(canvas, 135, 1000, 585, 1150);
            Paints.DrawText(canvas, 138, 1100, "Main menu", 90, 60);
            Paints.DrawButton(canvas, 135, 800, 585, 950);
            Paints.DrawText(canvas, 148, 900, "New game", 90, 60);
        }
        public static void Show(bool isPlayerWin)
        {
            _isPlWin = isPlayerWin;
            GameView.activeScene = "Result_Solo";
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            GameView.DrawEvent -= OnDraw;
        }
        public static void JustTouch(float x, float y)
        {
            if (x > 135 && x < 585 && y > 1000 && y < 1150)
            {
                Hide();
                MainMenu.Show();
            }
            if (x > 135 && x < 585 && y > 800 && y < 950)
            {
                Hide();
                NumberSelect.Show();
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
            if (x1 > 135 && x1 < 585 && y1 > 800 && y1 < 950 &&
                x2 > 135 && x2 < 585 && y2 > 800 && y2 < 950)
            {
                Hide();
                NumberSelect.Show();
            }
        }
    }
}
