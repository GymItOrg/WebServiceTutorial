using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceTutorial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemAddPage : ContentPage
	{

        //step 5: each .xaml.cs file needs to reference a new instance of the RestService class
        RestService _restService;
        public ItemAddPage ()
		{
			InitializeComponent ();

            //step 6: On the xaml page, we bound the text element. We want a new item so we set the bidnding context to a new Repository. Now the bound text element will reference a new Repositroy
            BindingContext = new Repository();
            //step 7: create a new instance of RestService 
            _restService = new RestService();
        }

        //step 8: add code for the OnAddBUttonClicked click event 
        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            //step 8: refernce the bound text element and set it to the Repository item
            var repository = (Repository)BindingContext;
            //step 9: Pass the new repository item to the AddRepository RestService method. We will need to code this method in RestService.CS
            await _restService.AddRepository(repository);
            //step 10: navigate back to the MainPage
            await Navigation.PopAsync();
            
        }
    }
}