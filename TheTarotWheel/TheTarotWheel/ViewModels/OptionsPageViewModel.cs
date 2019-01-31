using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using TheTarotWheel.Enums;

namespace TheTarotWheel.ViewModels
{
    public class OptionsPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        //public Action FadeIn { get; set; }
        public DelegateCommand PersonalDevolopementTapped { get; private set; }
        public DelegateCommand ProfessionalTapped { get; private set; }
        public DelegateCommand AffectiveTapped { get; private set; }
        public DelegateCommand FinancialTapped { get; private set; }
        public DelegateCommand HealthTapped { get; private set; }
        public DelegateCommand YesOrNoTapped { get; private set; }

        private ECards _selectedCard;

        public OptionsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "O Louco";

            _navigationService = navigationService;

            PersonalDevolopementTapped = new DelegateCommand(PersonalDevelopment);
            ProfessionalTapped = new DelegateCommand(Professional);
            AffectiveTapped = new DelegateCommand(Affective);
            FinancialTapped = new DelegateCommand(Financial);
            HealthTapped = new DelegateCommand(Health);
            YesOrNoTapped = new DelegateCommand(YesOrNo);

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            _selectedCard = (ECards)parameters["card"];

            if (_selectedCard != ECards.Null)
                SetImage();
        }

        #region functions
        private void SetImage()
        {
            if (_selectedCard == ECards.LeFov)
                SelectedCard = "LeFov.jpg";

            //FadeIn();
        }

        public async void PersonalDevelopment()
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("card", _selectedCard);
            param.Add("theme", EThemes.PersonalDevelopment);

            await _navigationService.NavigateAsync(new Uri("ResultPage", UriKind.Relative), param);
        }

        public async void Health()
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("card", _selectedCard);
            param.Add("theme", EThemes.Health);

            await _navigationService.NavigateAsync(new Uri("ResultPage", UriKind.Relative), param);
        }

        public async void Professional()
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("card", _selectedCard);
            param.Add("theme", EThemes.Professional);

            await _navigationService.NavigateAsync(new Uri("ResultPage", UriKind.Relative), param);
        }

        public async void Affective()
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("card", _selectedCard);
            param.Add("theme", EThemes.Affective);

            await _navigationService.NavigateAsync(new Uri("ResultPage", UriKind.Relative), param);
        }

        public async void Financial()
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("card", _selectedCard);
            param.Add("theme", EThemes.Financial);

            await _navigationService.NavigateAsync(new Uri("ResultPage", UriKind.Relative), param);
        }

        public async void YesOrNo()
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("card", _selectedCard);
            param.Add("theme", EThemes.YesOrNo);

            await _navigationService.NavigateAsync(new Uri("ResultPage", UriKind.Relative), param);
        }
        #endregion

        #region properties
        private string _card;
        public string SelectedCard
        {
            get { return _card; }
            set { SetProperty(ref _card, value); }
        }

        #endregion
    }
}
