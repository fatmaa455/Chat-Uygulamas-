using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatUygulamasi.Security
{
    // custom authorization
    // authorize 'yi (default authorization) kullanmak yerine kendimize authorization oluşturduk
    public class MyAuthorization : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //  HttpContext üzerinden kişinin yetkisi olup olmadığına bakılır (authorization)
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                // sisteme girdikten sonra içindekini al
                base.OnAuthorization(filterContext);
            }

            // Kullanıcının yetkisi yoksa başka bir sayfaya yönlendirilir (unauthorization)
            else
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}