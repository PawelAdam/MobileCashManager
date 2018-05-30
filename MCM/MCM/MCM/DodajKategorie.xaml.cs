using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCM.Klasy;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DodajKategorie : ContentPage
	{
		public DodajKategorie ()
		{
			InitializeComponent ();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaKategorii.ItemsSource = await App.KategoriaDatabase.GetKategorieAsync();
        }

        async private void ListaKategorii_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new KategoriaDetails() { BindingContext = e.SelectedItem as Kategorie });
            }
        }

        async private void NowaKategoria_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KategoriaDetails() { BindingContext = new Kategorie() });
        }
    }
}