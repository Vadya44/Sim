using Android.App;
using Android.OS;


namespace Sim
{
    [Activity(Label = "Sim", MainLauncher = true, Icon = "@mipmap/icon",
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