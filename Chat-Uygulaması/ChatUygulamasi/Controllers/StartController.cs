using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatUygulamasi.Models;

namespace ChatUygulamasi.Controllers
{
    public class StartController : Controller
    {
        SohbetUygulamasiEntities model = new SohbetUygulamasiEntities();
        // GET: Start
        public ActionResult Index()
        {
            List<kullanicilar> kullanici = model.kullanicilar.ToList();

            List<mesaj> m = model.mesaj.ToList();
            ViewBag.m = m;

            return View(kullanici);
        }
    }
}