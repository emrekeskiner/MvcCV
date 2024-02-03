using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult AdminList()
        {
            var admin = repo.List();
            return View(admin);
        }

        [HttpGet]
        public ActionResult Ekle()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Ekle(TblAdmin p)
        {
            p.Durum = true;
            repo.TAdd(p);
            return RedirectToAction("AdminList");
        }
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            var adm = repo.Find(x => x.ID == id);

            return View(adm);
        }

        [HttpPost]
        public ActionResult AdminGetir(TblAdmin p)
        {
            var adm = repo.Find(x => x.ID == p.ID);
            adm.KullaniciAdi = p.KullaniciAdi;
            adm.Sifre = p.Sifre;
            adm.Durum = true;
            repo.TUpdate(adm);

            return RedirectToAction("AdminList");
        }


        public ActionResult AdminSil(int id)
        {
            var adm = repo.Find(x => x.ID == id);
            adm.Durum = false;
            repo.TUpdate(adm);


            return RedirectToAction("AdminList");
        }
    }
}