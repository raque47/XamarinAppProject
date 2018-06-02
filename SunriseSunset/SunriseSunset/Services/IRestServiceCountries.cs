using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunriseSunset.Models;


namespace SunriseSunset.Services
{
    public interface IRestServiceCountries
    {
        Task<List<Item>> GetCountryIformationAsync(string country);
    }
}


