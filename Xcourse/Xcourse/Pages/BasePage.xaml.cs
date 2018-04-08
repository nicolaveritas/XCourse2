using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xcourse.Utils;

namespace Xcourse.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasePage : ContentPage
	{
		public BasePage ()
		{
			InitializeComponent ();
		}

        private void OnLogoutClicked(object sender, ClickedEventArgs args)
        {
            AuthenticationManager.Logout();
            Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new Xcourse.Pages.LoginPage());
        }
	}
}