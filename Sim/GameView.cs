﻿using System;
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
        public static string activeScene = "";
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
            //_scaleDetector = new ScaleGestureDetector(context, new MyScaleListener(this));
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




        private static readonly int InvalidPointerId = -1;
        private int _activePointerId = InvalidPointerId;
        private float _lastTouchX;
        private float _lastTouchY;
        private float _posX = 0;
        private float _posY = 0;
        byte isMoved = 0; 
        public override bool OnTouchEvent(MotionEvent ev)
        {
            MotionEventActions action = ev.Action & MotionEventActions.Mask;
            int pointerIndex = 0;
            
            if (ev.PointerCount > 1) return false;
            switch (action)
            {
                case MotionEventActions.Down:
                    _lastTouchX = ev.GetX();
                    _lastTouchY = ev.GetY();
                    _activePointerId = ev.GetPointerId(0);
                    break;
                case MotionEventActions.Move:
                    isMoved = 1;
                    pointerIndex = ev.FindPointerIndex(_activePointerId);
                    _posX = ev.GetX(pointerIndex);
                    _posY = ev.GetY(pointerIndex);
                    
                    break;
                case MotionEventActions.Up:
                    if (isMoved == 0)
                    {
                        TouchHandler.JustTouch(_lastTouchX / Factor, _lastTouchY / Factor);
                        break;
                    }
                    else
                    {
                        TouchHandler.MovedTouch(_lastTouchX / Factor, _lastTouchY / Factor,
                        ev.GetX(pointerIndex) / Factor, ev.GetY(pointerIndex) / Factor);
                        isMoved = 0;
                        break;
                        
                    }
                case MotionEventActions.Cancel:
                    _activePointerId = InvalidPointerId;
                    break;
            }
            return true;
        }
    }
}