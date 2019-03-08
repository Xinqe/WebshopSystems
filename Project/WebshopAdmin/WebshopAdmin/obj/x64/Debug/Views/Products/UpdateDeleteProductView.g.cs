﻿#pragma checksum "C:\Users\Robys\source\repos\ADVCsharp\Project\WebshopAdmin\WebshopAdmin\Views\Products\UpdateDeleteProductView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "72329495F6EC2163291F951D60866F6B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebshopAdmin.Views.Products
{
    partial class UpdateDeleteProductView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class UpdateDeleteProductView_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IUpdateDeleteProductView_Bindings
        {
            private global::WebshopAdmin.Views.Products.UpdateDeleteProductView dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBox obj2;
            private global::Windows.UI.Xaml.Controls.TextBox obj3;
            private global::Windows.UI.Xaml.Controls.TextBox obj4;

            private UpdateDeleteProductView_obj1_BindingsTracking bindingsTracking;

            public UpdateDeleteProductView_obj1_Bindings()
            {
                this.bindingsTracking = new UpdateDeleteProductView_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\Products\UpdateDeleteProductView.xaml line 26
                        this.obj2 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_2(this.obj2);
                        break;
                    case 3: // Views\Products\UpdateDeleteProductView.xaml line 32
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_3(this.obj3);
                        break;
                    case 4: // Views\Products\UpdateDeleteProductView.xaml line 39
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_4(this.obj4);
                        break;
                    default:
                        break;
                }
            }

            // IUpdateDeleteProductView_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::WebshopAdmin.Views.Products.UpdateDeleteProductView)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::WebshopAdmin.Views.Products.UpdateDeleteProductView obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_selectedProduct(obj.selectedProduct, phase);
                    }
                }
            }
            private void Update_selectedProduct(global::WebshopAdmin.Model.Product obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_selectedProduct_Name(obj.Name, phase);
                        this.Update_selectedProduct_Description(obj.Description, phase);
                        this.Update_selectedProduct_Price(obj.Price, phase);
                    }
                }
            }
            private void Update_selectedProduct_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Products\UpdateDeleteProductView.xaml line 26
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj2, obj, null);
                }
            }
            private void Update_selectedProduct_Description(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Products\UpdateDeleteProductView.xaml line 32
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj3, obj, null);
                }
            }
            private void Update_selectedProduct_Price(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Products\UpdateDeleteProductView.xaml line 39
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj4, obj.ToString(), null);
                }
            }
            private void UpdateTwoWay_2_Text()
            {
                if (this.initialized)
                {
                    this.dataRoot.selectedProduct.Name = this.obj2.Text;
                }
            }
            private void UpdateTwoWay_3_Text()
            {
                if (this.initialized)
                {
                    this.dataRoot.selectedProduct.Description = this.obj3.Text;
                }
            }
            private void UpdateTwoWay_4_Text()
            {
                if (this.initialized)
                {
                    this.dataRoot.selectedProduct.Price = (global::System.Int32) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Int32), this.obj4.Text);
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class UpdateDeleteProductView_obj1_BindingsTracking
            {
                private global::System.WeakReference<UpdateDeleteProductView_obj1_Bindings> weakRefToBindingObj; 

                public UpdateDeleteProductView_obj1_BindingsTracking(UpdateDeleteProductView_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<UpdateDeleteProductView_obj1_Bindings>(obj);
                }

                public UpdateDeleteProductView_obj1_Bindings TryGetBindingObject()
                {
                    UpdateDeleteProductView_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                }

                public void RegisterTwoWayListener_2(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_2_Text();
                        }
                    };
                }
                public void RegisterTwoWayListener_3(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_3_Text();
                        }
                    };
                }
                public void RegisterTwoWayListener_4(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_4_Text();
                        }
                    };
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\Products\UpdateDeleteProductView.xaml line 26
                {
                    this.txtProductName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Views\Products\UpdateDeleteProductView.xaml line 32
                {
                    this.txtProductDescription = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Views\Products\UpdateDeleteProductView.xaml line 39
                {
                    this.txtProductPrice = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Views\Products\UpdateDeleteProductView.xaml line 42
                {
                    this.btnCancelUpdateProduct = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCancelUpdateProduct).Click += this.btnCancelUpdateProduct_Click;
                }
                break;
            case 6: // Views\Products\UpdateDeleteProductView.xaml line 43
                {
                    this.btnUpdateProduct = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUpdateProduct).Click += this.btnUpdateProduct_ClickAsync;
                }
                break;
            case 7: // Views\Products\UpdateDeleteProductView.xaml line 44
                {
                    this.btnDeleteProduct = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnDeleteProduct).Click += this.btnDeleteProduct_Click;
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
            switch(connectionId)
            {
            case 1: // Views\Products\UpdateDeleteProductView.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    UpdateDeleteProductView_obj1_Bindings bindings = new UpdateDeleteProductView_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

