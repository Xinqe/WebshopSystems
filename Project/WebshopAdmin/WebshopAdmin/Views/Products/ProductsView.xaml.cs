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
using WebshopAdmin.Model;
using System.Collections.ObjectModel;
using WebshopAdmin.Views.Products;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WebshopAdmin.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductsView : Page
    {
      private  ObservableCollection<Product> data = new ObservableCollection<Product>();
        public ProductsView()
        {
            this.DataContext = this;
            this.InitializeComponent();
            LoadProductsAsync();
           

        }

        public async void LoadProductsAsync()
        {
            WebserviceModel client = new WebserviceModel();

            List<Product> x  = await client.GetProductsAsync();

            foreach (var item in x)
            {
                data.Add(item);
            }


        }

        private void btnProductCreate_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateProductView));
        }



        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product x = (Product)ProductList.SelectedItem;


            Frame.Navigate(typeof(UpdateDeleteProductView), x);
        }
    }
}
