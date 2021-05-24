using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ways_WPF.Services;

namespace Ways_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _loadedCommand;

        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                       ?? (_loadedCommand = new RelayCommand(
                           () => { _navigationService.NavigateTo("Home"); }));
            }
        }

        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}