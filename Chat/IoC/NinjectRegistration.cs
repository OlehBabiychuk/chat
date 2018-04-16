using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Interfaces;
using Chat.Models;
using Chat.Repositories;
using Ninject.Modules;

namespace Chat.IoC
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>()
                .To<UnitOfWork>()
                .InSingletonScope();
            Bind(typeof(IBaseRepository<>))
                .To(typeof(BaseRepository<>));
            Bind<ApplicationDbContext>()
                .To<ApplicationDbContext>();
        }
    }
}