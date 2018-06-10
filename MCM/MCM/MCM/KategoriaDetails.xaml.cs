using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MCM.Klasy;

namespace MCM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KategoriaDetails : ContentPage
	{
		public KategoriaDetails ()
		{
			InitializeComponent ();
		}

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var kategorieItem = (Kategorie)BindingContext;
            App.DatabaseController.SaveKategoria(kategorieItem);
            await Navigation.PopModalAsync(false);

        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}