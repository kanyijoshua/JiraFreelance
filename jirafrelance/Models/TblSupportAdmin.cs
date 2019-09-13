using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblSupportAdmin
    {
        public TblSupportAdmin()
        {
            TblChatBid = new HashSet<TblChatBid>();
            TblChatDirect = new HashSet<TblChatDirect>();
        }

        public int PkSupportAdminId { get; set; }
        public string SupportAdminFname { get; set; }
        public string SupportAdminEmail { get; set; }
        public string SupportAdminPhone { get; set; }
        public string SupportAdminUsername { get; set; }
        public string SupportAdminPassword { get; set; }

        public virtual ICollection<TblChatBid> TblChatBid { get; set; }
        public virtual ICollection<TblChatDirect> TblChatDirect { get; set; }
    }
}
