using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRtcModels;

namespace SignalRtcHubs
{
    public class SignalRtcHub : Hub
    {
        private static Dictionary<string, List<string>> rooms;

        static SignalRtcHub()
        {
            rooms = new Dictionary<string, List<string>>();
        }

        public async Task JoinRoom(string roomId)
        {
            if (!rooms.ContainsKey(roomId))
            {
                rooms.Add(roomId, new List<string>());
                await Clients.Caller.SendAsync("Created");
                await Clients.Others.SendAsync("ReceiveCreatedRooms", rooms.Keys);
            }
            else
            {
                await Clients.OthersInGroup(roomId).SendAsync("JoinedNewClient", Context.ConnectionId);
            }

            rooms[roomId].Add(Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);

            await Clients.Caller.SendAsync("Joined"); 
        }

        //public async Task LeaveRoom(string roomId)
        //{
        //    rooms[roomId].Remove(Context.ConnectionId);
        //    if (rooms[roomId].Count == 0)
        //        rooms.Remove(roomId);
                
        //    await Clients.Caller.SendAsync("Leaved");
        //}

        public async Task GetCreatedRooms()
        {
            await Clients.Caller.SendAsync("ReceiveCreatedRooms", rooms.Keys);
        }

        public async Task SendOffer(string clientId, object offer)
        {
            await Clients.Client(clientId).SendAsync("ReceiveOffer", Context.ConnectionId, offer);
        }

        public async Task AddIceCandidate(string roomId, object obj)
        {
            await Clients.OthersInGroup(roomId).SendAsync("ReceiveIceCandidate", Context.ConnectionId, obj);
        }

        //public async Task SendMessage(object obj)
        //{
        //    await Clients.Others.SendAsync("ReceiveMessage", obj);
        //} 
    }
}
