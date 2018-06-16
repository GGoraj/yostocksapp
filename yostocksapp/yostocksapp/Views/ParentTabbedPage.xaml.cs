using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using yostocksapp.Helpers;

namespace yostocksapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParentTabbedPage : TabbedPage
    {
        public ParentTabbedPage ()
        {
            InitializeComponent();
            Children.Add(new BrandsPage());
            Children.Add(new NewsPage());
            

            
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            Settings.UserName = "";
            Settings.Password = "";
            Settings.AccessToken = "";
            Navigation.InsertPageBefore(new SignInPage(), this);
            Navigation.PopAsync();
        }
    }
}