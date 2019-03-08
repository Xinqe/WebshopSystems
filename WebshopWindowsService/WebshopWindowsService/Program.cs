using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WebshopWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WebshopWindowsService()
            };
            ServiceBase.Run(ServicesToRun);



        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");
        }

        private static void ReadJsonFile()
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // read file into a string and deserialize JSON to a type
            List<Product> product = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(path + @"\jsonfile.json")); // reads from desktop

            //foreach (var item in product)
            //{
            //    Console.WriteLine($"Product name: {item.Name}, description: {item.Description}, price: {item.Price}");
            //}

            WebShopModel db = new WebShopModel();

            using (db)
            {
                bool b;
                foreach (var item in product)
                {
                    b = db.Product.Any(x => x.Name == item.Name && x.Description == item.Description && x.Price == item.Price);

                    if (b == false)
                    {
                        db.Product.Add(item);
                        db.SaveChanges();
                    }
                }
            }

        }
    }


}
