using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }
        async void LoginUser(object sender, EventArgs e)
        {
            await   Navigation.PushAsync(new LoginRegister());
        }
        async void RegisterUser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegistration());
        }
    }
}