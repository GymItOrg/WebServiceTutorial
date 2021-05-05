using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class LoginRegister : ContentPage
    {
        RestService _restService;
        public LoginRegister()
        {
            InitializeComponent();
            //adding a new bidning context to the loginUsers model. Since this is the first page, there is nothing yet attached
            BindingContext = new LoginUsers();
            _restService = new RestService();
        }

        async void LoginUser(object sender, EventArgs e)
        {
            var existingUser = (LoginUsers)BindingContext;
            Settings.AccessToken = await _restService.LoginExistingUser(existingUser);

            Debug.WriteLine(Settings.AccessToken);

            await Navigation.PushAsync(new MainPage());
        }
    }
}