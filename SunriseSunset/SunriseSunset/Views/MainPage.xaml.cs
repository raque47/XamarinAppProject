using System;
using System.Collections.Generic;
using SunriseSunset.Models;

using Xamarin.Forms;

namespace SunriseSunset.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //masterPage.ListView.ItemSelected += OnItemSelected;
        }

        void OnSearchCapitalItemClicked(object sender, EventArgs e)
        {
            var item = new Item()
            {
                ID = Guid.NewGuid().ToString()
            };
            var todoPage = new SearchPage("Capital");
            todoPage.BindingContext = item;
            Navigation.PushAsync(todoPage);
        }

        void OnSearchSunsetSunriseItemClicked(object sender, EventArgs e)
        {
            var item = new Item()
            {
                ID = Guid.NewGuid().ToString()
            };
            var todoPage = new SearchPage("Sunrise");
            todoPage.BindingContext = item;
            Navigation.PushAsync(todoPage);
        }

        void OnAbout(object sender, EventArgs e){
            var viewAbout = new AboutPage();
            Navigation.PushAsync(viewAbout);
        }
    }
}
