using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DU_Community_Commerce_Server_Side.Models
{
    public class Message
    {
        [Key]
        public string MessageId { get; set; }
        public string UserId { get; set; }
        public string MessageDescription { get; set; }
        public string SentBy { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsSeen { get; set; }

        public Message()
        {
            MessageId = Guid.NewGuid().ToString();
            DateTime=DateTime.Now;
        }
    }
}