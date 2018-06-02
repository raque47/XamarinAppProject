using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using SunriseSunset.Models;
using System.Diagnostics;
using SunriseSunset.Services;

namespace SunriseSunset.Services
{
    public class ApiRestCountries : IDataStore<Item>
    {
        HttpClient client;
        IEnumerable<Item> items;
        public const string SERVICE_ENDPOINT = "https://restcountries-v1.p.mashape.com/";


        public ApiRestCountries()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{SERVICE_ENDPOINT}/");
            items = new List<Item>();
        }

        //IEnumerable<Item> items;
        public async Task<Item> GetJsonAsync(string name)
        {
            if (name != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"/name/{name}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
           // items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}

// json a c#  push modal
//cusrom render
//popasync praa q el usuaario vuelve a al pagina anaterior 
//Mapa msa especifico 
//Segemented 