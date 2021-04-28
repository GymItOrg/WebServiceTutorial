using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServiceTutorial.Models;

namespace WebServiceTutorial
{
    public class RestService 
    {
        HttpClient _client;

        public List<Repository> repositories { get; private set; }
        public Repository repository { get; private set; }
        public List<Gyms> gyms { get; private set; }
        public Gyms gym { get; private set; }
        public RegisterUsers newUser { get; private set; }
        public  LoginUsers existingUser { get; private set; }


        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Repository>> GetRepositoriesAsync()
        {
            repositories = new List<Repository>();
            Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty)+"/commands");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<List<Repository>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return repositories;
        }

        public async Task<List<Gyms>> GetGymsAsync()
        {
            gyms = new List<Gyms>();
            Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty)+ "/Places");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    gyms = JsonConvert.DeserializeObject<List<Gyms>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return gyms;
        }


        //working method to change data
        public async Task SaveRepository(Repository repository)
        {
            string RepId = "/" + repository.Id.ToString();
            Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty) + "/commands" + RepId);
            string json = JsonConvert.SerializeObject(repository);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await _client.PutAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {

                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }


        //step 11: crate method for AddRepositry 
        public async Task AddRepository (Repository repository)
        {
            //step 12: build the URL to make the api call            
            Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty) + "/commands");

            //step 13: Serialize the repository from the previous page. This basically makes it ingestable for the API to pass it to the database
            string json = JsonConvert.SerializeObject(repository);

            //step 14: build the string (called content) that you will pass into the PostAsynch method
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            //step 15: pass your url and your content into your PostAsynch method which will add the data item to the database
            response = await _client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }

        public async Task DeleteRepository(Repository repository)
        {
            string RepId = "/" + repository.Id.ToString();
            Uri uri = new Uri( string.Format(Constants.GitHubReposEndpoint, string.Empty) + "/commands" + RepId);
            HttpResponseMessage response = null;
            response = await _client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {

                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }

        public async Task AddNewUser(RegisterUsers newUser)
        {
                   
            Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty) + "/Authentication/register");
            string json = JsonConvert.SerializeObject(newUser);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            //Debug.WriteLine(content.ToString());

            response = await _client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {

                Debug.WriteLine(@"\user successfully added.");
            }
        }

        public async Task LoginExistingUser(LoginUsers existingUser)
        {

            Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty) + "/Authentication/login");
            string json = JsonConvert.SerializeObject(existingUser);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            //Debug.WriteLine(content.ToString());

            response = await _client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {

                Debug.WriteLine(@"\login successful.");
            }
        }



    }
}