using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ChatUygulamasi.Models;

namespace ChatUygulamasi.Security
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        // Kullanıcının rollerini döndürür
        public override string[] GetRolesForUser(string username)
        {

            SohbetUygulamasiEntities model = new SohbetUygulamasiEntities();

            kullanicilar kullanici = model.kullanicilar.FirstOrDefault(x => x.kullaniciAdi == username);

            if (kullanici == null)
            {
                // Kullanıcı bulunamadı, boş bir dizi döndürebilirsiniz veya isteğinize göre bir hata işleme stratejisi uygulayabilirsiniz.
                return new string[0];
            }

            List<roller> r = model.roller.ToList();
            List<string> rollerListesi = new List<string>();

            foreach (roller rolDurum in r)
            {
                if (rolDurum.rolId == kullanici.rolId)
                {
                    rollerListesi.Add(rolDurum.rolAd);
                }
            }

            // Kullanıcının rollerini string dizisi olarak döndürün.
            return rollerListesi.ToArray();

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}