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
    public partial class LoginRegister : ContentPage
    {
        public LoginRegister()
        {
            InitializeComponent();
            //adding a new bidning context to the registerUsers model. Since this is the first page, there is nothing yet attached
            BindingContext = new RegisterUsers();
        }
    }
}