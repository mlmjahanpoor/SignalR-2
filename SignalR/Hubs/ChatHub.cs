using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {

            var id = Context.ConnectionId;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task ShowMessage(string name)
        {
            await Clients.All.SendAsync("ShowMessage", name);
        }
    }
}
