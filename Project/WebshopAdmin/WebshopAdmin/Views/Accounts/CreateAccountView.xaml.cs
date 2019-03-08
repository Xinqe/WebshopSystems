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

namespace WebshopAdmin.Views.Accounts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateAccountView : Page
    {
        public CreateAccountView()
        {
            this.InitializeComponent();
        }

        private void btnCancelCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccountsView));
        }

        private async void btnCreateAccount_ClickAsync(object sender, RoutedEventArgs e)
        {
            Account newAccount = new Account();
            if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(psw.Password) || String.IsNullOrWhiteSpace(pswconfirm.Password))
            {
                var dialog = new MessageDialog("Username cannot be empty.");
                await dialog.ShowAsync();
                return;
            }

            if (psw.Password != pswconfirm.Password)
            {
                var dialog = new MessageDialog("Passwords aren't matching.");
                await dialog.ShowAsync();
                return;
            }

            newAccount.Username = txtUsername.Text;
            newAccount.Password = psw.Password;

            WebserviceModel client = new WebserviceModel();
            client.CreateAccountAsync(newAccount);


            Frame.Navigate(typeof(AccountsView));
        }
    }
}
