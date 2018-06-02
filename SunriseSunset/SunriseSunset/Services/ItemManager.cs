using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunriseSunset.Models;
                   
namespace SunriseSunset.Services
{
    public class ItemManager
    {
        IRestServiceCountries restService;

        public ItemManager(IRestServiceCountries service)
        {
            restService = service;
        }

        public Task<List<Item>> GetCountriesTaskAsync(string country)
        {
            return restService.GetCountryIformationAsync(country);
        }
    }
}
