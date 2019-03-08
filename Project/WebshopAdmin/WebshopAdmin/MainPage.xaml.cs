using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WebshopAdmin.Model;
using WebshopAdmin.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebshopAdmin
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

        public void getProductsAsync()
        {
            WebserviceModel client = new WebserviceModel();

         
        }

        private void NavBar_Loaded(object sender, RoutedEventArgs e)
        {

            contentFrame.Navigate(typeof(HomeView));
        }

        private void NavBar_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }

        private void NavBar_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            TextBlock itemContent = args.InvokedItem as TextBlock;

            switch (itemContent.Tag)
            {
                case "NavProducts":
                    contentFrame.Navigate(typeof(ProductsView));
                    break;
                case "NavAccounts":
                    contentFrame.Navigate(typeof(AccountsView));
                    break;
                case "NavOrders":
                    contentFrame.Navigate(typeof(OrdersView));
                    break;
                case "NavHome":
                    contentFrame.Navigate(typeof(HomeView));
                    break;
                case null:
                    break;
                default:
                    break;
        
            }
        }
    }
}
