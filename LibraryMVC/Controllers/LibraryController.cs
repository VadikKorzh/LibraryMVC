using LibraryDataService;
using LibraryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.Controllers
{
    public class LibraryController : Controller
    {
        LibraryDbContext libraryDbContext = new LibraryDbContext();
        // GET: Library
        public ActionResult Index()
        {
            return View(libraryDbContext.Books);
        }

        // GET: Library/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Library/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Library/Create
        [HttpPost]
        public ActionResult Create(Writer writer)
        {
            try
            {
                // TODO: Add insert logic here
                libraryDbContext.Writers.Add(writer);
                libraryDbContext.SaveChanges();
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
            return View();
        }

        // POST: Library/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Library/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
