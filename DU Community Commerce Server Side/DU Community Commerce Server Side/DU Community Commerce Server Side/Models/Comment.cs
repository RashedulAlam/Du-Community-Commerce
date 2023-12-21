using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DU_Community_Commerce_Server_Side.Models
{
    public class Comment
    {
        [Key]
        public string CommentId { get; set; }
        public DateTime DateTime { get; set; }
        public string CommmentDescription { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }

        public Comment()
        {
            DateTime=DateTime.Now;
            CommentId = Guid.NewGuid().ToString();
        }
         
    }
}