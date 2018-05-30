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
	public partial class NowyRachunek : ContentPage
	{
		public NowyRachunek ()
		{
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            categoryPicker.ItemsSource = await App.KategoriaDatabase.GetKategorieAsync();
        }
        async void OnClickCofnij(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void OnClickZatwierdz(object sender, EventArgs e)
        {
            var rachunekItem = (Rachunek)BindingContext;
            await App.RachunekDatabase.SaveRachunek(rachunekItem);
            await Navigation.PushModalAsync(new NavigationPage(new PrzegladajWydatki()));
        }
        async void KategoriaAdd(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new KategoriaDetails() { BindingContext = new Kategorie() } ));
        }
    }
}