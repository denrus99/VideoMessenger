using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRtcModels;

namespace SignalRtcHubs
{
    public class SignalRtcHub : Hub
    {
        public async Task SendMessage(object obj)
        {
            await Clients.Others.SendAsync("ReceiveMessage", obj);
        }

        public async Task AddIceCandidate(object obj)
        {
            await Clients.Others.SendAsync("ReceiveIceCandidate", obj);
        }
    }
}
