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
	public partial class GymsPage : ContentPage
	{
        RestService _restService;

        public GymsPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void ViewGymsClicked(object sender, EventArgs e)
        {
            var accessToken = Settings.AccessToken;
            Debug.WriteLine(accessToken);
            List<Gyms> gyms = await _restService.GetGymsAsync(accessToken);
            MyGymList.ItemsSource = gyms;
        }





    }
}