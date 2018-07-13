using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CSCapstone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Catalog : Page
    {
        public Catalog()
        {
            this.InitializeComponent();
        }

        private async void Car1_ClickAsync(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("2007 Ford Mustang      Miles: 27,000 Price: $10,000");
            await dialog.ShowAsync();
        }

        private async void Car2_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("1995 Chevy Tahoe   Miles: 70,000 Price: $8,000");
            await dialog.ShowAsync();
        }

        private async void Car3_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("2007 Chevy Trailblazer   Miles: 60,000 Price: $10,000");
            await dialog.ShowAsync();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogoutScreen));
        }
    }
}
