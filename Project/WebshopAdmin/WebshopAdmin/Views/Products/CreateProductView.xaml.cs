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
    public sealed partial class CreateProductView : Page
    {
        public CreateProductView()
        {
            this.InitializeComponent();
          
        }

        private void btnCancelCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductsView));
        }

        private async void btnCreateProduct_ClickAsync(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product();

            if (String.IsNullOrWhiteSpace(txtProductName.Text) || String.IsNullOrWhiteSpace(txtProductDescription.Text))
            {
                var dialog = new MessageDialog("Name or Description cannot be empty.");
                await dialog.ShowAsync();
                return;
            }

            newProduct.Name = txtProductName.Text;
            newProduct.Description = txtProductDescription.Text;
            int price;

            if (int.TryParse(txtProductPrice.Text, out price))
            {
                newProduct.Price = price;


                // api create
                WebserviceModel client = new WebserviceModel();
                client.CreateProductAsync(newProduct);
            }
            else
            {
                var dialog = new MessageDialog("Price input isn't a number");
                await dialog.ShowAsync();
                return;
            }




            Frame.Navigate(typeof(ProductsView));
        }
    }
}
