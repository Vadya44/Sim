using Android.Graphics;


namespace Sim
{
    public static class Paints
    {
        static Paints()
        {
            // triangle showing 
            triangle.Color = Color.Khaki;
            triangle.StrokeWidth = 20 * F;


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
            resultWin.Color = Color.Rgb(4, 153, 68);
            resultWin.SetStyle(Paint.Style.Fill);

            // result lose color and other settings
            resultLose.Color = Color.Rgb(165, 3, 54);
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
        public static Paint triangle = new Paint();
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
        public static void DrawButtonM(Canvas canvas, int x1, int y1, int x2, int y2)
        {
            Paint p = new Paint();
            p.Color = Color.Honeydew;
            canvas.DrawRoundRect(x1 * F, y1 * F,
                x2 * F, y2 * F,
                10, 10, p);
            canvas.DrawRoundRect(x1 * F, y1 * F,
                x2 * F, y2 * F,
                10, 10, Paints.Circ);
        }
        public static void DrawCircle(Canvas canvas, int x, int y, int radius)
        {
            canvas.DrawCircle(x * F, y * F, radius * F, btns);
            canvas.DrawCircle(x * F, y * F, radius * F, Circ);
        }
        public static void DrawTextM(Canvas canvas, int x1, int y1, string textm,
    int textSize, int StrokeWidth)
        {

            Paint p = new Paint();
            p.StrokeWidth = StrokeWidth * F;
            p.TextSize = textSize * F;
            p.Color = Color.DarkRed;
            canvas.DrawText(textm, x1 * F,
                y1 * F, p);
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
                canvas.DrawRoundRect(100 * F, 60 * F, 620 * F, 560 * F,
                    180, 180, Circ);
                canvas.DrawText("Win", 220 * F, 455 * F, Paints.text);
                canvas.DrawText("You", 230 * F, 250 * F, Paints.text);
            }
            else
            {
                canvas.DrawRoundRect(100 * F, 60 * F, 620 * F, 560 * F,
                    180, 180, resultLose);
                canvas.DrawRoundRect(100 * F, 60 * F, 620 * F, 560 * F,
                    180, 180, Circ);
                canvas.DrawText("Lose", 190 * F, 455 * F, Paints.text);
                canvas.DrawText("You", 230 * F, 250 * F, Paints.text);

            }
        }
        public static void DrawTextMode(Canvas canvas, int x1, int y1, string textm,
                 int textSize, int StrokeWidth)
        {
            Paint modef = new Paint();
            modef.Color = Color.DarkRed;
            modef.StrokeWidth = (StrokeWidth + 8) * F;
            modef.TextSize = (textSize + 5) * F;
            modef.SetStyle(Paint.Style.Fill);
            canvas.DrawText(textm, (x1 - 4) * F,
                     (y1 + 1) * F, modef);
            Paint modetext = new Paint();
            modetext.Color = Color.Rgb(239, 163, 148);
            modetext.StrokeWidth = StrokeWidth * F;
            modetext.TextSize = textSize * F;
            canvas.DrawText(textm, x1 * F,
                y1 * F, modetext);
        }
    }
}