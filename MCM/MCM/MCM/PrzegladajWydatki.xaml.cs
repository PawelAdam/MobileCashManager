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
        protected override void OnAppearing()
        { 
            base.OnAppearing();
            List<JointTables> jt = App.DatabaseController.GetJointTables();
            listaRachunkow.ItemsSource = jt;
        }

        async private void ListaRachunkow_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                JointTables jt = (JointTables)e.SelectedItem;
                Rachunek r = App.DatabaseController.GetRachunek(jt.RachunekID);
                await Navigation.PushModalAsync(new RachunekDetails(jt) { BindingContext = r});
            }
        }

        async private void DodajRachunek_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NowyRachunek() { BindingContext = new Rachunek() });
            
        }
    }
}