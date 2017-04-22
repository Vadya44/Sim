using System;
using Android.Graphics;
namespace Sim
{
    public class MainMenu
    {
		// With clicks
        public static void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Paints.background.Color);
            Paints.DrawButton(canvas, 180, 350, 540, 550);
            Paints.DrawButton(canvas, 180, 600, 540, 800);
            Paints.DrawText(canvas, 210, 480, "Ranked", 90, 60);
            Paints.DrawText(canvas, 200, 730, "Training", 90, 60);
            Paints.DrawButton(canvas, 20, 20, 280, 130);
            Paints.DrawButton(canvas, 440, 20, 700, 130);
            Paints.DrawText(canvas, 40, 90, "Account", 60, 40);
            Paints.DrawText(canvas, 500, 95, "Top", 80, 50);
            Paints.DrawButton(canvas, 235, 1000, 485, 1150);
            Paints.DrawText(canvas, 250, 1100, "Rules", 90, 60);
            Hide();
            Result_Ranked.Show();
        }
        public static void Show()
        {
            GameView.DrawEvent += OnDraw;
        }
        public static void Hide()
        {
            GameView.DrawEvent -= OnDraw;
        }
    }
}