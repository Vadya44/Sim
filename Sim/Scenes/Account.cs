using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Android.Graphics.Drawables;
namespace Sim
{
	public static class Account
	{
		// With clicks
		public static void OnDraw(Canvas canvas)
		{
			
		}
		public static void Show()
		{
            GameView.activeScene = "Account";
			GameView.DrawEvent += OnDraw;
		}
		public static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
