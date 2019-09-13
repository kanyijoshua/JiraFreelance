using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblDepositDeduction
    {
        public int PkDepositDeductionId { get; set; }
        public int FkDepositDeductionHistory { get; set; }
        public string DepositDeductionDescription { get; set; }
        public string DepositDeductionAmount { get; set; }

        public virtual TblEmployerDepositHistory FkDepositDeductionHistoryNavigation { get; set; }
    }
}
