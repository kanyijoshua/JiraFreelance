using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblPaymentDeduction
    {
        public int PkPayDeductionId { get; set; }
        public int FkPayDeductionHistory { get; set; }
        public string PayDeductionDescription { get; set; }
        public string PayDeductionAmount { get; set; }

        public virtual TblUserPaymentHistory FkPayDeductionHistoryNavigation { get; set; }
    }
}
