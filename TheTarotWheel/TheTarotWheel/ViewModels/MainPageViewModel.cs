using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheTarotWheel.Enums;

namespace TheTarotWheel.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DelegateCommand Roll { get; private set; }
        public Action<int> RollImage { get; set; }
        public Action CancelAnimation { get; set; }

        private ECards _selectedCard;

        public MainPageViewModel(INavigationService navigationService) : base (navigationService)
        {
            Title = "A Roda do Tarot";

            _navigationService = navigationService;

            Roll = new DelegateCommand(GenerateCard);
        }

        private void GenerateCard()
        {
            Random random = new Random();
            var number = random.Next(1, 23);

            #region temporary
            Console.WriteLine(number);
            number = 1;
            #endregion

            if (number == 1)
                _selectedCard = ECards.LeFov;

            RollImage(1);
        }

        public async void GoToOptionsPage()
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("card", _selectedCard);

            await _navigationService.NavigateAsync(new Uri("OptionsPage", UriKind.Relative), parameters);
        }
    }
}
