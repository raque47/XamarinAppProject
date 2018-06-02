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

        public SearchPage()
        {
            InitializeComponent();
            //isNewItem = isNew;
            CapitalFromResponse = null;
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

            string capital = CapitalFromResponse[0].Capital;
            ResultCapitalContentPage view = new ResultCapitalContentPage(capital);
            await Navigation.PushAsync(view);

        }

        void OnCancelActivated(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
