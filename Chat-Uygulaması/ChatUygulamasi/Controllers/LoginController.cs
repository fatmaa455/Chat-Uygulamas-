using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ChatUygulamasi.Models;
using ChatUygulamasi.Security;

namespace ChatUygulamasi.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {

        SohbetUygulamasiEntities model = new SohbetUygulamasiEntities();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(kullanicilar kullanici)
        {
            kullanicilar k = model.kullanicilar.FirstOrDefault(x => x.kullaniciAdi == kullanici.kullaniciAdi && x.sifre == kullanici.sifre);

            if (k == null)
            {
                ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı !";
                return View();
            }

            else
            {
                FormsAuthentication.SetAuthCookie(kullanici.kullaniciAdi, false);

                return RedirectToAction("Index", "Start");
            }

        }
    }
}