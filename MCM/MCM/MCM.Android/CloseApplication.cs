using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCM.Klasy;
using Xamarin.Forms;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MCM.Droid
{
    class CloseApplication : ICloseApplication
    {
        public void CloseApp()
        {

            Android.OS.Process.KillProcess(Process.MyPid());
        }
    }
}