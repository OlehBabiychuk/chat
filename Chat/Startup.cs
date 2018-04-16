using Chat.Hubs;
using Chat.Interfaces;
using Chat.IoC;
using Chat.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;

[assembly: OwinStartup(typeof(Chat.Startup))]

namespace Chat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(
                typeof(ChatHub),
                () => new ChatHub(new UnitOfWork(new ApplicationDbContext())));
            ConfigureAuth(app);
            app.MapSignalR();

        }
    }
}
