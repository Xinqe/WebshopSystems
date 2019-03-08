using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShopUserMVC.Models;

namespace WebShopUserMVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private WebshopModel db = new WebshopModel();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            try
            {

   
            return View(await db.Product.ToListAsync());

            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {

   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Product.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }
        }

    }
}
