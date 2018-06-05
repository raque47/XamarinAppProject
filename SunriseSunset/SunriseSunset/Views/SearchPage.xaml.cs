using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SunriseSunset.Models;
using SunriseSunset.Services;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using SunriseSunset.Views;

namespace SunriseSunset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        //bool isNewItem;
        List<Item> CapitalFromResponse;
        List<Item> SunriseSunsetResponse;
        public string Type;

        public SearchPage(string searchType)
        {
            InitializeComponent();
            //isNewItem = isNew;
            CapitalFromResponse = null;
            SunriseSunsetResponse = null;
            Type = searchType;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            CapitalFromResponse = await App.ItemManager.GetCountriesTaskAsync("Costa Rica");
        }

        async void OnDeleteActivated(object sender, EventArgs e)
        {
            var todoItem = (Item)BindingContext;
            string countryEntered = todoItem.Country;
            CapitalFromResponse = await App.ItemManager.GetCountriesTaskAsync(countryEntered);
            if(CapitalFromResponse != null & CapitalFromResponse.Count > 0)
            {
                string capital = CapitalFromResponse[0].Capital;
                float[] latLong = CapitalFromResponse[0].Latlng;
                float latitud = latLong[0];
                float longitud = latLong[1];
                
                if(Type == "Capital"){
                    Item newItem = new Item();
                    newItem.Capital = capital;
                    newItem.Lat = latitud;
                    newItem.Long = longitud;
                    ResultCapitalContentPage view = new ResultCapitalContentPage(newItem);
                    await Navigation.PushAsync(view); 
                }
                else{
                    Item itemSunriseSunset = new Item();
                    itemSunriseSunset.Capital = capital;
                    itemSunriseSunset.Lat = latitud;
                    itemSunriseSunset.Long = longitud;
                    SunriseSunsetResponse = await App.ItemManager.GetSunriseAndSunset(latitud,longitud);
                    itemSunriseSunset.Sunset = SunriseSunsetResponse[0].Sunset;
                    itemSunriseSunset.Sunrise = SunriseSunsetResponse[0].Sunrise;
                    ResultSunriseSunset view = new ResultSunriseSunset(itemSunriseSunset);
                    await Navigation.PushAsync(view); 
                }


            }
        }

        void OnCancelActivated(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
