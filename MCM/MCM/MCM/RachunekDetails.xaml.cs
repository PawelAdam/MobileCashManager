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
        private string[] ps;
        private JointTables jt;
		public RachunekDetails (JointTables jointTables)
		{
			InitializeComponent ();
            typPlatnosciPicker.ItemsSource= new List<string>{
                "Karta",
                "Gotówka",
                "Inny"
            };
            kwotaEntry.SetBinding(Entry.TextProperty, "Kwota");
            jt = jointTables;
            kategoriaPicker.Text = App.DatabaseController.GetKategoria(jt.KategoriaID).KategoriaName;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateActionSheet();
        }
        private void PopulateActionSheet()
        {
            List<Kategorie> kategories =  App.DatabaseController.GetKategorie();
            ps = new string[kategories.Count];
            int i = 0;
            foreach(Kategorie k in kategories)
            {
                ps[i] = k.KategoriaName;
                i++;
            }
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            var kategoriaItem = App.DatabaseController.GetKategoriaByString(kategoriaPicker.Text);
            var rachunekItem = (Rachunek)BindingContext;
            rachunekItem.KategoriaID = kategoriaItem.KategoriaID;
            if (double.TryParse(kwotaEntry.Text, out double result))
                rachunekItem.Kwota = Math.Round(result,2);
            App.DatabaseController.SaveRachunek(rachunekItem);
            await Navigation.PopModalAsync();
        }

        async private void Cancel_Clicked(object sender, EventArgs e) => await Navigation.PopModalAsync();

        async private void Add_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new DodajKategorie());

        private async void KategoriaSheet_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Wyierz Kategorię", "Anuluj", null, ps);
            kategoriaPicker.Text = action.ToString();
        }
    }
}