using Instagram.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Message
{
    public class MessageCommandHandler : IRequestHandler<MessageCommand, Unit>
    {
        private readonly InstagramDbContext _instagramDbContext;
        private readonly IHubContext<ChatHub> _hubContext;

        public MessageCommandHandler(InstagramDbContext instagramDbContext, IHubContext<ChatHub> hubContext)
        {
            _instagramDbContext = instagramDbContext;
            _hubContext = hubContext;
        }




        public async Task<Unit> Handle(MessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Domain.Models.Messaging
            {

                SenderUserId = request.SenderUserId,    
                ReceiverUserId = request.ReceiverUserId,
                Content = request.Message,
                Timestamp = DateTime.UtcNow,    

            };

            // Save the message to the database
            _instagramDbContext.Messagestb.Add(message);
            await _instagramDbContext.SaveChangesAsync();

            // Send the message in real-time using SignalR
            await _hubContext.Clients.User(request.ReceiverUserId.ToString())
                .SendAsync("ReceiveMessage", request.SenderUserId, request.ReceiverUserId, request.Message);


            /* var chatHub = new ChatHub(_instagramDbContext);*/ // Instantiate ChatHub with necessary dependencies


            var chatHub = new ChatHub();
            await chatHub.SendMessage(request.SenderUserId, request.ReceiverUserId, request.Message);

            return Unit.Value;
        }
    }
}
