using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(ChatUygulamasi.Startup))]

namespace ChatUygulamasi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // SignalR’ı çalışır hale getiren app.MapSignalR() konfigürasyonu yapılır
            app.MapSignalR();
        }
    }
}