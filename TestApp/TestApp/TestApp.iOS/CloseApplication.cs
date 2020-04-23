using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Foundation;
using TestApp.iOS;
using TestApp.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace TestApp.iOS
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}