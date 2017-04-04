using BookStore.Models;
using BookStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            return View("Index");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
       public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Thank you, " + purchase.Person + ", for the buy!";
        }
        [HttpPost]
        public string PostBook()
        {
            
            return string.Format(Request.Params["title"] + " " + Request.Params["author"]);
         }
        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2> hello world</h2>");
        }

        public string Square()
        {
            int a = int.Parse(Request.Params["a"]);
            int b = int.Parse(Request.Params["b"]);
            return  String.Format("<h2> Squeare triangle = " +  a * b / 2);
        }
      
    }
}