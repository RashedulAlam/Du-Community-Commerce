using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DU_Community_Commerce_Server_Side.Models
{
    public class SearchItem
    {
        [Key]
        public string SearchId { get; set; }
        public string SearchText { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }

        public SearchItem()
        {
            SearchId = Guid.NewGuid().ToString();
            DateTime=DateTime.Now;
        }
    }
}