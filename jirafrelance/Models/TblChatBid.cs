using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblChatBid
    {
        public int PkBidChatId { get; set; }
        public int FkBidChatBidding { get; set; }
        //public int FkBidChatAdmin { get; set; }
        public string FkBidChatUser { get; set; }
        public string BidChatMessage { get; set; }
        public string BidChatTimeSent { get; set; }
        public string BidChatSender { get; set; }
        public string BidChatStatus { get; set; }
        public string BidChatTimeRead { get; set; }

        //public virtual TblSupportAdmin FkBidChatAdminNavigation { get; set; }
        public virtual TblBid FkBidChatBiddingNavigation { get; set; }
        public virtual ApplicationUser FkBidChatUserNavigation { get; set; }
    }
}
