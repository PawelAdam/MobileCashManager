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
	public partial class KategoriaDetails : ContentPage
	{
        private int gridColumnNumber = 0;
		public KategoriaDetails ()
		{
			InitializeComponent ();
		}
        async private void Save_Clicked(object sender, EventArgs e)
        {
            if (gridColumnNumber == 0)
            {
                var kategoriaItem = (Kategorie)BindingContext;
                await App.KategoriaDatabase.SaveKategoria(kategoriaItem);
                await Navigation.PopModalAsync();
            }
            else
            {
                var kategoriaItemList = (List<Kategorie>)BindingContext;
                foreach (Kategorie k in kategoriaItemList)
                {
                    await App.KategoriaDatabase.SaveKategoria(k);
                }
                await Navigation.PopModalAsync();
            }
        }

        async private void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void DodajPole_Clicked(object sender, EventArgs e)
        {
            gridColumnNumber++;
            //kategorie.Children.Add(
            //    new label
            //    {
            //        horizontaloptions = layoutoptions.fillandexpand,
            //        verticaloptions = layoutoptions.fillandexpand,
            //        text="nazwa kategorii",
            //        fontsize = device.getnamedsize(namedsize.medium, typeof(label)),
            //        textcolor = color.aliceblue
            //    },0,gridcolumnnumber);

            kategorie.Children.Add(
                new Entry
                {
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = Color.AliceBlue,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                },1,gridColumnNumber);
        }
    }
}