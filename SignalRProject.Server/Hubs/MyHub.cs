using Microsoft.AspNetCore.SignalR;

namespace SignalRProject.Hubs
{
    public class MyHub : Hub
    {
        public static List<string> Messages { get; set; } = new List<string>();
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }

        public async Task GetMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage",Messages);
        }
    }
}
