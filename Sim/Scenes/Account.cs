using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Android.Graphics.Drawables;
namespace Sim
{
	public class Account
	{
		static void OnDraw(Canvas canvas)
		{
			
		}
		static void Show()
		{
			GameView.DrawEvent += OnDraw;
		}
		static void Hide()
		{
			GameView.DrawEvent -= OnDraw;
		}
	}
}
