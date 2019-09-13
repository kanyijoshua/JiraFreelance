using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace jirafrelance.Models
{
    public class Company
    {
        public Company()
        {
        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        [ForeignKey("FkUserNavigation")]
        public string UserId { get; set; }

        public virtual ApplicationUser FkUserNavigation { get; set; }
        public virtual ICollection<TblJob> TblJob { get; set; }

    }
}
