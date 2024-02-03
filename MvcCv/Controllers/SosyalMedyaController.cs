using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult SosyalMedyaList()
        {
            var smedya = repo.List();
            return View(smedya);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            
            return View();
        }

        [HttpPost]

        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("SosyalMedyaList");
        }
        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            
            return View(hesap);
        }

        [HttpPost]
        public ActionResult SosyalMedyaGetir(TblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.Link = p.Link;
            hesap.Simge = p.Simge;
            hesap.Durum = true;
            repo.TUpdate(hesap);

            return RedirectToAction("SosyalMedyaList");
        }

       
        public ActionResult SosyalMedyaSil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            if (hesap.Durum == true)
            {
                hesap.Durum = false;
            }
            else
            {
                hesap.Durum = true;
            }
            
            repo.TUpdate(hesap);


            return RedirectToAction("SosyalMedyaList");
        }
    }
}