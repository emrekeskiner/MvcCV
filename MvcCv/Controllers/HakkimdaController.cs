using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda

        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        [HttpGet]
        public ActionResult Hakkimda()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Hakkimda(TblHakkimda p)
        {
            if (p.Resim != null)
            {


                if (Request.Files.Count > 0)

                {

                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);

                    string uzanti = Path.GetExtension(Request.Files[0].FileName);

                    string yol = "~/image/" + dosyaadi + uzanti;

                    Request.Files[0].SaveAs(Server.MapPath(yol));

                    p.Resim = "/image/" + dosyaadi + uzanti;



                }
            }

            var hakkimda = repo.Find(x => x.ID == 1);
            hakkimda.Ad = p.Ad;
            hakkimda.Soyad = p.Soyad;
            hakkimda.Mail = p.Mail;
            hakkimda.Telefon = p.Telefon;
            hakkimda.Adres = p.Adres;
            hakkimda.Aciklama = p.Aciklama;
            if(p.Resim != null)
            {
                hakkimda.Resim = p.Resim;
            }
           
            repo.TUpdate(hakkimda);
            return RedirectToAction("Hakkimda");
        }
    }
}