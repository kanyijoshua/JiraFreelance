using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblJob
    {
        public TblJob()
        {
            TblBid = new HashSet<TblBid>();
            TblJobAttachment = new HashSet<TblJobAttachment>();
        }

        public int PkJobId { get; set; }
        public string FkJobEmployer { get; set; }
        public string JobTitle { get; set; }
        public string JobBudget { get; set; }
        public string JobCategory { get; set; }
        public string JobDuration { get; set; }
        public string JobDescription { get; set; }
        public string JobStatus { get; set; }

        public virtual ApplicationUser FkJobEmployerNavigation { get; set; }
        public virtual ICollection<TblBid> TblBid { get; set; }
        public virtual ICollection<TblJobAttachment> TblJobAttachment { get; set; }
    }
}
