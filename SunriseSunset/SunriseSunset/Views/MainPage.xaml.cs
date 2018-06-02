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
                var todoPage = new SearchPage();
                todoPage.BindingContext = item;
                Navigation.PushAsync(todoPage);
            }
           /* void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                var item = e.SelectedItem as MasterPageItem;

                if (item != null)
                {
                    if (item.Title == "Capital")
                    {
                        var todoItem = new Item()
                        {
                            ID = Guid.NewGuid().ToString()
                        };
                        var todoPage = new SearchPage(true);
                        todoPage.BindingContext = todoItem;
                        Navigation.PushAsync(todoPage);
                    }
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
            }*/
    }
}
