using System;

namespace SunriseSunset.Models
{
    public class Item
    {
        public string ID { get; set; }

        public string Country { get; set; }

        public string Capital { get; set; }

        public string Region { get; set; }

        public string Population { get; set; }

        public float[] Latlng { get; set; } 

        public float Lat { get; set; }

        public float Long { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set; }
    }
}