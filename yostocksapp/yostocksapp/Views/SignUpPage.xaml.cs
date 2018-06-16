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
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            YostocksApiServices service = new YostocksApiServices();
            
            bool response = await service.RegisterUser(EntEmail.Text, EntPassword.Text, EntConfirmPassword.Text);
            if (!response)
            {
                await DisplayAlert("Alert", "Something wrong...\n perhaps your account already exists?", "Cancel");

            }
            else
            {
                await DisplayAlert("Hi", "Your account has been created", "Ok");
                await Navigation.PopToRootAsync();
            }

        }
    }
}