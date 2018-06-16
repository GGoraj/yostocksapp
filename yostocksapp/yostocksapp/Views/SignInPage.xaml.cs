using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using yostocksapp.Services;


namespace yostocksapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
		public SignInPage ()
		{
			InitializeComponent ();
		}

        private void TapSignUp_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void SignInBtn_Clicked(object sender, EventArgs e)
        {
            YostocksApiServices apiService = new YostocksApiServices();
            bool response = await apiService.LoginUser(EntEmail.Text, EntPassword.Text);
            if(!response)
            {
                await DisplayAlert("Error", "Wrong Username or Password", "Cancel");
            }
            else if(response)
            {
                Navigation.InsertPageBefore(new ParentTabbedPage(), this);
                await Navigation.PopAsync();
            }
        }
    }
}