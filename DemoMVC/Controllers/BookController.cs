using DemoMVC.DataAccess;
using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext = DemoMVC.Utils.Utils;

namespace DemoMVC.Controllers
{
    public class BookController : Controller
    {
        private BookContext db = new BookContext();
        public ActionResult List()
        {
            return View();
        }

        public ActionResult JustList() {
            return 
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                db.bookRepozitory.save(book);
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        public ActionResult EditBook(int? bookId)
        {
            int id = Ext.GetInt(bookId);
            if (id > 0)
            {
                Book bookModel = db.bookRepozitory.findBook(id);
                return View(bookModel);
            }
            else
            {
                return RedirectToAction("List");
            }

        }
        [HttpPost]
        public ActionResult UpdateBook(Book model)
        {
                db.bookRepozitory.update(model);
                return RedirectToAction("List");
        }
        public ActionResult ErrorBook()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult findBooks(string par) {
            return RedirectToAction("List", db.bookRepozitory.search(par));
        }

        public ActionResult searchedList(IList<Book> books)
        {
            return View(books);
        }

        [HttpPost]
        public string DeleteBook(int? bookId)
        {
            string statusCode = "0";
            int id = Ext.GetInt(bookId);
            if (bookId > 0)
            {
                bool isDeleted = db.bookRepozitory.delete(id);
                statusCode = (isDeleted) ? "1" : "2";
            }
            return statusCode;
            // return View(db.bookRepozitory.findAll());
        }
    }
}