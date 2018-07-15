using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StackPageTraining : ContentPage
	{
		public StackPageTraining ()
		{
			InitializeComponent ();

        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GreetPage());
        }

        async private void Another_ButtonClicked(object sender, EventArgs e)
        {
            var respone = await DisplayAlert("PopUp", "Czy klinięto przycisk?", "Tak", "Nie");

            if (respone)
                await DisplayAlert("Zrobione", "Tak to prawda", "ok");
            else
                await DisplayAlert("Zrobione", "Kłamca", "ok");

        }
        async private void AndAnother_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Forms());
        }

        async private void Final_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersistanceTraining());
        }
    }
}