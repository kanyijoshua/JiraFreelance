using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblProfile
    {
        public int PkProfileId { get; set; }
        public string FkProfileUser { get; set; }
        public string ProfilePhoto { get; set; }
        public string ProfileExpertiseOverview { get; set; }
        public string ProfileFeaturedWork { get; set; }

        public virtual ApplicationUser FkProfileUserNavigation { get; set; }
    }
}
