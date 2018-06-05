using SunriseSunset.Models;
using Xamarin.Forms;

namespace SunriseSunset.Views
{
    public partial class ResultSunriseSunset : ContentPage
    {
        public ResultSunriseSunset(Item newItem)
        {
            InitializeComponent();
            string sunriseText = "Sunrise in " +  newItem.Country + " is at " + newItem.Sunrise;
            sunrise.Text = sunriseText;
            imageSunrise.Source = ImageSource.FromFile("sunriseapp.png");

            string sunsetText = "Sunset in " + newItem.Country + " is at " + newItem.Sunset;
            sunset.Text = sunsetText;
            imageSunset.Source = ImageSource.FromFile("sunsetapp.png");
        }
    }
}