using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ways_DAO.Models;
using Ways_DAO.Repositories;
using Ways_WPF.Services;
using Ways_WPF.Views;

namespace Ways_WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        
        private User _candidate;
        private UserRepository _userRepository;

        private string _username;

        public string Username
        {
            get => this._username;
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (string.Equals(this._username, value)) return;
                this._username = value;
                this.RaisePropertyChanged();
            }
        }

        public ICommand NavigateCommand { get; set; }

        public HomeViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand<string>(ActionNavigate);
            _userRepository = new UserRepository();
        }

        private void ActionNavigate(string page)
        {
            switch (page)
            {
                case "start":
                    if (Username is null)
                        MessageBox.Show("Please enter a username !", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                    //_candidate = _userRepository.Create(new User(Username));
                    _navigationService.NavigateTo(nameof(Start), new User(Username));

                    break;
                case "admin":
                    _navigationService.NavigateTo(nameof(AdminLogin));
                    break;
            }
        }
    }
}