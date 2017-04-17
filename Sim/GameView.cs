using System;
using System.Collections.Generic;
using Android.Animation;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
namespace Sim
{
	public class GameView : View
	{
		public float mainWidth = 720;
		public float mainHidth = 1280;
		public static float CenterX;
		public static float CenterY;
		public float Factor;
		//int _px;
		//private Circle _circle;
		public static GameView Instance { get; private set; }
		public delegate void DrawDelegate(Canvas canvas);
		public static event DrawDelegate DrawEvent;
		public GameView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			Instance = this;
			CenterX = Width / 2;
			CenterY = Height / 2;
			Factor = ((Width / mainHidth) > (Height / mainHidth)) ?
				Height / mainHidth : Width / mainWidth;
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
			canvas.Restore();
			Invalidate();
			//_circle.Draw(canvas);
			//Methods.DrawPoints(10, canvas, _circle, _px);

		}
	}
}