using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Test3.Models; // Import your Book and Order models here
using System.Transactions; // Add this namespace for TransactionScope
using System.Diagnostics;

namespace Test3.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Order(int? id)
        {
            using (var transaction = new TransactionScope())
            {
                // Check if the user is authenticated
                if (!User.Identity.IsAuthenticated)
                {
                    TempData["ErrorMessage"] = "Please login to place an order.";
                    return RedirectToAction("Login", "Account");
                }

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book book = db.Books.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }

                string currentUserEmail = User.Identity.Name;
                DateTime currentDateTime = DateTime.Now;
                Debug.WriteLine("Current Date and Time: " + currentDateTime);
                Order order = new Order
                {
                    product_id = book.book_Id,
                    quantity = 1, // You can set the quantity as per your requirement
                    total = book.price, // Assuming price is stored in the book object
                    image = book.image,
                    date = DateTime.Now,
                    user_email = currentUserEmail // Set the current user's email
                };
                // Add the order to the database
                db.Orders.Add(order);
                db.SaveChanges();
                transaction.Complete();
                // Redirect to the details page of the ordered book
                return RedirectToAction("Order", "Home");
            }
        }

        public ActionResult Order()
        {
            // Get the current user's email
            string currentUserEmail = User.Identity.Name;

            // Retrieve orders from the database for the current user
            var orders = db.Orders.Where(o => o.user_email == currentUserEmail).ToList();

            return View(orders);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Search(string query)
        {
            var results = db.Books.Where(b => b.book_Name.Contains(query) || b.author.Contains(query)).ToList();
            return View(results);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
