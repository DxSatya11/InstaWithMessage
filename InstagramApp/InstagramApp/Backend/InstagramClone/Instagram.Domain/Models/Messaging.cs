using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.Models
{
    public class Messaging
    {
        public int Id { get; set; }
        public int SenderUserId { get; set; }
        public virtual Users Sender { get; set; }
        public int ReceiverUserId { get; set; }
        public virtual Users Receiver { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
