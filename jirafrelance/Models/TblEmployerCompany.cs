using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblEmployerCompany
    {
        public int PkCompanyId { get; set; }
        public string FkCompanyEmployer { get; set; }
        public string CompanyName { get; set; }
        public string EmployerIndustry { get; set; }

        public virtual ApplicationUser FkCompanyEmployerNavigation { get; set; }
    }
}
