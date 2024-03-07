using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using XAML_LoginForm.Models;
using XAML_LoginForm.Repositories;

namespace XAML_LoginForm.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;
        //Properties
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand<ICommand>(CanExecuteLoginCommand, ExecuteLoginCommand);
        }


        private bool CanExecuteLoginCommand(object obj)
        {
            bool canExecute = true;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 6
                || string.IsNullOrEmpty(Password) || Password.Length < 6)
            {
                canExecute = false;
            }
            return canExecute;
        }
        private void ExecuteLoginCommand(object t)
        {
            var validate = userRepository.AuthenicateUser(new NetworkCredential(Username, Password));
            if (validate)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid Username or Password";
            }
        }
    }
}
