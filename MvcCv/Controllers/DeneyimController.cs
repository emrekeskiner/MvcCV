using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepostory deneyimRepostory = new DeneyimRepostory();
        public ActionResult DeneyimListesi()
        {
            var deneyim = deneyimRepostory.List();
            return View(deneyim);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            deneyimRepostory.TAdd(p);
            return RedirectToAction("DeneyimListesi");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = deneyimRepostory.Find(x => x.ID == id);
            deneyimRepostory.TDelete(t);
            return RedirectToAction("DeneyimListesi");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimlerim t = deneyimRepostory.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = deneyimRepostory.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            deneyimRepostory.TUpdate(t);
            return RedirectToAction("DeneyimListesi");
        }
    }
}