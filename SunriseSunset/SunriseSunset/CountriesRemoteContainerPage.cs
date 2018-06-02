using System;
using SunriseSunset.Models;
using SunriseSunset.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using SunriseSunset.Views;
namespace SunriseSunset
{
    public class CountriesRemoteContainerPage : SearchPage
    {
        public ApiRestCountries Cliente { get; set; }
         
        public CountriesRemoteContainerPage()
        {
            Cliente = new ApiRestCountries();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            IsBusy = true;

            try
            {
                var json = await ApiRestCountriesClient.GetJsonAsync(CountrySelected);

                var itemResponse = JsonConvert.DeserializeObject<Item>(json.capital);


               /* SearchPage.labelCapital.Text = itemResponse.capital;

                SearchPage.Datos.Clear();

                foreach (var item in itemResponse)
                {
                    SearchPage.Datos.Add(item);
                } 
                */
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

