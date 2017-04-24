using System;
using Android.Graphics;
using Android.Content;
using Android.Views;
namespace Sim
{
    public class MainMenu
    {

        // With clicks
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Paints.DrawButton(canvas, 180, 350, 540, 550); // Ranked
            Paints.DrawButton(canvas, 180, 600, 540, 800); // Training
            Paints.DrawText(canvas, 210, 480, "Ranked", 90, 60);
            Paints.DrawText(canvas, 200, 730, "Training", 90, 60);
            Paints.DrawButton(canvas, 20, 20, 280, 130); // Account 
            Paints.DrawButton(canvas, 440, 20, 700, 130); // Top
            Paints.DrawText(canvas, 40, 90, "Account", 60, 40);
            Paints.DrawText(canvas, 500, 95, "Top", 80, 50);
            Paints.DrawButton(canvas, 235, 1000, 485, 1150); // Rules
            Paints.DrawText(canvas, 250, 1100, "Rules", 90, 60);
        }
        public static void Show()
        {
            GameView.activeScene = "MainMenu";
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            GameView.DrawEvent -= OnDraw;
        }
        public static void JustTouch(float x, float y)
        {
            if (x > 180 && x < 540 && y > 350 && y < 550)
            {
                Hide();
                Game_Ranked.Show();
            }
            if (x > 180 && x < 540 && y > 600 && y < 800)
            {
                Hide();
                Game_Solo.Show();
            }
            if (x > 20 && x < 280 && y > 20 && y < 130)
            {
                Hide();
                Account.Show();
            }
            if (x > 440 && x < 700 && y > 20 && y < 130)
            {
                Hide();
                LeaderBoard.Show();
            }
            if (x > 235 && x < 485 && y > 1000 && y < 1150)
            {
                Hide();
                Rules.Show();
            }

        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            if (x1 > 180 && x1 < 540 && y1 > 350 && y1 < 550 &&
                x2 > 180 && x2 < 540 && y2 > 350 && y2 < 550)
            {
                Hide();
                Game_Ranked.Show();
            }
            if (x1 > 180 && x1 < 540 && y1 > 600 && y1 < 800 &&
                x2 > 180 && x2 < 540 && y2 > 600 && y2 < 800)
            {
                Hide();
                Game_Solo.Show();
            }
            if (x1 > 20 && x1 < 280 && y1 > 20 && y1 < 130 &&
                x2 > 20 && x2 < 280 && y2 > 20 && y2 < 130)
            {
                Hide();
                Account.Show();
            }
            if (x1 > 440 && x1 < 700 && y1 > 20 && y1 < 130 &&
                x2 > 440 && x2 < 700 && y2 > 20 && y2 < 130)
            {
                Hide();
                LeaderBoard.Show();
            }
            if (x1 > 235 && x1 < 485 && y1 > 1000 && y1 < 1150 &&
                x2 > 235 && x2 < 485 && y2 > 1000 && y2 < 1150)
            {
                Hide();
                Rules.Show();
            }
        }
        }
}