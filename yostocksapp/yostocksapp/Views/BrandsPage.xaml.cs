using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using yostocksapp.ViewModels;

namespace yostocksapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BrandsPage : ContentPage
	{
		public BrandsPage ()
		{
			InitializeComponent ();
            BindingContext = new BrandsViewModel();
        }

        async Task OnBuyClickedAsync(object sender, EventArgs e)
        {

            var action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
            Debug.WriteLine("Action: " + action);
        }
    }
}