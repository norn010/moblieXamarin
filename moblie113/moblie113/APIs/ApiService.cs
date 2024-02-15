using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using moblie113.Models;
using Newtonsoft.Json;


namespace moblie113.APIs
{
    internal class ApiService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "http://10.0.2.2:50418/api/";

        public ApiService()
        {
            _client = new HttpClient();
        }
        public async Task<ObservableCollection<BookModel>> GetBooks()
        {
            ObservableCollection<BookModel> Items = null;

            try
            {
                var response = await _client.GetAsync($"{_baseUrl}/books1");
                if (response.IsSuccessStatusCode) 
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ObservableCollection<BookModel>>(content);
                    return Items;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }
            return null;
        }
        public async Task<bool> AddBook(BookModel item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_baseUrl + "books1", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBook(BookModel item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_baseUrl + "books1/" + item.book_Id, content);
            return response.IsSuccessStatusCode;
        }
    }
}


        /*public async Task<bool> Register(Register Item)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Item);
                StringContent sContent = new StringContent(json,Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Http://10.0.2.2:59360/api/Account/Register", sContent);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }*/
    
