using System;
using Android.Graphics;
namespace Sim
{
    public static class Result_Ranked
    {
		// With clicks
        static void OnDraw(Canvas canvas)
        {
            Paints.DrawRes(canvas, true);
            Paints.DrawButton(canvas, 135, 1000, 585, 1150);
            Paints.DrawText(canvas, 138, 1100, "Main menu", 90, 60);
            Paints.DrawButton(canvas, 135, 800, 585, 950);
            Paints.DrawText(canvas, 148, 900, "New game", 90, 60);
            Paints.DrawText(canvas, 270, 650, "CHANGE", 40, 20);
            Paints.DrawText(canvas, 270, 700, "NEW RANK", 40, 20);
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