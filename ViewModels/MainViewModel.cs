﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using XAML_LoginForm.Models;
using XAML_LoginForm.Repositories;

namespace XAML_LoginForm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel? _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel? CurrentUserAccount 
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null) 
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;";
                CurrentUserAccount.ProfilePictue = null;
                
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid User, not logged in";
                //hide child views
            }
        }
    }
}
