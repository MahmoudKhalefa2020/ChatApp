using ImoApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace ImoApp.Hubs
{
    public class ChatHub:Hub
    {
        private readonly ImoContext imoContext ;
        public ChatHub(ImoContext _imoContext)
        {
            imoContext = _imoContext ;
        }
        public void NewMessage (string username ,string message)
        {
            var messagechat = new MessageChat();
            messagechat.User = username;
            messagechat.Message = message;
            imoContext.MessageChats.Add(messagechat);
            imoContext.SaveChanges();            
            Clients.All.SendAsync("NotifyMessage", username, message);

        }

        public override Task OnConnectedAsync()
        {
            string Name = Context.User.Identity.Name;
            Clients.All.SendAsync("NewUser", Name, Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
