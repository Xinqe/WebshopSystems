using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WebshopAdmin.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WebshopAdmin.Views.Orders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateDeleteOrderView : Page
    {
        public CombinedOrder selectedCombinedOrder { get; set; }
        public ObservableCollection<ProductPresenter> productData { get; set; }
        public int Ordersum { get; set; }
        public UpdateDeleteOrderView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedCombinedOrder = (CombinedOrder)e.Parameter;
            productData = new ObservableCollection<ProductPresenter>();
            PresentData();
            CalculateSum();
        }

        private void PresentData()
        {
            foreach (var item in selectedCombinedOrder.products)
            {
                ProductPresenter newProductPresenter = new ProductPresenter();

                newProductPresenter.ID = item.ID;
                newProductPresenter.Name = item.Name;
                newProductPresenter.Description = item.Description;
                newProductPresenter.Price = item.Price;



                OrderItem orderItemQuantity = selectedCombinedOrder.orderItems.FirstOrDefault(b => b.ProductID == item.ID);
                newProductPresenter.Quantity = orderItemQuantity.Quantity;

                productData.Add(newProductPresenter);

            }
        }

        public void CalculateSum()
        {
            int sum = 0;

            foreach (var item in productData)
            {
                sum += item.Price * item.Quantity;
            }

            Ordersum = sum;
        }

        private void btnCancelUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrdersView));

        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e) // here
        {

            foreach (var item in productData)
            {
                selectedCombinedOrder.orderItems.FirstOrDefault(x => x.ProductID == item.ID).Quantity = item.Quantity;
            }
            WebserviceModel client = new WebserviceModel();
            client.UpdateOrderAsync(selectedCombinedOrder);

            Frame.Navigate(typeof(OrdersView));
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            WebserviceModel client = new WebserviceModel();
            client.DeletOrderAsync(selectedCombinedOrder.order);
            Frame.Navigate(typeof(OrdersView));
        }

        private void btnDeleteProductFromOrder_Click(object sender, RoutedEventArgs e)
        {
            ProductList.SelectedItem = ((FrameworkElement)sender).DataContext;

            ProductPresenter x = (ProductPresenter)ProductList.SelectedItem;

            productData.Remove(productData.FirstOrDefault(c => c.ID == x.ID));

            var deletedOrderItem = selectedCombinedOrder.orderItems.FirstOrDefault(c => c.ProductID == x.ID);

            selectedCombinedOrder.orderItems.Remove(deletedOrderItem);

            selectedCombinedOrder.products.Remove(selectedCombinedOrder.products.FirstOrDefault(c => c.ID == x.ID));

            WebserviceModel client = new WebserviceModel();
            client.DeletOrderItemAsync(deletedOrderItem);

        }


    }
}
