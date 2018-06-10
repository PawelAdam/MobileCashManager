using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MCM.Klasy;
using MCM.Data;
using SQLite;


[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MCM
{
    public partial class App : Application
    {
        private static DatabaseController dbc;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static DatabaseController DatabaseController
        {
            get
            {
                if (dbc == null)
                {
                    dbc = new DatabaseController();
                }
                return dbc;
            }
        }

        public static void Shutdown()
        {
            var closer = DependencyService.Get<ICloseApplication>();
            closer?.CloseApp();
        }
    }
}
