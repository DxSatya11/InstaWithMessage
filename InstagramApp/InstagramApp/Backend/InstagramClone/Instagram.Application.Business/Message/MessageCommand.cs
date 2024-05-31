using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Message
{
    public class MessageCommand : IRequest<Unit>
    {
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public string? Message { get; set; } 
    }
}
