using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Medium_Assignment.Models;
using Medium_Assignment.Controllers;

namespace Medium_Assignment
{
    public class WebApiClient
    {
        public string BaseURL { get; set; }
        public string AuthToken { get; set; }
        
        public WebApiClient() { 
            BaseURL = "https://localhost:44357/";
        }

        public WebApiClient(string AuthToken)
        {
            BaseURL = "https://localhost:44357/";
            this.AuthToken = AuthToken;
        }

        public async Task<AuthTokenViewModel> Authenticate(AuthTokenBindingModel model) {

            var content = new AuthTokenViewModel();

            var client = new HttpClient();

            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();

            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", model.grant_type),
                new KeyValuePair<string, string>("username", model.username),
                new KeyValuePair<string, string>("password", model.password),
            };

            var Res = await client.PostAsync("token", new FormUrlEncodedContent(data));

            if (Res.IsSuccessStatusCode)
            {
                var response = await Res.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                
                content.AccessToken = json["access_token"];
                content.TokenType = json["token_type"];
                content.ExpiresIn = TimeSpan.Parse(json["expires_in"]);
                content.UserName = json["userName"];
                content.Issued = DateTime.Parse(json[".issued"]);
                content.Expires = DateTime.Parse(json[".expires"]);
            }

            return content;
        }

        public async Task<ViewModel> Get<ViewModel>(string resourcePath)
        {

           
            ViewModel content = default(ViewModel);

            var client = new HttpClient();
            
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);


            var Res = await client.GetAsync($"api/{resourcePath}");

            if (Res.IsSuccessStatusCode)
            {
                var response = await Res.Content.ReadAsStringAsync();

                content = JsonConvert.DeserializeObject<ViewModel>(response);
            }

            

            return content;

        }



        public async Task<ViewModel> Get<ViewModel>(string resourcePath, int id) {

            ViewModel content = default(ViewModel);

            var client = new HttpClient();

            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);


            var Res = await client.GetAsync($"api/{resourcePath}/{id}");

            if (Res.IsSuccessStatusCode)
            {
                var response = await Res.Content.ReadAsStringAsync();

                content = JsonConvert.DeserializeObject<ViewModel>(response);
            }



            return content;

        }

        public async Task<bool> Post<BindingModel>(string resourcePath, BindingModel model) {
            var client = new HttpClient();
            
            //Passing service base url
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var Res = await client.PostAsJsonAsync($"api/{resourcePath}", model);

            return Res.IsSuccessStatusCode;
        }

        public async Task<bool> Put<BindingModel>(string resourcePath, int id, BindingModel model)
        {
            var client = new HttpClient();

            //Passing service base url
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var Res = await client.PutAsJsonAsync($"api/{resourcePath}/{id}", model);

            return Res.IsSuccessStatusCode;

        }

        public async Task<bool> Delete(string resourcePath, int id)
        {

            var client = new HttpClient();

            //Passing service base url
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var Res = await client.DeleteAsync($"api/{resourcePath}/{id}");

            return Res.IsSuccessStatusCode;
        }




    }
}