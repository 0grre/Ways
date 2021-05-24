using GalaSoft.MvvmLight.Views;

namespace Ways_WPF.Services
{
    public interface IFrameNavigationService: INavigationService
    {
        object Parameter { get; }
    }
}