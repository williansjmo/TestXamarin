
using Android.App;
using TestApp.Droid;
using TestApp.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace TestApp.Droid
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}