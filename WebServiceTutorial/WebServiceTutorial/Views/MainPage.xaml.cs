using System;
using System.Collections.Generic;
using System.Linq;
using WebServiceTutorial.Views;
using Xamarin.Forms;

namespace WebServiceTutorial
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            
            List<Repository> repositories = await _restService.GetRepositoriesAsync();
            MyListView.ItemsSource = repositories;
        }


        //step 2:add code to the click event
        async void OnAddClicked(object sender, EventArgs e)
        {
            //step 3: Use the navigation class and PushAsynch to go to a different page and reference it in the method
            //ste[ 4: create a new xaml item call "ItemAddPage" (this is already been done) 
            await Navigation.PushAsync(new ItemAddPage());
        }

        async void OnGymViewClicked(object sender, EventArgs e)
        {            
            await Navigation.PushAsync(new GymsPage());
        }



        //walkthrough read version tutorial 
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new RepositoryEntry
                {
                    BindingContext = e.SelectedItem as Repository
                });
            }
        }
    }
}