using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xcourse.Models
{
    public class ScanItem
    {
        public string Barcode { get; set; }
        public DateTime Timestamp { get; set; }
        public Position Location { get; set; }
    }
}
