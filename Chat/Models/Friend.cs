using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class Friend
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public string FriendId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}