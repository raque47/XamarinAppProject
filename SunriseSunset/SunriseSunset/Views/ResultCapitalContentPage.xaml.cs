﻿using System;
using System.Collections.Generic;
using SunriseSunset.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SunriseSunset.Views
{
    public partial class ResultCapitalContentPage : ContentPage
    {
        public ResultCapitalContentPage(Item newItem)
        {
            InitializeComponent();
            capital.Text = newItem.Capital;


            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(newItem.Lat, newItem.Long),
                Label = "Country" + newItem.Country +", " + newItem.Capital,
                Address = ""
            };

            var position = new Position(newItem.Lat, newItem.Long);
            customMap.Circle = new CustomCircle
            {
                Position = position,
                Radius = 1000
            };

            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1.0)));
        }
    }
}
