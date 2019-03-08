using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace WebshopAdmin.Views.Accounts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateDeleteAccountView : Page
    {

        public Account selectedAccount { get; set; }
        public UpdateDeleteAccountView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedAccount = (Account)e.Parameter;
        }

        private void btnCancelUpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccountsView));
        }

        private async void btnUpdateAccount_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(pswCurrent.Password) ||String.IsNullOrWhiteSpace(pswNew.Password) || String.IsNullOrWhiteSpace(pswNewConfirm.Password))
            {
                var dialog = new MessageDialog("The fields cannot be empty.");
                await dialog.ShowAsync();
                return;
            }

            if (pswCurrent.Password != selectedAccount.Password)
            {
                var dialog = new MessageDialog("Current password are wrong.");
                await dialog.ShowAsync();
                return;
            }

            if (pswNew.Password != pswNewConfirm.Password)
            {
                var dialog = new MessageDialog("Passwords aren't matching.");
                await dialog.ShowAsync();
                return;
            }

            WebserviceModel client = new WebserviceModel();

            client.UpdateAccountAsync(selectedAccount);
            Frame.Navigate(typeof(AccountsView));

        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            WebserviceModel client = new WebserviceModel();
            client.DeleteAccountAsync(selectedAccount);
            Frame.Navigate(typeof(AccountsView));
        }
    }
}
