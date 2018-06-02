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
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List < Kategorie > kategories = await App.KategoriaDatabase.GetKategorieAsync();
            List<string> katestringlist = new List<string>();
            foreach (Kategorie k in kategories)
                katestringlist.Add(k.NazwaKategorii.ToString());
            categoryPicker.ItemsSource = katestringlist;
        }

        private async void OnClickCofnij(object sender, EventArgs e) => await Navigation.PopModalAsync();

        private async void OnClickZatwierdz(object sender, EventArgs e)
        {
            var rachunekItem = (Rachunek)BindingContext;
            await App.RachunekDatabase.SaveRachunek(rachunekItem);
            await Navigation.PopModalAsync(true);
        }

        private async void KategoriaAdd(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync(false);
            await Navigation.PushModalAsync(new NavigationPage(new KategoriaDetails() { BindingContext = new Kategorie() } ));
        }

        private void KwotaEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newValue = e.NewTextValue;
            if (!double.TryParse(newValue, out double value))
            {
                kwotaEntry.BackgroundColor = Color.OrangeRed;
                Save.IsEnabled = false;
            }
            else
            {
                kwotaEntry.BackgroundColor = Color.LightSlateGray;
                Save.IsEnabled = true;
            }
        }
    }
}