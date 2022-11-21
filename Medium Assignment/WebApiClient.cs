using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Medium_Assignment.Models;
using Medium_Assignment.Controllers;
using System.Web.Http;

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

            try {

                var Res = await client.PostAsync("token", new FormUrlEncodedContent(data));

                var response = await Res.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);


                if (Res.IsSuccessStatusCode)
                {
                    content.IsSuccess = true;
                    content.AccessToken = json["access_token"];
                    content.TokenType = json["token_type"];
                    content.ExpiresIn = TimeSpan.Parse(json["expires_in"]);
                    content.UserName = json["userName"];
                    content.Issued = DateTime.Parse(json[".issued"]);
                    content.Expires = DateTime.Parse(json[".expires"]);
                }
                else {
                    content.StatusCode = Res.StatusCode;
                    content.IsSuccess = false;
                    content.Errors.Add(json["error_description"]);
                }

            } catch (HttpRequestException e) {
                content.IsSuccess = false;
                content.Errors.Add(e.Message);
            }
            
            return content;
        }

        public async Task<BindingModel> Get<BindingModel>(string resourcePath) where BindingModel: WebAPIClientBindingModel
        {


            BindingModel content = default(BindingModel);

            var client = new HttpClient();

            
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            try {
                var Res = await client.GetAsync($"api/{resourcePath}");

                var response = await Res.Content.ReadAsStringAsync();

                content = JsonConvert.DeserializeObject<BindingModel>(response);

                if (Res.IsSuccessStatusCode)
                {
                    content.IsSuccess = true;
                }
                else {
                    var json = JsonConvert.DeserializeObject<BindingModel>(response);
                    content.IsSuccess = false;
                    content.StatusCode = Res.StatusCode;
                    content.Errors = json.Errors;
                }

                

            }
            catch (HttpRequestException e)
            {
                content.IsSuccess = false;
                content.Errors.Add(e.Message);
            }

            return content;

        }


        public async Task<BindingModel> Get<BindingModel>(string resourcePath, int id) where BindingModel : WebAPIClientBindingModel
        
        {

            BindingModel content = default(BindingModel);

            var client = new HttpClient();

            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            try
            {
                var Res = await client.GetAsync($"api/{resourcePath}/{id}");

                var response = await Res.Content.ReadAsStringAsync();

                content = JsonConvert.DeserializeObject<BindingModel>(response);

                if (Res.IsSuccessStatusCode)
                {
                    content.IsSuccess = true;
                }
                else
                {
                    var json = JsonConvert.DeserializeObject<BindingModel>(response);
                    content.IsSuccess = false;
                    content.StatusCode = Res.StatusCode;

                    content.Errors = json.Errors;
                }

            }
            catch (HttpRequestException e)
            {
                content.IsSuccess = false;
                content.Errors.Add(e.Message);
            }

            return content;

        }

        public async Task<BindingModel> Post<BindingModel>(string resourcePath, BindingModel model) where BindingModel : WebAPIClientBindingModel
        {
            var client = new HttpClient();
            
            //Passing service base url
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            try
            {
                var Res = await client.PostAsJsonAsync($"api/{resourcePath}", model);

                var response = await Res.Content.ReadAsStringAsync();

                if (Res.IsSuccessStatusCode)
                {
                    model.IsSuccess = true;
                }
                else
                {
                    var json = JsonConvert.DeserializeObject<BindingModel>(response);
                    model.IsSuccess = false;
                    model.StatusCode = Res.StatusCode;
                    model.Errors = json.Errors;
                }

            } 

            catch (HttpRequestException e) {
                model.IsSuccess = false;
                model.Errors.Add(e.Message);
            }

            return model;
        }

        public async Task<BindingModel> Put<BindingModel>(string resourcePath, int id, BindingModel model) where BindingModel : WebAPIClientBindingModel

        {
            var client = new HttpClient();

            //Passing service base url
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            try {
                var Res = await client.PutAsJsonAsync($"api/{resourcePath}/{id}", model);

                var response = await Res.Content.ReadAsStringAsync();

                if (Res.IsSuccessStatusCode)
                {
                    model.IsSuccess = true;

                }
                else
                {
                    var json = JsonConvert.DeserializeObject<BindingModel>(response);
                    model.IsSuccess = false;
                    model.StatusCode = Res.StatusCode;
                    model.Errors = json.Errors;
                }

            }

            catch (HttpRequestException e)
            {
                model.IsSuccess = false;
                model.Errors.Add(e.Message);
            }


            return model;

        }

        public async Task<BindingModel> Delete<BindingModel>(string resourcePath, int id) where BindingModel : WebAPIClientBindingModel

        {
            BindingModel model = default(BindingModel);

            var client = new HttpClient();

            //Passing service base url
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            
            try {
                var Res = await client.DeleteAsync($"api/{resourcePath}/{id}");

                var response = await Res.Content.ReadAsStringAsync();

                if (Res.IsSuccessStatusCode)
                {
                    model.IsSuccess = true;

                }
                else
                {
                    var json = JsonConvert.DeserializeObject<BindingModel>(response);
                    model.IsSuccess = false;
                    model.StatusCode = Res.StatusCode;
                    model.Errors = json.Errors;
                }

            }

            catch (HttpRequestException e)
            {
                model.IsSuccess = false;
                model.Errors.Add(e.Message);
            }



            return model;
        }




    }
}