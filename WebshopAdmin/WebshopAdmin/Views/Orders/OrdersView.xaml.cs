using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WebshopAdmin.Model;
using WebshopAdmin.Views.Orders;
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

namespace WebshopAdmin.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrdersView : Page
    {
        public ObservableCollection<CombinedOrder> data { get; set; }
        public OrdersView()
        {
            this.InitializeComponent();
            LoadCombinedOrdersAsync();
        }

        public async void LoadCombinedOrdersAsync()
        {
            WebserviceModel client = new WebserviceModel();
            data = new ObservableCollection<CombinedOrder>();

            List<CombinedOrder> x = await client.GetCombinedOrdersAsync();

            foreach (var item in x)
            {
                data.Add(item);
            }


        }


        private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            {
                CombinedOrder x = (CombinedOrder)OrderList.SelectedItem;


                Frame.Navigate(typeof(UpdateDeleteOrderView), x);

            }
        }
    }
}
