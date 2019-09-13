using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jirafrelance.Models
{
    public partial class TblBid
    {
        public TblBid()
        {
            TblChatBid = new HashSet<TblChatBid>();
            TblWorkspace = new HashSet<TblWorkspace>();
        }

        public int PkBidId { get; set; }
        public int FkJobBidded { get; set; }
        public string BidTime { get; set; }
        public string BidAwardTime { get; set; }
        [Required]
        public string FkBidUser { get; set; }
        [Required]
        public string BidOfferInformation { get; set; }
        public string BidStatus { get; set; }

        public virtual ApplicationUser FkBidUserNavigation { get; set; }
        public virtual TblJob FkJobBiddedNavigation { get; set; }
        public virtual ICollection<TblChatBid> TblChatBid { get; set; }
        public virtual ICollection<TblWorkspace> TblWorkspace { get; set; }
    }
}
