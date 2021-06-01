using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Entities.Concrete
{
    public class Message : IEntity
    {
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
