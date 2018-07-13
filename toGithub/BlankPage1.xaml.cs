using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;
using System.Net.Http;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CSCapstone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        IMobileServiceTable<AppLogins> todoTable = App.MobileService.GetTable<AppLogins>();
        MobileServiceCollection<AppLogins, AppLogins> items;

        public class Contact
        {
            public int ID { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string favoriteMake { get; set; }
        }


        public class AppLogins
        {
            public string Id { get; set; }
            public string Text { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string favoriteMake { get; set; }

            internal static object where(Func<object, bool> p)
            {
                throw new NotImplementedException();
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        async private void register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppLogins item = new AppLogins
                {
                    username = username.Text,
                    password = password.Text,
                    favoriteMake = favoriteMake.Text,
                };
                await App.MobileService.GetTable<AppLogins>().InsertAsync(item);
                var dialog = new MessageDialog("Successful!");
                await dialog.ShowAsync();
            }
            catch (Exception em)
            {
                var dialog = new MessageDialog("An Error Occured: " + em.Message);
                await dialog.ShowAsync();
            }
        }

        private void username_TextChanged()
        {

        }
    }
}
