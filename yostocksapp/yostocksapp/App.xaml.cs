using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using yostocksapp.Helpers;
using yostocksapp.Data;
using yostocksapp.Views;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace yostocksapp
{
	public partial class App : Application
	{
        public static NewsApiManager NewsApiManager { get; private set; }

        //public static NewsApiManager NewsApiManager { get; private set; }
        public App()
        {
            InitializeComponent();
            
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                NewsApiManager = new NewsApiManager(new NewsApiService());
                MainPage = new NavigationPage(new ParentTabbedPage());
            }
            else if (string.IsNullOrEmpty(Settings.UserName) && string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new SignInPage());
            }
            

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
