using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ChatUygulamasi.Models;

namespace CamlicaProje.Controllers
{
    [Authorize]
    public class RegisterController : Controller
    {
        SohbetUygulamasiEntities model = new SohbetUygulamasiEntities();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            kullanicilar kullanici = new kullanicilar();

            return View(kullanici);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(kullanicilar kullanici)
        {
            kullanicilar k = model.kullanicilar.FirstOrDefault(x => x.kullaniciAdi == kullanici.kullaniciAdi);

            if (k != null)
            {
                ViewBag.Mesaj = "Bu kullanıcı adı kullanılmakta ! Lütfen başka bir kullanıcı adı deneyiniz !";

                return View();
            }

            else
            {
                kullanici.rolId = 2;
                model.kullanicilar.Add(kullanici);

                model.SaveChanges();

                FormsAuthentication.SetAuthCookie(kullanici.kullaniciAdi, false);

                return RedirectToAction("Index", "Start");
            }
        }
    }
}