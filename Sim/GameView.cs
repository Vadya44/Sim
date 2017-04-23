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
        private static readonly int InvalidPointerId = -1;
        private readonly ScaleGestureDetector _scaleDetector;
        private int _activePointerId = InvalidPointerId;
        private float _lastTouchX;
        private float _lastTouchY;
        private float _posX;
        private float _posY;
        private float _scaleFactor = 1.0f;




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
            _scaleDetector = new ScaleGestureDetector(context, new MyScaleListener(this));
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





        public override bool OnTouchEvent(MotionEvent ev)
        {
            _scaleDetector.OnTouchEvent(ev);
            MotionEventActions action = ev.Action & MotionEventActions.Mask;
            int pointerIndex;
            switch (action)
            {
                case MotionEventActions.Down:
                    _lastTouchX = ev.GetX();
                    _lastTouchY = ev.GetY();
                    _activePointerId = ev.GetPointerId(0);
                    MainMenu.Hide();
                    Result_Ranked.Show();
                    break;
                case MotionEventActions.Move:
                    pointerIndex = ev.FindPointerIndex(_activePointerId);
                    float x = ev.GetX(pointerIndex);
                    float y = ev.GetY(pointerIndex);
                    if (!_scaleDetector.IsInProgress)
                    {
                        // Only move the ScaleGestureDetector isn't already processing a gesture.
                        float deltaX = x - _lastTouchX;
                        float deltaY = y - _lastTouchY;
                        _posX += deltaX;
                        _posY += deltaY;
                        Invalidate();
                    }
                    _lastTouchX = x;
                    _lastTouchY = y;
                    MainMenu.Hide();
                    Result_Ranked.Show();
                    break;
                case MotionEventActions.Up:
                case MotionEventActions.Cancel:
                    // This events occur when something cancels the gesture (for example the
                    // activity going in the background) or when the pointer has been lifted up.
                    // We no longer need to keep track of the active pointer.
                    _activePointerId = InvalidPointerId;
                    break;
                case MotionEventActions.PointerUp:
                    // We only want to update the last touch position if the the appropriate pointer
                    // has been lifted off the screen.
                    pointerIndex = (int)(ev.Action & MotionEventActions.PointerIndexMask) >> (int)MotionEventActions.PointerIndexShift;
                    int pointerId = ev.GetPointerId(pointerIndex);
                    if (pointerId == _activePointerId)
                    {
                        // This was our active pointer going up. Choose a new
                        // action pointer and adjust accordingly
                        int newPointerIndex = pointerIndex == 0 ? 1 : 0;
                        _lastTouchX = ev.GetX(newPointerIndex);
                        _lastTouchY = ev.GetY(newPointerIndex);
                        _activePointerId = ev.GetPointerId(newPointerIndex);
                    }
                    break;
            }
            return true;
        }
    }
     class MyScaleListener : ScaleGestureDetector.SimpleOnScaleGestureListener
    {
        private readonly GameView _view;
        public MyScaleListener(GameView view)
        {
            _view = view;
        }
        public override bool OnScale(ScaleGestureDetector detector)
        {
            return true;
        }
    }
}