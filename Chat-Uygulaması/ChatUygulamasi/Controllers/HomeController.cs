using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatUygulamasi.Models;

namespace ChatUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        SohbetUygulamasiEntities model = new SohbetUygulamasiEntities();
        public ActionResult Index(int? id)
        {
            ViewBag.AliciId = id;

            List<kullanicilar> kullanici = model.kullanicilar.ToList();

            return View(kullanici);
        }
	}
}