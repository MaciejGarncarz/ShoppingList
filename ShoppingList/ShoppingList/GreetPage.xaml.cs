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
	public partial class GreetPage : ContentPage
	{
        private int _buttonClickedCount = 0;
		public GreetPage ()
		{
            InitializeComponent();

            slider.Value = 0.5;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (_buttonClickedCount == 0)
                quoteLabel.Text = "Quote 1";

            if (_buttonClickedCount == 1)
                quoteLabel.Text = "Quote 2";

            if (_buttonClickedCount == 2)
                quoteLabel.Text = "Quote 3";

            _buttonClickedCount++;

            if (_buttonClickedCount == 3)
                _buttonClickedCount = 0;


        }

    }
}