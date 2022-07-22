using MVC5_DemoProject.Models;
using MVC5_DemoProject.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace MVC5_DemoProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksDbContext _context = new BooksDbContext();
        // GET: Books
        public ActionResult Index()
        {
            var books= _context.Books.Include(m=>m.Category).ToList();

            return View(books);
        }
        public ActionResult Create()
        {
            var bookvm = new BookFormViewModel
            {
                Categories = _context.Categories.Where(m=>m.IsActive).ToList()
            };

            return View("BookForm",bookvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories=_context.Categories.Where(m=>m.IsActive).ToList();
                return View("Create", model);
            }
            if (model.Id == 0)
            {
                var b = new Book();
                b.Title = model.Title;
                b.Author = model.Author;
                b.Desciption = model.Desciption;
                b.CatId = model.CatId;
                _context.Books.Add(b);
            }
            else
            {
                var book = _context.Books.Find(model.Id);
                book.Title = model.Title;
                book.Desciption = model.Desciption;
                book.Author = model.Author;
                book.CatId = model.CatId;

            }
            _context.SaveChanges();
            TempData["msg"] = "Data Saved Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var book = _context.Books.Include(m => m.Category).SingleOrDefault(b=>b.Id==id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        public ActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            var BookVM = new BookFormViewModel();
            BookVM.Id = book.Id;
            BookVM.Title = book.Title;
            BookVM.Author = book.Author;
            BookVM.Desciption = book.Desciption;
            BookVM.CatId = book.CatId;
            BookVM.Categories = _context.Categories.ToList();
            return View("BookForm",BookVM);
        }
        public ActionResult Delete(int id)
        {
            var b = _context.Books.Find(id);
            if (b != null)
            {
                _context.Books.Remove(b);
                _context.SaveChanges();
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            return HttpNotFound();
        }
    }
}