using TheTarotWheel.ViewModels;
using Xamarin.Forms;

namespace TheTarotWheel.Views
{
    public partial class OptionsPage : ContentPage
    {
        public OptionsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            OptionsPageViewModel vm = BindingContext as OptionsPageViewModel;

            /*vm.FadeIn =  async () =>
            {
                await card.FadeTo(1, 1000);
            };*/
        }
    }
}
