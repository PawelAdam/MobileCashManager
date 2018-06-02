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
            kwotaEntry.SetBinding(Entry.TextProperty, "Kwota", stringFormat: "{0:C}");
            kategoriaPicker.SetBinding(Picker.SelectedItemProperty, "Kategoria");
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!firstlaunchview)
            {
                PopulatePicker();
            }
            else firstlaunchview = true;
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
            await App.RachunekDatabase.SaveRachunek(rachunekItem);
            await Navigation.PopModalAsync();
        }

        async private void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopModalAsync();

        async private void Add_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new DodajKategorie() { BindingContext = new Kategorie() });

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            char[] originalText = kwotaEntry.Text.ToCharArray();
            foreach(char c in originalText)
            {
                if (!(Char.IsNumber(c) || Char.IsPunctuation(c))) {
                    kwotaEntry.Text = kwotaEntry.Text.Remove(kwotaEntry.Text.IndexOf(c));
                    kwotaEntry.BackgroundColor = Color.OrangeRed;
                } else
                    kwotaEntry.BackgroundColor = Color.LightSlateGray;
            };
        }
    }
}