using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xcourse.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        IObservable<(string username, string password)> _formValuesStream;
        IDisposable _validation;
		public LoginPage ()
		{
			InitializeComponent ();
            var userTextStream = Observable.FromEventPattern<TextChangedEventArgs>(x => usernameEntry.TextChanged += x, x => usernameEntry.TextChanged -= x);
            var pswTextStream = Observable.FromEventPattern<TextChangedEventArgs>(x => passwordEntry.TextChanged += x, x => passwordEntry.TextChanged -= x);
            _formValuesStream =
                userTextStream
                .CombineLatest(
                    pswTextStream,
                    (user, psw) => (username: user.EventArgs.NewTextValue, password: psw.EventArgs.NewTextValue));

            usernameEntry.Completed += UsernameEntry_Completed;
        }

        private void UsernameEntry_Completed(object sender, EventArgs e) => passwordEntry.Focus();

        private static bool UsernameValidator(string username) => username != null && username != string.Empty;
        private static bool PasswordValidator(string password) => password != null && password != string.Empty;
        private void OnLoginButtonClicked(object sender, ClickedEventArgs args)
        {
            if (Utils.AuthenticationManager.Login(usernameEntry.Text, passwordEntry.Text))
            {
                Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new RootPage()));
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    errorMessage.IsVisible = true;
                    passwordEntry.Text = string.Empty;
                    await Task.Delay(TimeSpan.FromSeconds(10));
                    errorMessage.IsVisible = false;
                });
            }
        } 

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _validation = _formValuesStream.Subscribe(val => loginButton.IsEnabled = UsernameValidator(val.username) && PasswordValidator(val.password));
            usernameEntry.Focus();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _validation.Dispose();
            usernameEntry.Completed -= UsernameEntry_Completed;
        }
    }
}