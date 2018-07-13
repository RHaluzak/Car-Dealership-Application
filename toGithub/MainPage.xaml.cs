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

using SQLite;
using SQLite.Net;
using SQLite.Net.Async;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;




// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CSCapstone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        IMobileServiceTable<AppLogins> todoTable = App.MobileService.GetTable<AppLogins>();
        MobileServiceCollection<AppLogins, AppLogins> items;

        private IMobileServiceSyncTable<AppLogins> todoGetTable = App.MobileService.GetSyncTable<AppLogins>();

        public int IsAuth { get; set; }

        public class AppLogins
        {
            public string id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string favoriteMake { get; set; }
        }

        private async Task SyncAsync()
        {
            await App.MobileService.SyncContext.PushAsync();
            await todoGetTable.PullAsync("AppLogins", todoTable.CreateQuery());
        }

        private async Task InitLocalStoreAsync()
        {
            if (!App.MobileService.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("Capstone.db");
                store.DefineTable<AppLogins>();
                await App.MobileService.SyncContext.InitializeAsync(store);
            }
            await SyncAsync();
        }

        async public void GetAuthentication()
        {

            IMobileServiceSyncTable<AppLogins> toGetTable = App.MobileService.GetSyncTable<AppLogins>();

            List<AppLogins> items = await toGetTable
                .Where(AppLogins => AppLogins.username == username.Text)
                .ToListAsync();

            IsAuth = items.Count();

            foreach (var value in items)
            {
                var dialog = new MessageDialog("UserID: " + value.username);
                await dialog.ShowAsync();
            }


            if (IsAuth > 0)
            {
                var dialog = new MessageDialog("Login Successful.");
                await dialog.ShowAsync();
                this.Frame.Navigate(typeof(HomePage));
            }
            else
            {
                var dialog = new MessageDialog("Username or Password is incorrect.");
                await dialog.ShowAsync();
            }
        }

        async private void signIn_Click(object sender, RoutedEventArgs e)
        {
            await InitLocalStoreAsync();
            GetAuthentication();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));
        }

        
    }
}
