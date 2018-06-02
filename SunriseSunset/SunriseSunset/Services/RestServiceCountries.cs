using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SunriseSunset.Models;

namespace SunriseSunset.Services
{
    public class RestServiceCountries : IRestServiceCountries
    {
        HttpClient client;

        public List<Item> Items { get; private set; }

        public RestServiceCountries()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Mashape-Key", "0QLx05ycbCmsh3lcpXAukYZcgQ3Qp1P6rZYjsn4d2aZy1bVRDp");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

        }


        public async Task<List<Item>> GetCountryIformationAsync(string country)
        {
            Items = new List<Item>();
            string RestCountriesURL = "https://restcountries-v1.p.mashape.com/name/{0}";
            var uri = new Uri(string.Format(RestCountriesURL, country));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Item>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            Debug.WriteLine(Items[0].Capital);

            return Items;
        }
    }
}
