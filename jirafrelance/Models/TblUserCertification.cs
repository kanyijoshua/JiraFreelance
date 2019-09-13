using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblUserCertification
    {
        public int PkCertificationId { get; set; }
        public string FkCertificationUserId { get; set; }
        public string CertificationName { get; set; }

        public virtual ApplicationUser FkCertificationUser { get; set; }
    }
}
