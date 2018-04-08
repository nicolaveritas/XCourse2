using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xcourse.Models;
using Xcourse.Services;

namespace Xcourse.Pages.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScanTemplate : ContentView
	{
        private ObservableCollection<ScanItem> BarcodeList;
		public ScanTemplate ()
		{
			InitializeComponent ();
            BarcodeList = new ObservableCollection<ScanItem>()
            {
                new ScanItem
                {
                    Barcode = "234234",
                    Timestamp = DateTime.Now.AddDays(-1),
                }
            };
            barcodeList.ItemsSource = BarcodeList;
		}

        private async void OnTriggerTapped(object sender, TappedEventArgs args)
        {
            await trigger.ScaleTo(0.95, 100, easing: Easing.SinIn);
            await trigger.ScaleTo(1, 100, easing: Easing.SinIn);

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
            if (result != null)
            {
                var location = await LocationService.Instance.GetCurrentPosition();
                var item = new ScanItem
                {
                    Barcode = result.Text,
                    Timestamp = new DateTime(result.Timestamp),
                    Location = location
                };
                BarcodeList.Add(item);
            }
                
        }
	}
}