using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var hakkimda = db.TblHakkimda.ToList();
            return View(hakkimda);
        }

        public PartialViewResult Deneyim()
        {
            var deneyim = db.TblDeneyimlerim.ToList();
            return PartialView(deneyim);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitim = db.TblEgitimlerim.ToList();
            return PartialView(egitim);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenek = db.TblYeteneklerim.ToList();
            return PartialView(yetenek);
        }

        public PartialViewResult Hobilerim()
        {
            var hobi = db.TblHobilerim.ToList();
            return PartialView(hobi);
        }

        public PartialViewResult Sertifikalar()
        {
            var sertifika = db.TblSertifikalarim.ToList();
            return PartialView(sertifika);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalMedya);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim p)
        {
            p.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(p);
            db.SaveChanges();
            return PartialView("iletisim");
        }
    }
}