using Microsoft.AspNetCore.SignalR;

namespace SignalR.Api.Hubs
{
    public class ChatHub:Hub
    {

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message)
        {

            var id = Context.ConnectionId;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
