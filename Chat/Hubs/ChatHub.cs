using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Chat.Interfaces;
using Chat.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        
        private static List<UserDTO> Users;
        private IUnitOfWork _unitOfWork;

        public ChatHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private UserDTO GetUser()
        {
            {
                var user = new UserDTO
                {
                    UserName = _unitOfWork.UsersRepo.GetAll().ToList().Find(c => c.Email == Context.User.Identity.Name).Email,
                    ConnectionId = Context.ConnectionId
                };

                return user;
            }

        }
        public void SendPublic(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients
            Clients.All.broadcastMessage(name, message);
        }



       




        public override Task OnConnected()
        {
            if (Users == null)
            {
                Users = new List<UserDTO>();
            }
            Users.Add(GetUser());
            Clients.All.showUsers(Users);
            Clients.All.OnMessage(
                "[server]", "Welcome to the chat room, " + Context.User.Identity.Name);
            return base.OnConnected();
        }

        public void Send(string message)
        {
            Clients.All.message(Context.User.Identity.GetUserName() +" " + message);

        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Users.Remove(Users.Find(c => c.ConnectionId == Context.ConnectionId));
            Clients.All.showUsers(Users);
            return base.OnDisconnected(stopCalled);
        }

        public void ShowPrivateChat(string userConnectionId)
        {
            Clients.Caller.openChat(userConnectionId);
        }
        public void SendPrivate(string userConnectionId, string message)
        {
            var s = Users.Any(c => c.ConnectionId == userConnectionId);
            if (Users.Any(c => c.ConnectionId == userConnectionId))
            {
                Clients.Client(userConnectionId).sendPrivate(message);
            }
        }


        public void UserTyping(string connectionId, string msg)
        {
            if (connectionId != null)
            {
                var id = Context.ConnectionId;
                Clients.Client(connectionId).isTyping(id, msg);
            }
        }

        public void SendRequest(string toId)
        {
            var user = _unitOfWork.UsersRepo.GetAll().ToList()
                .Find(c => c.Email == Users.Find(a => a.ConnectionId == toId).UserName ).Id;
            FriendRequest req = new FriendRequest
            {
                FromId = Context.User.Identity.GetUserId(),
                ToId = user
            };

            _unitOfWork.UsersRepo
                .GetAll()
                .ToList()
                .Find(c => c.Email == Users.Find(a => a.ConnectionId == toId).UserName)
                .FriendRequests.Add(req);
            _unitOfWork.Save();
            var reqId = _unitOfWork.RequestsRepo.GetAll().ToList().Find(c => c.FromId == req.FromId && c.ToId == req.ToId).Id;
            Clients.Client(toId).sendRequest(req.FromId, reqId);

        }

        public void Answer(string id, int reqId, string answer)
        {
            if (answer == "yes")
            {
                var list = _unitOfWork.UsersRepo.GetAll().ToList()
                    .Find(c => c.Email == Users.Find(a => a.ConnectionId != id).UserName).UserFriends.ToList();
                Friend user = new Friend
                {
                   
                    UserId = Context.User.Identity.GetUserId(),
                    
                    FriendId = _unitOfWork.UsersRepo.GetAll().ToList().Find(c => c.UserName == Users.Find(a => a.ConnectionId == id).UserName).Id
                   // FriendId = _unitOfWork.UsersRepo.GetAll().ToList().Where((c=>c.FriendRequests ==Users. ))
                };
                list.Add(user);
                var delreq = _unitOfWork.RequestsRepo.GetById(reqId);
                _unitOfWork.RequestsRepo.Delete(delreq);
                _unitOfWork.Save();
            }

            else
            {
                var delreqq = _unitOfWork.RequestsRepo.GetById(reqId);
                _unitOfWork.RequestsRepo.Delete(delreqq);
                _unitOfWork.Save();
            }
        }

        public void ChatAllert(string userId)
        {
            Clients.Caller.chatInfo("Chat with:" + Users.Find(c => c.ConnectionId == userId).UserName);
        }

        public void ShowUsers()
        {
            Clients.All.showUsers(Users);
        }
    }
}