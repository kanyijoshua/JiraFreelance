using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblEmployerDepositHistory
    {
        public TblEmployerDepositHistory()
        {
            TblDepositDeduction = new HashSet<TblDepositDeduction>();
        }

        public int PkDepositId { get; set; }
        public string FkDepositEmployer { get; set; }
        public string DepositDescription { get; set; }
        public string DepositAmount { get; set; }
        public string DepositBalance { get; set; }
        public string DepositDate { get; set; }
        public string DepositDeductions { get; set; }
        public string FinalDepositAmount { get; set; }

        public virtual ApplicationUser FkDepositEmployerNavigation { get; set; }
        public virtual ICollection<TblDepositDeduction> TblDepositDeduction { get; set; }
    }
}
