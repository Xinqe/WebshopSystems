using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WebShopService.Model;

namespace WebShopService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {
            // Set up a timer that triggers every minute.
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 5000; // 10 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Enabled = true;
            
            timer.Start();
            
        }
    
     
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.

            CreateFolder();
            ReadJsonFile();
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

        protected override void OnStop()
        {

        }
       private static WebshopModel db = new WebshopModel();
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
                //product = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(@"C:/jsonfile.json")); 
                product = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(file.FullName));

                if (product == null)
                {
                    db.Log.Add(new Log() { Description = "failed to read from file by WebshopService" });
                    db.SaveChanges();
                    return;
                }


                try
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
                catch (Exception e)
                {
                    db.Log.Add(new Log() { Description = e.Message });
                    db.SaveChanges();
                }


            }
        }
    }
}
