using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblEmployer
    {
        public TblEmployer()
        {
            TblChatDirect = new HashSet<TblChatDirect>();
            TblChatWorkspace = new HashSet<TblChatWorkspace>();
            TblEmployerCompany = new HashSet<TblEmployerCompany>();
            TblEmployerDepositHistory = new HashSet<TblEmployerDepositHistory>();
            TblJob = new HashSet<TblJob>();
        }

        public int PkEmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPhone { get; set; }
        public string EmpBalance { get; set; }

        public virtual ICollection<TblChatDirect> TblChatDirect { get; set; }
        public virtual ICollection<TblChatWorkspace> TblChatWorkspace { get; set; }
        public virtual ICollection<TblEmployerCompany> TblEmployerCompany { get; set; }
        public virtual ICollection<TblEmployerDepositHistory> TblEmployerDepositHistory { get; set; }
        public virtual ICollection<TblJob> TblJob { get; set; }
    }
}
