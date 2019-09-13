using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblChatDirect
    {
        public int PkDirectChatId { get; set; }
        //public string FkDirectChatAdmin { get; set; }
        public string FkDirectChatEmployer { get; set; }
        public string DirectChatMessage { get; set; }
        public string DirectChatTimeSent { get; set; }
        public string DirectChatSender { get; set; }
        public string DirectChatStatus { get; set; }
        public string DirectChatTimeRead { get; set; }

        //public virtual ApplicationUser FkDirectChatAdminNavigation { get; set; }
        public virtual ApplicationUser FkDirectChatEmployerNavigation { get; set; }
    }
}
