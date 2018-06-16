using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using yostocksapp.Helpers;
using yostocksapp.Models;

namespace yostocksapp.Services
{
    public class YostocksApiServices
    {
        public YostocksApiServices()
        {
            //
        }

        public async Task<bool> RegisterUser(string email, string password, string confirmPassword)
        {
            var registerModel = new RegisterModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var httpClient = new HttpClient();
            
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //Registering User
            var response = await httpClient.PostAsync("http://192.168.1.163:5000/api/Account/Register", content);
            return response.IsSuccessStatusCode;
        }
        
        public async Task<bool> LoginUser(string email, string password)
        {
            var keyvalues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.1.163:5000/Token");
            request.Content = new FormUrlEncodedContent(keyvalues);
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);

            //requesting Token
            var content = await response.Content.ReadAsStringAsync();
            JObject jObject = JsonConvert.DeserializeObject<dynamic>(content); // Microsoft.CSharp package (for use of 'dynamic' type)
            var accessToken = jObject.Value<string>("access_token");
            Settings.AccessToken = accessToken;
            return response.IsSuccessStatusCode;
        }

        public async void GetUserProfile(int userId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "We will add the token here" );
            var apiUrl = "http://192.168.1.163:5000/api/YostocksUsers/GetUserProfile";
            var json = await httpClient.GetStringAsync($"{apiUrl}?UserId={userId}");
            //JsonConvert.DeserializeObject<User>
        }


    }
}
