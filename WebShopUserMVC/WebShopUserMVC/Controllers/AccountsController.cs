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
using System.Web.Security;


namespace WebShopUserMVC.Controllers
{
    public class AccountsController : Controller
    {
        private WebshopModel db = new WebshopModel();


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account x) 
        {
            try
            {


            if (x.Username == null || x.Password == null)
            {
                ModelState.AddModelError("", "Wrong password or username");
                return View();
            }

            bool validUser = false;


            validUser = db.Account.Any(c => c.Username == x.Username && c.Password == x.Password);

            if (validUser == true)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(x.Username, false);

                return RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "Invalid login");

            return View();

            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }

        }
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        // GET: Accounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {

        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Account.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);

            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account x) 
        {

            try
            {


            var dump = db.Account.FirstOrDefault(b => b.Username == x.Username);
            if (dump != null)
            {
                ModelState.AddModelError("", "Invalid username, it is already taken.");
                return View();
            }

            if (dump == null)
            {
                db.Account.Add(x);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                ModelState.AddModelError("", "Failed to create an account.");
                return View();
            }

            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Username,Password")] Account account)
        {
            try
            {

 
            if (ModelState.IsValid)
            {
                db.Account.Add(account);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(account);

            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }
        }

        // GET: Accounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Account.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }

            return View(account);

            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }

        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Username,Password")] Account account)
        {
            try
            {

  
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(account);

            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }
        }

        // GET: Accounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Account.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);

            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }


        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {

            

            Account account = await db.Account.FindAsync(id);
            db.Account.Remove(account);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                db.Log.Add(new Log { Description = e.Message });
                db.SaveChanges();
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
