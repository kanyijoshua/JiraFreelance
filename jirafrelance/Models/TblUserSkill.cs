using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblUserSkill
    {
        public int PkSkillId { get; set; }
        public string FkSkillUserId { get; set; }
        public string UserSkillName { get; set; }

        public virtual ApplicationUser FkSkillUser { get; set; }
    }
}
