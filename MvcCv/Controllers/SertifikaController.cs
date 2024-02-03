using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();

        public ActionResult SertifikaListesi()
        {
            var sertifikaListesi = repo.List().ToList();
            return View(sertifikaListesi);
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim p)
        {
            repo.TAdd(p);

            return RedirectToAction("SertifikaListesi");
        }

        [HttpGet]
        public ActionResult SertifikaDuzenle(int id)
        {
            var sertifika = repo.TGet(id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaDuzenle(TblSertifikalarim p)
        {
            var sertifika = repo.Find(x => x.ID == p.ID);
            sertifika.Kurum = p.Kurum;
            sertifika.Aciklama = p.Aciklama;
            sertifika.Tarih = p.Tarih;
            repo.TUpdate(sertifika);

            return RedirectToAction("SertifikaListesi");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.TGet(id);
            repo.TDelete(sertifika);
            return RedirectToAction("SertifikaListesi");
        }
    }
}