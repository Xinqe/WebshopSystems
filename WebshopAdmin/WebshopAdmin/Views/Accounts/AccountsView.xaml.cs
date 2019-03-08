using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WebshopAdmin.Model;
using WebshopAdmin.Views.Accounts;
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
    public sealed partial class AccountsView : Page
    {
        private ObservableCollection<Account> data = new ObservableCollection<Account>();
        public AccountsView()
        {
            this.InitializeComponent();
            LoadAccountsAsync();
        }

        public async void LoadAccountsAsync()
        {
            WebserviceModel client = new WebserviceModel();

            List<Account> x = await client.GetAccountsAsync();

            foreach (var item in x)
            {
                data.Add(item);
            }


        }

        private void btnAccountCreate_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateAccountView));
        }

        private void AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account x = (Account)AccountList.SelectedItem;


            Frame.Navigate(typeof(UpdateDeleteAccountView), x);
        }
    }
}
