using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Opcje : ContentPage
	{
		public Opcje ()
		{
			InitializeComponent ();
		}

        async private void Button_Clicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Czy jesteś pewien", "Ta operacja jest nieodwracalana", "Kontynuuj", "Anuluj"))
            {
                App.DatabaseController.DropRachunekTable();
                new Data.DatabaseController();
            }
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (await DisplayAlert("Czy jesteś pewien", "Ta operacja jest nieodwracalana", "Kontynuuj", "Anuluj"))
            {
                App.DatabaseController.DropKategoriaTable();
                new Data.DatabaseController();
            }
        }
    }
}