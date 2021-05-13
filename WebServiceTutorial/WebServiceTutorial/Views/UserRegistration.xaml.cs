﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTutorial.Helpers;
using WebServiceTutorial.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegistration : ContentPage
    {
        RestService _restService;
        public UserRegistration()
        {
            InitializeComponent();
            //BindingContext = new RegisterUsers();

            _restService = new RestService();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var newUser = (RegisterUsers)BindingContext;
            await _restService.AddNewUser(newUser);

            Settings.Username = newUser.userName;
            Settings.Password = newUser.Password;

            await Navigation.PushAsync(new LoginRegister());
        }
    }
}