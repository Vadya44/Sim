using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Content.PM;
using Android.Content;
using Android.Graphics.Drawables.Shapes;
using System.IO;
namespace Sim
{
	public static class Intro
	{
		static Bitmap _b;
		public static void OnDraw(Canvas canvas)
		{
			canvas.DrawBitmap(_b, 10, 10, null);
		}
		public static void Show()
		{
			_b = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.FKNV);

			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
