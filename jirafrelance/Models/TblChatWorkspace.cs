using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblChatWorkspace
    {
        public int PkWkspChatId { get; set; }
        public int FkWkspChatWorkspace { get; set; }
        //public int FkWkspChatEmployer { get; set; }
        public string FkWkspChatUser { get; set; }
        public string WkspChatMessage { get; set; }
        public string WkspChatTimeSent { get; set; }
        public string WkspChatSender { get; set; }
        public string WkspChatStatus { get; set; }
        public string WkspChatTimeRead { get; set; }

        //public virtual TblEmployer FkWkspChatEmployerNavigation { get; set; }
        public virtual ApplicationUser FkWkspChatUserNavigation { get; set; }
        public virtual TblWorkspace FkWkspChatWorkspaceNavigation { get; set; }
    }
}
