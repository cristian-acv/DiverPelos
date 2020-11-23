
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace DiverPelos.Droid
{
    [Activity(Label = "DiverPelos",
                 Theme = "@style/SplashTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]


    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));
        }
    }
}