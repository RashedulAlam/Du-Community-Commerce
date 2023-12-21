using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace DU_Community_Commerce_Server_Side.Models
{
    public class UserHistory
    {
        [Key]
        public string HistoryId { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public DateTime DateTime { get; set; }

        public UserHistory()
        {
            HistoryId = Guid.NewGuid().ToString();
            DateTime=DateTime.Now;
        }

    }
}