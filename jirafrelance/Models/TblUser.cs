using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblBid = new HashSet<TblBid>();
            TblChatBid = new HashSet<TblChatBid>();
            TblChatWorkspace = new HashSet<TblChatWorkspace>();
            TblProfile = new HashSet<TblProfile>();
            TblUserCertification = new HashSet<TblUserCertification>();
            TblUserSkill = new HashSet<TblUserSkill>();
        }

        public int PkUserId { get; set; }
        public string UserIdNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserCounty { get; set; }
        public string UserGender { get; set; }
        public string UserDateOfBirth { get; set; }
        public string UserBalance { get; set; }

        public virtual ICollection<TblBid> TblBid { get; set; }
        public virtual ICollection<TblChatBid> TblChatBid { get; set; }
        public virtual ICollection<TblChatWorkspace> TblChatWorkspace { get; set; }
        public virtual ICollection<TblProfile> TblProfile { get; set; }
        public virtual ICollection<TblUserCertification> TblUserCertification { get; set; }
        public virtual ICollection<TblUserSkill> TblUserSkill { get; set; }
    }
}
