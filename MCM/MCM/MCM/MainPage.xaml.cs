using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MCM
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();
            Title = "Mobile Cash Manager";

        }
        /*async void OnClick_nowyRachunek(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NowyRachunek());
        }*/
        async void OnClick_przegladajWydatki(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PrzegladajWydatki()));
        }
        async void OnClick_opcje(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Opcje());
        }

        private void OnClick_wyjscie(object sender, EventArgs e)
        {
            App.Shutdown();
        }

        async private void PrzegladajKategorie_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DodajKategorie()));
        }
    }
}
