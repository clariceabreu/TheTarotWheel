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
    public class ResultPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DelegateCommand RollAgain { get; private set; }

        private ECards _selectedCard;
        private EThemes _selectedTheme;

        public ResultPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            RollAgain = new DelegateCommand(GoToMainPage);
        }


        #region functions
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            _selectedCard = (ECards)parameters["card"];
            _selectedTheme = (EThemes)parameters["theme"];

            if (_selectedCard != ECards.Null && _selectedTheme != EThemes.Null)
                Title = _selectedTheme.ToString();
                SetText();
        }

        private void SetText()
        {
            if (_selectedCard == ECards.LeFov)
            {
                if (_selectedTheme == EThemes.Professional)
                    ResultText = "1. si ce travail ne vous correspond plus, il est vraiment temps de prendre vos clics et vos clacs et de suivre un autre chemin professionnel. ( attention toutefois de ne pas vous mettre en difficulté. Avant de quitter votre emploi, soyez au point sur vos objectifs et sur le nouveau chemin que vous voulez prendre). Faites un tour ici pour en savoir plus sur comment atteindre ses objectifs.\n\n2.  Vous avez une proposition pour un nouvel emploi dans une autre ville ou bien une proposition de délocalisation ? Qu' attendez vous pour faire vos valises..?\n\n3. Vous avez un projet, une idées, un rêve, une passion dont vous aimeriez en faire votre gagne pain ? Allez y ! Foncez ! Prenez votre bâton de pèlerin et allez trouver les compagnons et les conseils qui vous aiderons dans votre projet.\nFaites un tour ici pour connaitre quelques conseils qui pourront vous aider dans votre entreprise.\n\n4. Vous êtes sans emploi. Il est peut être temps de sortir de \ncette situation. Votre attitude fera la différence dans les entretiens d embauche. Pour cela, il vous faut un but, un objectif qui vous tient á coeur. Pourquoi avez vous besoin de cet emploi. ? qu´est ce qui vous motive ? Pourquoi êtes vous prêts ou prêtes a accepter un travail, qui pour le début , peut ne pas vous correspondre ou vous plaire.? Trouvez votre motivation et battez aux portes. Un poste vous attends. faites un tour ici pour en savoir plus sur la motivation.";
                else if (_selectedTheme == EThemes.Affective)
                    ResultText = "1.  Dans le cas oú  votre couple est en pleine turbulences, il serait judicieux de prendre vos distances. On ne parle pas de rupture ( Une rupture doit se faire la tête froide, aprés avoir analyser la situation avec discernement) et prendre vos distances va vous permettre de faire ce travail, de vous poser la question de ce que vous voulez vraiment dans votre relation.\n\n2. En cas de violences, partez dės que vous le pouvez. Trouvez de l' aide. Ne vous laissez pas intimider. Vous êtes victime et vous ne méritez pas toute cette violence quoi que vous pouvez en penser ou quoi que l on veut vous faire croire. Protégez vous. \n\n3. Si votre couple est tranquille, dans la norme, des hauts et des bas mais l' amour est au rendez vous, pourquoi ne pas pensez á sortir d' une certaine routine, de penser á des choses nouvelles pour pimenter le chemin ?\nFaites un tour ici, vous trouverez des idées.\n\n4. Si vous êtes célibataire et que cela vous incommode, il n' y a pas de raisons que ça dure si ce n' est votre mésestime qui vous sabote. Vous méritez d' être heureux ou heureuse en amour comme chacun d' entre nous. Pour changer votre situation, il faut faire l effort de travailler vos blocages, votre timidité, etc. Osez rencontrer un psychologue, un coach, ou toute autre personne qui pourront vous aider á vous épanouir. \nFaites un tour ici pour en savoir un peu plus sur la mesestime.\n";

                else if (_selectedTheme == EThemes.YesOrNo)
                {
                    Random random = new Random();
                    var number = random.Next(1, 3);

                    if (number == 1)
                        ResultText = "Sim!";
                    else if (number == 2)
                        ResultText = "Não!";
                }
            }

        }

        private async void GoToMainPage()
        {
            await _navigationService.NavigateAsync(new Uri("http://www.TheTarotWheel.com/NavigationPage/MainPage", UriKind.Absolute));
        }
        #endregion

        #region properties
        private string _resultText;
        public string ResultText
        {
            get { return _resultText; }
            set { SetProperty(ref _resultText, value); }
        }
        #endregion
    }
}
