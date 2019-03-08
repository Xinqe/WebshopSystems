using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReaderTester
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFolder();
            ReadJsonFile();

            Console.WriteLine("Hello World!");
            Console.ReadKey();


        }

        private static void CreateFolder()
        {
            string path = @"C:\webshopmap";
            try
            {
                if (Directory.Exists(path))
                {
                    return;
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return;
        }

        private static WebShopModel db = new WebShopModel();
        private static List<Product> product = new List<Product>();
        private static void ReadJsonFile()
        {
            string path = @"C:\webshopmap";
            if (File.Exists(path))
            {
                Console.WriteLine("File path exists");
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles())
            {


                // read file into a string and deserialize JSON to a type
                product = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(file.FullName)/*File.ReadAllText(path + @"\jsonfile.json")*/); //path + @"\jsonfile.json"


                if (product == null)
                {
                    Console.WriteLine("No data was read from file");
                    //db.Log.Add(new Log() { Description = "failed to read from file?" });
                    //db.SaveChanges();
                    return;
                }



                foreach (var item in product)
                {
                    Console.WriteLine($"Product name: {item.Name}, description: {item.Description}, price: {item.Price}");

                }

                try
                {

                    bool b;
                    foreach (var item in product) // fel på foreach ? eller läser av filen ? 
                    {
                        b = db.Product.Any(x => x.Name == item.Name && x.Description == item.Description && x.Price == item.Price);

                        if (b == false)
                        {
                            //db.Log.Add(new Log() { Description = "test before product add" });
                            // db.Product.Add(new Product() { Description = "test", Name = "boop1", Price = 20 });
                            db.Product.Add(item);
                            //db.Log.Add(new Log() { Description = "test after product add" });


                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception e)
                {
                    db.Log.Add(new Log() { Description = e.Message });
                    db.SaveChanges();
                }

            }
        }
    }

}

