using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [Key]

        public int PkWkspcId { get; set; }
        public int FkWkspcBid { get; set; }
        [DataType(DataType.Date)]
        public DateTime WkspcStartTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime WkspcExpectendEndTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime WkspcActualEndTime { get; set; }
        public string WkspcRating { get; set; }
        public string WkspcStatus { get; set; }
        public string WkspcFeedback { get; set; }
        public string WkspcAmountAgreed { get; set; }
        
        [ForeignKey("FkWkspcBid")]
        public virtual TblBid FkWkspcB { get; set; }
        public virtual ICollection<TblChatWorkspace> TblChatWorkspace { get; set; }
        public virtual ICollection<TblDispute> TblDispute { get; set; }
        public virtual ICollection<TblUserPaymentHistory> TblUserPaymentHistory { get; set; }
    }
}
