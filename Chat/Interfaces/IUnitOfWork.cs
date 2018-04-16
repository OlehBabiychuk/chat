using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chat.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<ApplicationUser> UsersRepo { get; }
        IBaseRepository<FriendRequest> RequestsRepo { get; }
        IBaseRepository<Friend> FriendsRepo { get; }
        int Save();
    }
}