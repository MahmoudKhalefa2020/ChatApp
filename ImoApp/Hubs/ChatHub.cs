using ImoApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace ImoApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;
        private readonly ImoContext _imoContext;
        public ChatHub(ILogger<ChatHub> logger, ImoContext imoContext)
        {
            _logger = logger;
            _imoContext = imoContext;
        }

        public async Task SendMessage(string user, string message, string messageDate)
        {
            if (!DateTime.TryParse(messageDate, out DateTime parsedDate))
            {
                // Handle parsing error, maybe log it or set a default value
                parsedDate = DateTime.UtcNow; // Example: Use current UTC time if parsing fails
            }
            await Clients.All.SendAsync("ReceiveMessage", user, message, messageDate);
            MessageChat messageChat = new MessageChat()
            {
                Message = message,
                User = user,
                MessageDate = parsedDate

            };
            _imoContext.MessageChats.Add(messageChat);
            await _imoContext.SaveChangesAsync();
        }



        #region chat Methods
        //public void NewMessage(string username, string message)
        //{
        //	var messagechat = new MessageChat();
        //	messagechat.User = username;
        //	messagechat.Message = message;
        //	imoContext.MessageChats.Add(messagechat);
        //	imoContext.SaveChanges();
        //	Clients.All.SendAsync("NotifyMessage", username, message);

        //}
        //public override Task OnConnectedAsync()
        //{
        //	string Name = Context.User.Identity.Name;
        //	Clients.All.SendAsync("NewUser", Name, Context.ConnectionId);
        //	return base.OnConnectedAsync();
        //}
        #endregion

    }
}
