using System;
using Xamarin.Forms;
using SunriseSunset.Services;
using SunriseSunset.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SunriseSunset
{
    public partial class App : Application
    {
        public static ItemManager ItemManager { get; private set; }

        public App()
        {
            ItemManager = new ItemManager(new RestServiceCountries());
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new MainPage();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
