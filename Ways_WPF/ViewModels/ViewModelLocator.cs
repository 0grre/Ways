using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Ways_WPF.Services;
using Ways_WPF.Views;

namespace Ways_WPF.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<StartViewModel>();
            SimpleIoc.Default.Register<AdminLoginViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure(nameof(Home), new Uri("../Views/Home.xaml", UriKind.Relative));
            navigationService.Configure(nameof(Start), new Uri("../Views/Start.xaml", UriKind.Relative));
            navigationService.Configure(nameof(AdminLogin), new Uri("../Views/AdminLogin.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public StartViewModel StartViewModel => ServiceLocator.Current.GetInstance<StartViewModel>();
        public AdminLoginViewModel AdminLoginViewModel => ServiceLocator.Current.GetInstance<AdminLoginViewModel>();

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}