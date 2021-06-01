using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Models
{
    public class MessageDetailModel
    {
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
