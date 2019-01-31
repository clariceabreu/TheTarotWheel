using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTarotWheel.ViewModels;
using Xamarin.Forms;

namespace TheTarotWheel.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();

            grid.RaiseChild(marker);

            MainPageViewModel vm = BindingContext as MainPageViewModel;

            vm.RollImage = async (card) =>
            {
                if (card == 1)
                    await wheel.RotateTo(710, 4000, Easing.SinOut);

                await Task.Delay(1000);
                vm.GoToOptionsPage();

                 
            };

        }
    }
}