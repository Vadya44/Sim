using System;
using System.Collections.Generic;
using Android.Animation;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.App;
using Android.Content.Res;
namespace Sim
{
	public class GameView : View
	{
		public static float mainWidth = 720;
		public static float mainHidth = 1280;
		public static float CenterX;
		public static float CenterY;
		public static float Factor = 1;
		//int _px;
		//private Circle _circle;
		public static GameView Instance { get; private set; }
		public delegate void DrawDelegate(Canvas canvas);
		public static event DrawDelegate DrawEvent;
        static GameView()
        {
            Resources resources = Application.Context.Resources;
            int Width = resources.DisplayMetrics.WidthPixels;
            int Heigth = resources.DisplayMetrics.HeightPixels;
            CenterX = Width / 2;
            CenterY = Heigth / 2;
            Factor = Math.Max((float)Width / mainWidth, (float)Heigth / mainHidth);
        }
		public GameView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
            Instance = this;
            //Initialize();
        }
		//private void Initialize()
		//{
		//var metrics = Resources.DisplayMetrics;
		//_circle = new Circle(metrics.WidthPixels, metrics.HeightPixels);
		//_px = Resources.DisplayMetrics.WidthPixels;
		//}
		protected override void OnDraw(Canvas canvas)
		{
			canvas.Save();
			DrawEvent?.Invoke(canvas);
			Invalidate();
			//_circle.Draw(canvas);
			//Methods.DrawPoints(10, canvas, _circle, _px);

		}
	}
}