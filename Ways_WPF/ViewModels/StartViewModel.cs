using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ways_DAO.Models;
using Ways_WPF.Services;
using Question = Ways_WPF.Views.Question;

namespace Ways_WPF.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        #region Interfaces

        private IFrameNavigationService _navigationService;
        public ICommand NavigateCommand { get; set; }

        #endregion

        private User _user;

        public StartViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand<string>(ActionNavigate);
            _user = _navigationService.Parameter as User;
        }

        private void ActionNavigate(string type)
        {
            _navigationService.NavigateTo(nameof(Question), new UserQuestionTypeParameter(_user, type) );
        }
        
        public class UserQuestionTypeParameter
        {
            public User User { get; set; }
            public string Type { get; set; }

            public UserQuestionTypeParameter(User user, string type)
            {
                User = user;
                Type = type;
            }
        }
    }
}