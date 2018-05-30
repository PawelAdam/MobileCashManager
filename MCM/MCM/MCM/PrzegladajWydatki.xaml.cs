using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCM.Klasy;
using MCM.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrzegladajWydatki : ContentPage
	{
		public PrzegladajWydatki ()
		{
			InitializeComponent ();

            Title = "Lista Rachunków";

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaRachunkow.ItemsSource = await App.RachunekDatabase.GetRachunkiAsync();
        }

        async private void ListaRachunkow_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new RachunekDetails() { BindingContext = e.SelectedItem as Rachunek });
            }
        }

        async private void DodajRachunek_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NowyRachunek() { BindingContext = new Rachunek() });
        }
    }
}