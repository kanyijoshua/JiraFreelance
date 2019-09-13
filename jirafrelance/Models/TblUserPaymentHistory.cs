using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblUserPaymentHistory
    {
        public TblUserPaymentHistory()
        {
            TblPaymentDeduction = new HashSet<TblPaymentDeduction>();
        }

        public int PkPayId { get; set; }
        public int FkWorkspacePay { get; set; }
        public string PayDescription { get; set; }
        public string PayAmount { get; set; }
        public string PayBalance { get; set; }
        public string PayDate { get; set; }
        public string PayDeductions { get; set; }
        public string FinalPay { get; set; }

        public virtual TblWorkspace FkWorkspacePayNavigation { get; set; }
        public virtual ICollection<TblPaymentDeduction> TblPaymentDeduction { get; set; }
    }
}
