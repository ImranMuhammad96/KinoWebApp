using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KinoWebApp.Models;
using KinoWebApp.Persistence;

namespace KinoWebApp.Controllers
{
    public class SeansController : Controller
    {
        private KinoWebAppDbContext _context = new KinoWebAppDbContext();

        public ActionResult Create()
        {
            ViewBag.IDF = new SelectList(_context.Filmy, "IDF", "TYTUL");
            ViewBag.NR_SALI = new SelectList(_context.Sale, "NR_SALI", "NR_SALI");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seans seans)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IDF = new SelectList(_context.Filmy, "IDF", "TYTUL", seans.IDF);
                ViewBag.NR_SALI = new SelectList(_context.Sale, "NR_SALI", "NR_SALI", seans.NR_SALI);
                return View(seans);
            }

            _context.Seanse.Add(seans);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seans seans = _context.Seanse.Find(id);
            if (seans == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDF = new SelectList(_context.Filmy, "IDF", "TYTUL", seans.IDF);
            ViewBag.NR_SALI = new SelectList(_context.Sale, "NR_SALI", "NR_SALI", seans.NR_SALI);
            return View(seans);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seans seans)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(seans).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.IDF = new SelectList(_context.Filmy, "IDF", "TYTUL", seans.IDF);
            ViewBag.NR_SALI = new SelectList(_context.Sale, "NR_SALI", "NR_SALI", seans.NR_SALI);
            return View(seans);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seans seans = _context.Seanse.Find(id);
            if (seans == null)
            {
                return HttpNotFound();
            }
            return View(seans);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seans seans = _context.Seanse.Find(id);
            _context.Seanse.Remove(seans);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
