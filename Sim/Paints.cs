using System;
using Android.Graphics;
namespace Sim
{
	public static  class Paints
	{
		static Paints()
		{
			//background and text color
			background.Color = Color.Rgb(63, 231, 252);
			text.Color = Color.Rgb(63, 231, 252);


			// button's inside color
			btns.Color = Color.Rgb(38,196,133);
			btns.SetStyle(Paint.Style.Fill);

			//button circlular's color
			Circ.Color = Color.Rgb(47, 6, 1);
			Circ.SetStyle(Paint.Style.Stroke);
			Circ.StrokeWidth = 5 * GameView.Factor;

			//result win color and other settings
			resultWin.Color = Color.Rgb(50, 144, 143);
			resultWin.SetStyle(Paint.Style.Fill);

			// result lose color and other settings
			resultLose.Color = Color.Rgb(85, 58, 65);
			resultLose.SetStyle(Paint.Style.Fill);
		}
		public static Paint background = new Paint();
		public static Paint text = new Paint();
		public static Paint btns = new Paint();
		public static Paint resultWin = new Paint();
		public static Paint resultLose = new Paint();
		public static Paint Circ = new Paint();
        public static void DrawButton(Canvas canvas, int x1, int y1, int x2, int y2)
        {
            canvas.DrawRoundRect(x1 * GameView.Factor, y1 * GameView.Factor,
                x2 * GameView.Factor, y2 * GameView.Factor,
                10, 10, Paints.btns);
            canvas.DrawRoundRect(x1 * GameView.Factor, y1 * GameView.Factor,
                x2 * GameView.Factor, y2 * GameView.Factor,
                10, 10, Paints.Circ);
        }
        public static void DrawText(Canvas canvas, int x1, int y1, string textm,
            int textSize, int StrokeWidth)
        { 
            text.StrokeWidth = StrokeWidth * GameView.Factor;
            text.TextSize = textSize * GameView.Factor;
            canvas.DrawText(textm, x1 * GameView.Factor,
                y1 * GameView. Factor, Paints.text);
        }
	}
}
