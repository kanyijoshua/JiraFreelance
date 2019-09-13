using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace jirafrelance.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            TblBid = new HashSet<TblBid>();
            TblChatBid = new HashSet<TblChatBid>();
            TblChatWorkspace = new HashSet<TblChatWorkspace>();
            TblUserCertification = new HashSet<TblUserCertification>();
            TblUserSkill = new HashSet<TblUserSkill>();
            TblChatDirect = new HashSet<TblChatDirect>();
            TblEmployerCompany = new HashSet<TblEmployerCompany>();
            TblEmployerDepositHistory = new HashSet<TblEmployerDepositHistory>();
            TblJob = new HashSet<TblJob>();
        }
        public enum Gender
        {
            Male,
            Female
        }
        public DateTime DateOfBirth { get; set; }
        public int Balance { get; set; }
        public int IdNumber { get; set; }
        public int County { get; set; }
        public Gender gender { get; set; }
        public virtual ICollection<TblBid> TblBid { get; set; }
        public virtual ICollection<TblChatBid> TblChatBid { get; set; }
        public virtual ICollection<TblChatWorkspace> TblChatWorkspace { get; set; }
        public virtual ICollection<TblUserCertification> TblUserCertification { get; set; }
        public virtual ICollection<TblUserSkill> TblUserSkill { get; set; }
        public string ProfilePhoto { get; set; }
        public string ProfileExpertiseOverview { get; set; }
        public string ProfileFeaturedWork { get; set; }
        public virtual ICollection<TblChatDirect> TblChatDirect { get; set; }
        public virtual ICollection<TblEmployerCompany> TblEmployerCompany { get; set; }
        public virtual ICollection<TblEmployerDepositHistory> TblEmployerDepositHistory { get; set; }
        public virtual ICollection<TblJob> TblJob { get; set; }
        //[ForeignKey("")]
        public virtual ICollection<TblProfile> TblProfile { get; set; }

    }
}
