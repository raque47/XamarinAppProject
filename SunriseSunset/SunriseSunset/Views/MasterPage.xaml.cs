using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SunriseSunset.Views
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MasterPage()
        {
            InitializeComponent();
        }
    }
}
