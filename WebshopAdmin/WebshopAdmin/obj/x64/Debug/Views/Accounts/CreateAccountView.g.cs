﻿#pragma checksum "C:\Users\Robys\source\repos\ADVCsharp\Project\WebshopAdmin\WebshopAdmin\Views\Accounts\CreateAccountView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0110736EFB81330549CC7C17E4652FE4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebshopAdmin.Views.Accounts
{
    partial class CreateAccountView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\Accounts\CreateAccountView.xaml line 24
                {
                    this.txtUsername = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Views\Accounts\CreateAccountView.xaml line 30
                {
                    this.psw = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 4: // Views\Accounts\CreateAccountView.xaml line 36
                {
                    this.pswconfirm = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 5: // Views\Accounts\CreateAccountView.xaml line 41
                {
                    this.btnCancelCreateAccount = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCancelCreateAccount).Click += this.btnCancelCreateAccount_Click;
                }
                break;
            case 6: // Views\Accounts\CreateAccountView.xaml line 42
                {
                    this.btnCreateAccount = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCreateAccount).Click += this.btnCreateAccount_ClickAsync;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
