using System;
using Android.Graphics;
using Android.Content;
using Android.Views;
namespace Sim
{
	public class MainMenu : GameView
	{
		private readonly ScaleGestureDetector _scaleDetector;
		private float _lastTouchX;
      		private float _lastTouchY;
        	private float _posX;
		private float _posY;
		private float _scaleFactor = GameView.Factor;
		private int _activePointerId = InvalidPointerId;
		// With clicks
		public MainMenu(Context context) : base(context, null)
		{
			
		}
		public override bool OnTouchEvent(MotionEvent ev)
		{
			_scaleDetector.OnTouchEvent(ev);
			MotionEventActions action = ev.Action & MotionEventActions.Mask;
			switch (action)
			{
				case MotionEventActions.Down:
					_lastTouchX = ev.GetX();
					_lastTouchY = ev.GetY();
					_activePointerId = ev.GetPointerId(0);
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
					break;
				case MotionEventActions.Up:
				case MotionEventActions.Cancel:
					// This events occur when something cancels the gesture (for example the
					// activity going in the background) or when the pointer has been lifted up.
					// We no longer need to keep track of the active pointer.
					_activePointerId = InvalidPointerId;
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