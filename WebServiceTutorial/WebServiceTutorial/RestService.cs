using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebServiceTutorial
{
    public class RestService 
    {
        HttpClient _client;

        public List<Repository> repositories { get; private set; }
        public Repository repository { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Repository>> GetRepositoriesAsync()
        {
            repositories = new List<Repository>();
            Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty));

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


        //working method to change data
        public async Task SaveRepository(Repository repository)
        {
            string RepId = "/" + repository.Id.ToString();
            Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty) + RepId);
            string json = JsonConvert.SerializeObject(repository);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


            HttpResponseMessage response = null;
            response = await _client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {

                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }


        }

        //public async Task SaveRepository(Repository repository)
        //{
        //    //string RepId = "/" + repository.Id.ToString();
        //    Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty));
        //    string json = JsonConvert.SerializeObject(repository);
        //    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


        //    HttpResponseMessage response = null;
        //    response = await _client.PostAsync(uri, content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Debug.WriteLine(@"\tTodoItem successfully saved.");
        //    }


        //}


        //not working yet 
        //public async Task<Repository> AddRepository(int id, string howto)
        //{
        //    Repository repository = new Repository()
        //    {
        //        Id = id,
        //        HowTo = howto,
        //    };

        //    Uri uri = new Uri(string.Format(Constants.GitHubReposEndpoint, string.Empty));

        //    string json = JsonConvert.SerializeObject(repository);
        //    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = null;
        //    response = await _client.PostAsync(uri, content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Debug.WriteLine(@"\tTodoItem successfully saved.");
        //    }

        //    return JsonConvert.DeserializeObject<Repository>(
        //       await response.Content.ReadAsStringAsync());


        //}



    }
}