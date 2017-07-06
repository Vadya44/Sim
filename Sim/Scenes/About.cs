using Android.Graphics;


namespace Sim
{
    public static class About
    // With clicks
    {

        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.resultLose.Color);
            Paints.DrawButton(canvas, 30, 50, 690, 900);
            Paints.DrawText(canvas, 40, 180, "Application's history:", 70, 50);
            Paints.DrawText(canvas, 37, 370, "Application is created as part", 50, 30);
            Paints.DrawText(canvas, 110, 520, "of 1st year project by", 50, 30);
            Paints.DrawText(canvas, 50, 670, "Gataullin Vadim, student of", 50, 30);
            Paints.DrawText(canvas, 110, 820, " SE CS HSE. May 2k17", 50, 30);
            Paints.DrawButton(canvas, 100, 1000, 620, 1150);
            Paints.DrawText(canvas, 112, 1100, "Main menu", 100, 75);


        }
        public static void Show()
        {
            GameView.activeScene = "Rules";
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            GameView.DrawEvent -= OnDraw;
        }
        public static void JustTouch(float x, float y)
        {
            if (x > 100 && x < 620 && y > 1000 && y < 1150)
            {
                Hide();
                MainMenu.Show();
            }
        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            if (x1 > 100 && x1 < 620 && y1 > 1000 && y1 < 1150 &&
                x2 > 100 && x2 < 620 && y2 > 1000 && y2 < 1150)
            {
                Hide();
                MainMenu.Show();
            }
        }
    }
}
