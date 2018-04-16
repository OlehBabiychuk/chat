using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Interfaces
{
    public interface IChatRepository
    {
        void Add(string name, string message);
    }
}