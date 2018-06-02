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
        private bool firstlaunchview = true;
		public RachunekDetails ()
		{
            
			InitializeComponent ();
            PopulatePicker();
            typPlatnosciPicker.ItemsSource= new List<string>{
                "Karta",
                "Gotówka",
                "Inny"
            };
            kwotaEntry.SetBinding(Entry.TextProperty, "Kwota");
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulatePicker();
        }
        async private void PopulatePicker()
        {
            List<Kategorie> kategories = await App.KategoriaDatabase.GetKategorieAsync();
            List<string> katestringlist = new List<string>();
            foreach (Kategorie k in kategories)
                katestringlist.Add(k.NazwaKategorii.ToString());
            kategoriaPicker.ItemsSource = katestringlist;
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            var rachunekItem = (Rachunek)BindingContext;
            if (double.TryParse(kwotaEntry.Text, out double result))
                rachunekItem.Kwota = Math.Round(result,2);
            await App.RachunekDatabase.SaveRachunek(rachunekItem);
            await Navigation.PopModalAsync();
        }

        async private void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopModalAsync();

        async private void Add_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new DodajKategorie() { BindingContext = new Kategorie() });
    }
}