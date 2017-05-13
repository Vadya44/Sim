using System;
using Android.Graphics;
namespace Sim
{
	public static class Paints
	{
		static Paints()
		{
			//background and text color
			background.Color = Color.Rgb(132, 153, 177);
			text.Color = Color.Rgb(132, 153, 177);


			// button's inside color
			btns.Color = Color.Rgb(104, 80, 112);
			btns.SetStyle(Paint.Style.Fill);

			//button circlular's color
			Circ.Color = Color.Rgb(54, 21, 30);
			Circ.SetStyle(Paint.Style.Stroke);
			Circ.StrokeWidth = 5 * GameView.Factor;

			//result win color and other settings
			resultWin.Color = Color.Rgb(50, 144, 143);
			resultWin.SetStyle(Paint.Style.Fill);

			// result lose color and other settings
			resultLose.Color = Color.Rgb(85, 58, 65);
			resultLose.SetStyle(Paint.Style.Fill);

			//solo line player
			plSoloLine.Color = new Color(69, 105, 144);
			plSoloLine.StrokeWidth = 720 / 60 * GameView.Factor;
			plSoloLine.SetStyle(Paint.Style.Stroke);

			//solo line bot
			botSoloLine.Color = new Color(244, 91, 105);
			botSoloLine.StrokeWidth = 720 / 60 * GameView.Factor;
			botSoloLine.SetStyle(Paint.Style.Stroke);
        }
		public static float F = GameView.Factor;
		public static Paint background = new Paint();
		public static Paint text = new Paint();
		public static Paint btns = new Paint();
		public static Paint resultWin = new Paint();
		public static Paint resultLose = new Paint();
		public static Paint Circ = new Paint();
		public static Paint plSoloLine = new Paint();
		public static Paint botSoloLine = new Paint();
		public static void DrawButton(Canvas canvas, int x1, int y1, int x2, int y2)
		{
			canvas.DrawRoundRect(x1 * F, y1 * F,
			    x2 * F, y2 * F,
			    10, 10, Paints.btns);
			canvas.DrawRoundRect(x1 * F, y1 * F,
			    x2 * F, y2 * F,
			    10, 10, Paints.Circ);
		}
        public static void DrawCircle(Canvas canvas, int x, int y, int radius)
        {
            canvas.DrawCircle(x * F, y * F, radius * F, btns);
            canvas.DrawCircle(x * F, y * F, radius * F, Circ);
        }
        public static void DrawText(Canvas canvas, int x1, int y1, string textm,
		    int textSize, int StrokeWidth)
		{
			text.StrokeWidth = StrokeWidth * F;
			text.TextSize = textSize * F;
			canvas.DrawText(textm, x1 * F,
			    y1 * F, Paints.text);
		}
		public static void DrawRes(Canvas canvas, bool isWin)
		{
			canvas.DrawColor(background.Color);
			//canvas.DrawRoundRect(100 * F, 60 * F, 620 * F, 560 * F,
					//120, 120, Circ);
			text.StrokeWidth = 250 * F;
			text.TextSize = 175 * F;
			if (isWin)
			{
                canvas.DrawRoundRect(100 * F, 60 * F, 620 * F, 560 * F,
                    180, 180, resultWin);
                canvas.DrawText("Win", 220 * F, 455 * F, Paints.text);
                canvas.DrawText("You", 230 * F, 250 * F, Paints.text);
                canvas.DrawRoundRect(150 * GameView.Factor, 600 * GameView.Factor,
				 570 * GameView.Factor, 720 * GameView.Factor,
					120, 120, Paints.resultWin);
			}
			else 
			{
                canvas.DrawRoundRect(100 * F, 60 * F, 620 * F, 560 * F,
                    180, 180, resultLose);
                canvas.DrawText("Lose", 190 * F, 455 * F, Paints.text);
                canvas.DrawText("You", 230 * F, 250 * F, Paints.text);
                canvas.DrawRoundRect(150 * GameView.Factor, 600 * GameView.Factor,
				 570 * GameView.Factor, 720 * GameView.Factor,
					120, 120, Paints.resultLose);
			}
			//canvas.DrawRoundRect(200 * GameView.Factor, 600 * GameView.Factor,
					//520 * GameView.Factor, 720 * GameView.Factor,
					//	5, 5, Paints.Circ);
		}
	}
}
