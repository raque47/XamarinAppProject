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

        HttpClient clientSunriseSunset;

        public List<Item> Items { get; private set; }

        public RestServiceCountries()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Mashape-Key", "0QLx05ycbCmsh3lcpXAukYZcgQ3Qp1P6rZYjsn4d2aZy1bVRDp");
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            clientSunriseSunset = new HttpClient();
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
            //Debug.WriteLine(Items[0].Capital);

            return Items;
        }


        public async Task<List<Item>> GetSunriseAndSunset(float lat, float longitud)
        {
            Items = new List<Item>();
            string RestSunriseSunsetURL = "https://api.sunrise-sunset.org/json?lat={0}&lng={1}&date=today";
            var uri = new Uri(string.Format(RestSunriseSunsetURL, lat, longitud));
            try
            {
                var response = await clientSunriseSunset.GetAsync(uri);
   
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    int startIndex = 11;
                    int endIndex = content.Length - 27;
                    String substring = content.Substring(startIndex, content.Length - 26);
                    string finalResponse = substring.Insert(0, "[");
                    string finalContent = finalResponse.Insert(finalResponse.Length, "]");
                    Items = JsonConvert.DeserializeObject<List<Item>>(finalContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }  
    }
}