using System;
using System.Data.SqlClient;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ways_DAO.Models;
using Ways_DAO.Repositories;
using Ways_DAO.Services;
using Ways_WPF.Services;

namespace Ways_WPF.ViewModels
{
    public class AdminLoginViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private AdminUserRepository _adminUserRepository;
        private string _email;

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public ICommand LoginCommand { get; set; }


        public AdminLoginViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new RelayCommand<object>(ActionLogin);
            _adminUserRepository = new AdminUserRepository();
        }

        private void ActionLogin(object o)
        {
            string password;
            PasswordBox passwordBox;
            AdminUser admin = null;

            try
            {
                passwordBox = (o as System.Windows.Controls.PasswordBox);
                password = passwordBox.Password;
                
                // todo handle case no field is filled
                if (_email.Length == 0) throw new ArgumentException("Please enter an email !");
                if (password.Length == 0) throw new ArgumentException("Please enter a password !");
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                
                return;
            }

            try
            {
                admin = Security.Login(_email, password);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            MessageBox.Show($"Email {Email}, Pwd {password}", "Successfully Authenticated !", MessageBoxButton.OK, MessageBoxImage.Information);
            passwordBox.Clear();

            
            //_navigationService.NavigateTo(nameof(AdminHome), admin);
        }
    }
}