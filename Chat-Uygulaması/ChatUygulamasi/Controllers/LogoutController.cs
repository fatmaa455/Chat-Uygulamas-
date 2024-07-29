using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ChatUygulamasi.Security;

namespace ChatUygulamasi.Controllers
{
    [Authorize]
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Login");
        }
    }
}