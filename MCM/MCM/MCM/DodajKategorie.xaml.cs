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
        public DodajKategorie()
		{
			InitializeComponent ();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listaKategorii.ItemsSource = App.DatabaseController.GetKategorie();
        }

        private async void ListaKategorii_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                if(await DisplayAlert("Akcja", "Co chcesz zrobić", "Edytuj", "Usuń"))
                {
                    await Navigation.PushModalAsync(new NavigationPage(new KategoriaDetails() { BindingContext = e.SelectedItem as Kategorie }));
                }
                else
                {
                    App.DatabaseController.DeleteKategoria(e.SelectedItem as Kategorie);
                    OnAppearing();
                }
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new KategoriaDetails() { BindingContext = new Kategorie() }));
        }
    }
}