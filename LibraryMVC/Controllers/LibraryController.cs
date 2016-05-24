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
        static IWritersRepository _writersRepository;
        static IBooksRepository _booksRepository;

        public LibraryController()
        {
            LibraryDbContext libraryDbContext = new LibraryDbContext();
            _writersRepository = new WritersEFRepository(libraryDbContext);
            _booksRepository = new BooksEFRepository(libraryDbContext);

            Random rnd = new Random((int)DateTime.Now.Ticks);
            foreach (var book in _booksRepository.GetAll())
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
            _booksRepository.SubmitChanges();

        }

        // GET: Library
        public ActionResult Index()
        {
            return View(_booksRepository.GetAll());
        }

        // GET: Library/Details/5
        public ActionResult Details(int id)
        {
            Book book = _booksRepository.GetById(id);
            book.AddHit();
            _booksRepository.SubmitChanges();
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
                _writersRepository.AddWriter(writer);
                _writersRepository.SubmitChanges();
                return RedirectToAction("Index");
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
            foreach (var writer in _writersRepository.GetAll())
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
                // TODO: Add insert logic here
                //libraryDbContext.Writers.Add(writer);
                //libraryDbContext.SaveChanges();
                _booksRepository.AddBook(book);
                _booksRepository.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Library/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> writers = new List<SelectListItem>();
            foreach (var writer in _writersRepository.GetAll())
            {
                writers.Add(new SelectListItem { Text = writer.Name.ToString(), Value = writer.Id.ToString() });
            }
            ViewBag.Writers = writers;
            return View(_booksRepository.GetById(id));
        }

        // POST: Library/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // TODO: Add update logic here
                Book bookToEdit = _booksRepository.GetById(id);
                bookToEdit.AuthorId = book.AuthorId;
                bookToEdit.ISBN = book.ISBN;
                bookToEdit.Title = book.Title;
                _booksRepository.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Library/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_booksRepository.GetById(id));
        }

        // POST: Library/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _booksRepository.RemoveBook(id);
                _booksRepository.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
