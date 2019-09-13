using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblWorkspace
    {
        public TblWorkspace()
        {
            TblChatWorkspace = new HashSet<TblChatWorkspace>();
            TblDispute = new HashSet<TblDispute>();
            TblUserPaymentHistory = new HashSet<TblUserPaymentHistory>();
        }

        public int PkWkspcId { get; set; }
        public int FkWkspcBid { get; set; }
        public string WkspcStartTime { get; set; }
        public string WkspcExpectendEndTime { get; set; }
        public string WkspcActualEndTime { get; set; }
        public string WkspcRating { get; set; }
        public string WkspcStatus { get; set; }
        public string WkspcFeedback { get; set; }
        public string WkspcAmountAgreed { get; set; }

        public virtual TblBid FkWkspcB { get; set; }
        public virtual ICollection<TblChatWorkspace> TblChatWorkspace { get; set; }
        public virtual ICollection<TblDispute> TblDispute { get; set; }
        public virtual ICollection<TblUserPaymentHistory> TblUserPaymentHistory { get; set; }
    }
}
