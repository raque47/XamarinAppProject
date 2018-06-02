using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SunriseSunset.Views
{
    public partial class ResultCapitalContentPage : ContentPage
    {
        public ResultCapitalContentPage(string CapitalResponse)
        {
            InitializeComponent();
            capital.Text = CapitalResponse;
        }
    }
}
