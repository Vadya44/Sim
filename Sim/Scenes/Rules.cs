using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
namespace Sim
{
	public static class Rules
	// With clicks
	{
		
		public static void OnDraw(Canvas canvas)
		{
            canvas.DrawColor(Paints.resultLose.Color);
            Paints.DrawButton(canvas, 30, 50, 690, 900);
            Paints.DrawText(canvas, 50, 100, "Two players take turns coloring any", 40, 20);
            Paints.DrawText(canvas, 105, 170, "uncolored lines. One player", 40, 20);
            Paints.DrawText(canvas, 110, 240, "colors in one color, and the", 40, 20);
            Paints.DrawText(canvas, 100, 310, "other colors in another color,", 40, 20);
            Paints.DrawText(canvas, 140, 380, "with each player trying to", 40, 20);
            Paints.DrawText(canvas, 33, 450, "avoid the creation of a triangle made", 40, 20);
            Paints.DrawText(canvas, 50, 530, "solely of their color (only triangles", 40, 20);
            Paints.DrawText(canvas, 95, 600, "with the dots as corners count;", 40, 20);
            Paints.DrawText(canvas, 112, 670, "intersections of lines are not", 40, 20);
            Paints.DrawText(canvas, 140, 740, "relevant); the player who", 40, 20);
            Paints.DrawText(canvas, 140, 810, "completes such a triangle", 40, 20);
            Paints.DrawText(canvas, 190, 880, "loses immediately.", 40, 20);
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
