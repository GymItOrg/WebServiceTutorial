using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceTutorial
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class RepositoryEntry : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRepository(value);
            }
        }

        public RepositoryEntry()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Repository();
        }

        void LoadRepository(string howTo)
        {
            try
            {
                // Retrieve the note and set it as the BindingContext of the page.
                Repository repository = new Repository
                {
                    HowTo = howTo,
                    //HowTo = File.ReadAllText(id),
                    //Date = File.GetCreationTime(id)
                };
                BindingContext = repository;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        //async void OnSaveButtonClicked(object sender, EventArgs e)
        //{
        //    var repository = (Repository)BindingContext;

        //    if (string.IsNullOrEmpty(repository.Id))
        //    {
        //        // Save the file.
        //        var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
        //        File.WriteAllText(filename, note.Text);
        //    }
        //    else
        //    {
        //        // Update the file.
        //        File.WriteAllText(note.Filename, note.Text);
        //    }

        //    // Navigate backwards
        //    await Shell.Current.GoToAsync("..");
        //}
    }
}
