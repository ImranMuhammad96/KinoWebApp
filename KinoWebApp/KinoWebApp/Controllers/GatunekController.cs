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
    public class GatunekController : Controller
    {
        private KinoWebAppDbContext _context = new KinoWebAppDbContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gatunek newGatunek)
        {
            if (!ModelState.IsValid)
            {
                return View(newGatunek);
            }

            _context.Gatunki.Add(newGatunek);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gatunek gatunek = _context.Gatunki.Find(id);
            if (gatunek == null)
            {
                return HttpNotFound();
            }
            return View(gatunek);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gatunek gatunek)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(gatunek).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(gatunek);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gatunek gatunek = _context.Gatunki.Find(id);
            if (gatunek == null)
            {
                return HttpNotFound();
            }
            return View(gatunek);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gatunek gatunek = _context.Gatunki.Find(id);
            _context.Gatunki.Remove(gatunek);
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
