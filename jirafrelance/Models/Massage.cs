using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace jirafrelance.Models
{
    public class Massage
    {
        [Key]
        public int MessageId { get; set; }
        public  string sender_id { get; set; }
        public  string reciever_id { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        [ForeignKey("sender_id")]
        public virtual ApplicationUser FkSender { get; set; }
        [ForeignKey("reciever_id")]
        public virtual ApplicationUser FkReciever { get; set; }

    }
}
