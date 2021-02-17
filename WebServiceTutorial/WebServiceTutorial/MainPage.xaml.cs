using System;
using System.Collections.Generic;
using System.Linq;
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
            //List<Repository> repositories = await _restService.GetRepositoriesAsync(Constants.GitHubReposEndpoint);
            //string content = await _restService.GetRepositoriesAsync();
            List<Repository> repositories = await _restService.GetRepositoriesAsync();
            MyListView.ItemsSource = repositories;
        }


        async void OnListViewItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the filename as a query parameter.
                Repository repository = (Repository)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(RepositoryEntry)}?{nameof(RepositoryEntry.ItemId)}={repository.Id}");
            }
        }

        //async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem != null)
        //    {
        //        await Navigation.PushAsync(new NoteEntryPage
        //        {
        //            BindingContext = e.SelectedItem as Note
        //        });
        //    }
        //}
    }
}