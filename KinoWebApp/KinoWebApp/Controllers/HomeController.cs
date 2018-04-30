using KinoWebApp.Models;
using KinoWebApp.Persistence;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace KinoWebApp.Controllers
{
    public class HomeController : Controller
    {
        private KinoWebAppDbContext _context = new KinoWebAppDbContext();

        // GET: Home
        public ActionResult Index()
        {

            var film = _context.Filmy.ToList();

            //    var film = _context.Filmy.Include(i => i.ID_GAT).ToList();
            
            return View(film);
        }

        public ActionResult Kino()
        {
            return View();
        }

        public ActionResult Kontakt()
        {
            return View();
        }

        public ActionResult Gat()
        {
            var gat = _context.Gatunki.ToList();
            return View(gat);
        }

        public ActionResult Kat()
        {
            var kat = _context.Kategorie.ToList();
            return View(kat);
        }

        public ActionResult Repertuar()
        {
            var seans = _context.Seanse.ToList();
            return View(seans);
        }

        public ActionResult Cennik()
        {
            var miejsce = _context.Miejsca.ToList();
            return View(miejsce);
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