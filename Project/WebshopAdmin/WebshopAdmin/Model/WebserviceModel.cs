using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebshopAdmin.Model
{
    class WebserviceModel
    {
        private string url = "https://webshopapi20181007041301.azurewebsites.net/Api/";


        public WebserviceModel()
        {

        }

        public async Task<List<CombinedOrder>> GetCombinedOrdersAsync() // gets data that is related to the order. 
        {
            List<Order> orders = new List<Order>();
            List<OrderItem> orderItems = new List<OrderItem>();
            List<Account> accounts = await GetAccountsAsync();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
            List<Product> products = await GetProductsAsync();

            List<CombinedOrder> combinedOrders = new List<CombinedOrder>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(url + "Orders"));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync(); 
                    orders = JsonConvert.DeserializeObject<List<Order>>(content);
                }

                response = await client.GetAsync(new Uri(url + "OrderItems"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(content);
                }



            }

            // making the list of combined classes

            foreach (var order in orders)
            {
                CombinedOrder x = new CombinedOrder();
                x.order = order;
                x.orderItems.AddRange(orderItems.Where(c => c.OrderID== order.ID).ToList()); 
                x.account = accounts.FirstOrDefault(c => c.ID == order.AccountID);

                foreach (var item in x.orderItems)
                {
                   x.products.Add( products.FirstOrDefault(v => v.ID == item.ProductID));
                }
                combinedOrders.Add(x);

            }




            return combinedOrders;
        }

        public async void UpdateOrderAsync(CombinedOrder combinedOrder) // here
        {
            HttpClient client = new HttpClient();

            foreach (var item in combinedOrder.orderItems)
            {
                OrderItem x = item;

                var jsonedProductLoop = JsonConvert.SerializeObject(x);

                HttpResponseMessage responseLoop = await client.PutAsync(url + $"OrderItems/{item.ID}", new StringContent(jsonedProductLoop, Encoding.UTF8, "application/json"));
                responseLoop.EnsureSuccessStatusCode();
            }

            var jsonedProduct = JsonConvert.SerializeObject(combinedOrder.order);

            HttpResponseMessage response = await client.PutAsync(url + $"Orders/{combinedOrder.order.ID}", new StringContent(jsonedProduct, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            foreach (var item in combinedOrder.orderItems)
            {
                UpdateOrderItemAsync(item);
            }

        }

        private async void UpdateOrderItemAsync(OrderItem orderItem)
        {
            var jsonedProduct = JsonConvert.SerializeObject(orderItem);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url + $"OrderItems/{orderItem.ID}", new StringContent(jsonedProduct, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async void DeletOrderItemAsync(OrderItem orderItem)
        {
            var jsonedProduct = JsonConvert.SerializeObject(orderItem);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url + $"OrderItems/{orderItem.ID}");
            response.EnsureSuccessStatusCode();
        }

        public async void DeletOrderAsync(Order order)
        {
            var jsonedProduct = JsonConvert.SerializeObject(order);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url + $"Orders/{order.ID}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            List<Account> accounts = new List<Account>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(url + "Accounts"));


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    try
                    {
                        accounts = JsonConvert.DeserializeObject<List<Account>>(content);

                        return accounts;

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }


                    return accounts;
                }
                return accounts;
            }
        }

        public async void CreateAccountAsync(Account account)
        {
            var jsonedProduct = JsonConvert.SerializeObject(account);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url + "Accounts", new StringContent(jsonedProduct, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async void UpdateAccountAsync(Account account)
        {
            var jsonedProduct = JsonConvert.SerializeObject(account);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url + $"Accounts/{account.ID}", new StringContent(jsonedProduct, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async void DeleteAccountAsync(Account account)
        {
            var jsonedProduct = JsonConvert.SerializeObject(account);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url + $"Accounts/{account.ID}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            List<Product> products = new List<Product>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(url + "Products"));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    try
                    {
                        products = JsonConvert.DeserializeObject<List<Product>>(content);

                        return products;

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    

                    return products;
                }

                return products;
            }

        }

        public async void CreateProductAsync(Product product)
        {
            var jsonedProduct =  JsonConvert.SerializeObject(product);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url + "Products", new StringContent(jsonedProduct, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async void UpdateProductAsync(Product product)
        {
            var jsonedProduct = JsonConvert.SerializeObject(product);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url + $"Products/{product.ID}", new StringContent(jsonedProduct, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async void DeleteProductAsync(Product product)
        {
            var jsonedProduct = JsonConvert.SerializeObject(product);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url + $"Products/{product.ID}");
            response.EnsureSuccessStatusCode();
        }

    }
    public class Product
    {

        public Product()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }


    }

    public class OrderItem
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

    }

    public class Order
    {

        public Order()
        {

        }

        public int ID { get; set; }

        public int AccountID { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }
    }

    public class Account
    {

        public Account()
        {

        }

        public int ID { get; set; }


        public string Username { get; set; }

        public string Password { get; set; }


    }


}


