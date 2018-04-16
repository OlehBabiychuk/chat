using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chat.Models
{  
        public class ApplicationUser : IdentityUser
        {


            public ApplicationUser()
            {
                FriendRequests = new HashSet<FriendRequest>();
                UserFriends = new HashSet<Friend>();
            }

            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Здесь добавьте утверждения пользователя
                return userIdentity;
            }
            public virtual ICollection<FriendRequest> FriendRequests { get; set; }
            public virtual ICollection<Friend> UserFriends { get; set; }


        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {

            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }


            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
            public virtual DbSet<FriendRequest> FriendRequests { get; set; }
            public virtual DbSet<Friend> UserFriends { get; set; }
        }
}