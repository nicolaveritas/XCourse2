using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xcourse.Pages;
using Xcourse.Services;
using Xcourse.Utils;

namespace Xcourse
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = AuthenticationManager.IsLoggedIn() ? (Page)new NavigationPage(new RootPage()) : new LoginPage();

#pragma warning disable CS4014 // No need to await service
            LocationService.Instance.StartListening();
#pragma warning restore CS4014
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
