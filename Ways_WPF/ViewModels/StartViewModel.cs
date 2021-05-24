using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ways_DAO.Models;
using Ways_WPF.Services;

namespace Ways_WPF.ViewModels
{
    public class StartViewModel: ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        public ICommand NavigateCommand { get; set; }

        private User _user;
        private string _username;


        public string Username
        {
            get => _username;
            set
            {
                if (_username == value)
                    return;

                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        public StartViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand<string>(ActionNavigate);
            _user = _navigationService.Parameter as User;
            if (_user != null)
            {
                Username = _user.UserName;
            }
        }

        private void ActionNavigate(string page)
        {
            switch (page)
            {
                case "orientation":
                    break;
                case "game":
                    break;
            }
        }
    }
}