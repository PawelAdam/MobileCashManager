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
	public partial class RachunekDetails : ContentPage
	{
		public RachunekDetails ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            kategoriaPicker.ItemsSource = await App.KategoriaDatabase.GetKategorieAsync();
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            var rachunekItem = (Rachunek)BindingContext;
            await App.RachunekDatabase.SaveRachunek(rachunekItem);
            await Navigation.PopModalAsync();
        }

        async private void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopModalAsync();

        async private void Add_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new DodajKategorie() { BindingContext = new Kategorie() });
    }
}