using Instagram.Domain.Models;
using Instagram.Infrastructure.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Message
{
    public class ChatHub : Hub
    {   
        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            await Clients.User(receiverId.ToString()).SendAsync("ReceiveMessage", senderId, receiverId, message);

        }

        public override async Task OnConnectedAsync()
        {
           
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
          

            await base.OnDisconnectedAsync(exception);
        }
    }
}

