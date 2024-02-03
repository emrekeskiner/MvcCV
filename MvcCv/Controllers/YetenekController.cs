using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek

        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>(); 
        public ActionResult YetenekListesi()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("YetenekListesi");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.TGet(id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim p)
        {
            var yetenek = repo.Find(x => x.ID == p.ID);
            yetenek.Yetenek = p.Yetenek;
            yetenek.Oran = p.Oran;
            repo.TUpdate(yetenek);
            return RedirectToAction("YetenekListesi");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            
            return RedirectToAction("YetenekListesi");
        }
    }
}