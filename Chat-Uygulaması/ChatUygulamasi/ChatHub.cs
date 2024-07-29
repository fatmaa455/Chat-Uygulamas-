using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using ChatUygulamasi.Models;

namespace ChatUygulamasi
{
    // ChatHub, kullanıcıların birbirlerine mesaj göndermesini ve bu mesajların güncellenmesini sağlar.
    // Ayrıca kullanıcı bağlantı durumlarını yönetir.
    public class ChatHub : Hub
    {
        SohbetUygulamasiEntities model = new SohbetUygulamasiEntities();

        // Mesaj gönderme metodu
        public void Send(string message, string username)
        {
            var gonderenAdi = Context.User.Identity.Name;

            var gonderen = model.kullanicilar.FirstOrDefault(k => k.kullaniciAdi == gonderenAdi);
            var alici = model.kullanicilar.FirstOrDefault(k => k.kullaniciAdi == username);

            if (gonderen == null || alici == null)
            {
                return; // Gönderen veya alıcı bulunamazsa mesaj gönderilmez
            }

            var mesaj = new mesaj
            {
                gonderenId = gonderen.kullaniciId,
                aliciAdi = username,
                icerik = message
            };

            model.mesaj.Add(mesaj);
            model.SaveChanges();

            // Mesajı hem alıcı grubuna hem de gönderici grubuna gönder
            Clients.Group(username).sendMessage(gonderenAdi, username, message, mesaj.mesajId);
            Clients.Group(gonderenAdi).sendMessage(gonderenAdi, username, message, mesaj.mesajId);
        }

        // Mesaj güncelleme metodu
        public void UpdateMessage(int messageId, string updatedMessage)
        {
            var mesaj = model.mesaj.FirstOrDefault(m => m.mesajId == messageId);

            if (mesaj == null)
            {
                return; // Mesaj bulunamazsa güncelleme yapılmaz
            }

            mesaj.icerik = updatedMessage;
            model.SaveChanges();

            // Güncellenmiş mesajı tüm kullanıcılara bildir
            Clients.All.updateMessage(messageId, updatedMessage);
        }

        // Kullanıcı bağlandığında çağrılır
        public override Task OnConnected()
        {
            string kullaniciAdi = Context.User.Identity.Name;
            Groups.Add(Context.ConnectionId, kullaniciAdi);
            return base.OnConnected();
        }

        // Kullanıcı bağlantıyı kestiğinde çağrılır
        public override Task OnDisconnected(bool stopCalled)
        {
            string kullaniciAdi = Context.User.Identity.Name;
            Groups.Remove(Context.ConnectionId, kullaniciAdi);
            return base.OnDisconnected(stopCalled);
        }

        // Kullanıcı tekrar bağlandığında çağrılır
        public override Task OnReconnected()
        {
            string kullaniciAdi = Context.User.Identity.Name;
            Groups.Add(Context.ConnectionId, kullaniciAdi);
            return base.OnReconnected();
        }
    }
}