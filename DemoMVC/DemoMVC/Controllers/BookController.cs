using DemoMVC.DataAccess;
using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class BookController : Controller
    {
        private string errorMessage = "";
        private BookContext db = new BookContext();
        public ActionResult List()  {           
            return View(db.bookRepozitory.findAll());
        }
        public ActionResult EditBook(int ? bookId)
        {
            int id = 0;
            if (int.TryParse("" + bookId, out id))
            {
                ViewBag.ErrorMessage = errorMessage;
                ViewBag.ErrorMessage = errorMessage;
                Book bookModel = db.bookRepozitory.findBook(id);
                return View(bookModel);
            }else
            {//TODO:change to displaying message
                return RedirectToAction("List");
            }

        }
        [HttpPost]
        public ActionResult UpdateBook(Book model)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = db.bookRepozitory.update(model);               
                errorMessage = "";
                //todo:display success message
                return RedirectToAction("List");
            }
            else {
                errorMessage = "Error in form book";
                return RedirectToAction("EditBook", new { bookId=model.ID});
            }
           
        }
        public ActionResult ErrorBook()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult DeleteBook( int bookId)
        {
            int id = 0;
            if (int.TryParse("" + bookId, out id))
            {
                ViewBag.ErrorMessage = errorMessage;
                db.bookRepozitory = db.bookRepozitory.delete(bookId);
                return View(db);
            }
            else
            {//TODO:change to displaying message
                return RedirectToAction("List");
            }
            // return View(db.bookRepozitory.findAll());
        }
    }
}