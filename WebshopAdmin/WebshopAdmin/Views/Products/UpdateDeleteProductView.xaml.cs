using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WebshopAdmin.Model;
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

namespace WebshopAdmin.Views.Products
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateDeleteProductView : Page
    {
        public Product selectedProduct { get; set; }
        private WebserviceModel client = new WebserviceModel();

        public UpdateDeleteProductView()
        {
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedProduct  = (Product)e.Parameter;
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            client.DeleteProductAsync(selectedProduct);
            Frame.Navigate(typeof(ProductsView));
        }

        private async void btnUpdateProduct_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtProductName.Text) || String.IsNullOrWhiteSpace(txtProductDescription.Text) || String.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                var dialog = new MessageDialog("Price input isn't a number");
                await dialog.ShowAsync();
                return;
            }

            client.UpdateProductAsync(selectedProduct);
            Frame.Navigate(typeof(ProductsView));
        }

        private void btnCancelUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductsView));
        }
    }
}
