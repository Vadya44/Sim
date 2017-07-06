using Android.App;
using Android.OS;
using Android.Views;


namespace Sim
{
    [Activity(Label = "The Sim", MainLauncher = true, Icon = "@drawable/icon",
    Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Intro.Show();
        }
    }
}