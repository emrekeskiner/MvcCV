﻿using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       

        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities db = new DbCvEntities();
            var admin = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi &&
            x.Sifre == p.Sifre);
            if(admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.KullaniciAdi, false);
                Session["KullaniciAdi"] = admin.KullaniciAdi.ToString();
                return RedirectToAction("Hakkimda", "Hakkimda");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index");
        }
    }
}