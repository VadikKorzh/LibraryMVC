using LibraryDataService;
using LibraryDataService.Models;
using LibraryDataService.Repositories;
using LibraryMVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.Controllers
{
    public class LibraryController : Controller
    {
        //private LibraryUnitOfWork _library;
        private IUnitOfWork _library;

        public LibraryController(IUnitOfWork library)
        {
            _library = library;

            Random rnd = new Random((int)DateTime.Now.Ticks);
            foreach (var book in _library.BookRepository.GetAll())
            {
                if (book.Hits.Count == 0)
                {
                    book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date, Count = rnd.Next(200) });
                    book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date.AddDays(-1), Count = rnd.Next(1, 200) });
                    book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date.AddDays(-2), Count = rnd.Next(1, 200) });
                    book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date.AddDays(-3), Count = rnd.Next(1, 200) });
                    book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date.AddDays(-4), Count = rnd.Next(1, 200) });
                    book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date.AddDays(-5), Count = rnd.Next(1, 200) });
                    book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date.AddDays(-6), Count = rnd.Next(1, 200) });
                    book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date.AddDays(-7), Count = rnd.Next(1, 200) });
                }
            }
            _library.Save();
        }

        // GET: Library
        [OutputCache(Duration = 240, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            return View(_library.BookRepository.GetAll());
        }

        public ActionResult IndexClearCache()
        {
            string path = Url.Action("Index", "Library");
            Response.RemoveOutputCacheItem(path);
            return RedirectToAction("Index");
        }

        public ActionResult IndexWriters()
        {
            return View(_library.WriterRepository.GetAll());
        }

        // GET: Library/Details/5
        public ActionResult BookDetails(int id)
        {
            Book book = _library.BookRepository.Get(id);
            book.AddHit();
            _library.Save();
            return View(book);
        }

        // GET: Library/Create
        public ActionResult CreateWriter()
        {
            return View();
        }

        // POST: Library/Create
        [HttpPost]
        public ActionResult CreateWriter(Writer writer)
        {
            try
            {
                // TODO: Add insert logic here
                //libraryDbContext.Writers.Add(writer);
                //libraryDbContext.SaveChanges();
                _library.WriterRepository.Add(writer);
                _library.Save();
                return RedirectToAction("IndexWriters");
            }
            catch
            {
                return View();
            }
        }

        // GET: Library/Create
        public ActionResult CreateBook()
        {
            List<SelectListItem> writers = new List<SelectListItem>();
            foreach (var writer in _library.WriterRepository.GetAll())
            {
                writers.Add(new SelectListItem { Text = writer.Name.ToString(), Value = writer.Id.ToString() });
            }
            ViewBag.Writers = writers;
            return View();
        }

        // POST: Library/Create
        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            try
            {
                List<SelectListItem> writers = new List<SelectListItem>();
                foreach (var writer in _library.WriterRepository.GetAll())
                {
                    writers.Add(new SelectListItem { Text = writer.Name.ToString(), Value = writer.Id.ToString() });
                }
                ViewBag.Writers = writers;
                // TODO: Add insert logic here
                //libraryDbContext.Writers.Add(writer);
                //libraryDbContext.SaveChanges();
                _library.BookRepository.Add(book);
                _library.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Library/Edit/5
        public ActionResult EditBook(int id)
        {
            List<SelectListItem> writers = new List<SelectListItem>();
            foreach (var writer in _library.WriterRepository.GetAll())
            {
                writers.Add(new SelectListItem { Text = writer.Name.ToString(), Value = writer.Id.ToString() });
            }
            ViewBag.Writers = writers;
            return View(_library.BookRepository.Get(id));
        }

        // POST: Library/Edit/5
        [HttpPost]
        public ActionResult EditBook(int id, Book book)
        {
            try
            {
                List<SelectListItem> writers = new List<SelectListItem>();
                foreach (var writer in _library.WriterRepository.GetAll())
                {
                    writers.Add(new SelectListItem { Text = writer.Name.ToString(), Value = writer.Id.ToString() });
                }
                ViewBag.Writers = writers;
                // TODO: Add update logic here
                Book bookToEdit = _library.BookRepository.Get(id);
                bookToEdit.AuthorId = book.AuthorId;
                bookToEdit.ISBN = book.ISBN;
                bookToEdit.Title = book.Title;
                _library.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Library/Delete/5
        public ActionResult DeleteBook(int id)
        {
            return View(_library.BookRepository.Get(id));
        }

        // POST: Library/Delete/5
        [HttpPost]
        public ActionResult DeleteBook(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _library.BookRepository.Remove(id);
                _library.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditWriter(int id)
        {
            return View(_library.WriterRepository.Get(id));
        }
        [HttpPost]
        public ActionResult EditWriter(int id, Writer writer)
        {
            try
            {
                Writer writerToUpdate = _library.WriterRepository.Get(id);
                writerToUpdate.Name = writer.Name;
                _library.Save();
                return RedirectToAction("IndexWriters");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult DeleteWriter(int id)
        {
            return View(_library.WriterRepository.Get(id));
        }
        [HttpPost]
        public ActionResult DeleteWriter(int id, Writer writer)
        {
            try
            {
                _library.WriterRepository.Remove(id);
                _library.Save();
                return RedirectToAction("IndexWriters");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
