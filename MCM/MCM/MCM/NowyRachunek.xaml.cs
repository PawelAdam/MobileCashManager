using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCM.Klasy;
using MCM.Data;
using MCM;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NowyRachunek : ContentPage
	{
        private List<Kategorie> kt;
		public NowyRachunek ()
		{
            InitializeComponent();
            typPicker.ItemsSource = new List<string>{
                "Karta",
                "Gotówka",
                "Inny"
            };
            DataPicker.Date = DateTime.Now;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            kt = App.DatabaseController.GetKategorie();
            foreach (Kategorie k in kt)
            {
                Kategoria.Items.Add(k.KategoriaName);
            }
            
        }

        private async void OnClickCofnij(object sender, EventArgs e) => await Navigation.PopModalAsync();

        private async void OnClickZatwierdz(object sender, EventArgs e)
        {
            var rachunekItem = (Rachunek)BindingContext;
            if(double.TryParse(kwotaEntry.Text,out double result))
            {
                rachunekItem.Kwota = Math.Round(result,2);
            }
            Kategorie k = App.DatabaseController.GetKategoriaByString(Kategoria.SelectedItem.ToString());
            rachunekItem.KategoriaID = k.KategoriaID;
            App.DatabaseController.SaveRachunek(rachunekItem);
            await Navigation.PopModalAsync(true);
        }

        private async void KategoriaAdd(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DodajKategorie()));
        }
    }
}