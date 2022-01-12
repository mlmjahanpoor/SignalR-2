using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            if(DateTime.Now.Second > 10)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, "g1");

            }


            else if(DateTime.Now.Second > 10 && DateTime.Now.Second < 30)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, "g2");

            }
            else
            {
                Groups.AddToGroupAsync(Context.ConnectionId, "g3");

            }

            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message,string g)
        {

            var id = Context.ConnectionId;

            await Clients.Group(g).SendAsync("ReceiveMessage", user, message);
        }

        public async Task ShowMessage(string name)
        {
            await Clients.All.SendAsync("ShowMessage", name);
        }
    }
}
