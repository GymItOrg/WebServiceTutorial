using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTutorial.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegistrationPage1 : ContentPage
    {
        RestService _restService;
        public UserRegistrationPage1()
        {
            InitializeComponent();
            BindingContext = new RegisterUsers();

            _restService = new RestService();
        }

        async void OnNextButtonClicked(object sender, EventArgs e)
        {
            var newUser = (RegisterUsers)BindingContext;
            //await _restService.AddNewUser(newUser);

            await Navigation.PushAsync(new UserRegistration
            {
                BindingContext = newUser as RegisterUsers
            });
        }
    }
}