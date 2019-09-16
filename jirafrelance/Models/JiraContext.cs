using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace jirafrelance.Models
{
    public partial class JiraContext : IdentityDbContext<ApplicationUser>
    {
        public JiraContext()
        {
        }

        public JiraContext(DbContextOptions<JiraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBid> TblBid { get; set; }
        public virtual DbSet<TblChatBid> TblChatBid { get; set; }
        public virtual DbSet<TblChatDirect> TblChatDirect { get; set; }
        public virtual DbSet<TblChatWorkspace> TblChatWorkspace { get; set; }
        public virtual DbSet<TblDepositDeduction> TblDepositDeduction { get; set; }
        public virtual DbSet<TblDispute> TblDispute { get; set; }
        public virtual DbSet<TblEmployer> TblEmployer { get; set; }
        public virtual DbSet<TblEmployerCompany> TblEmployerCompany { get; set; }
        public virtual DbSet<TblEmployerDepositHistory> TblEmployerDepositHistory { get; set; }
        public virtual DbSet<TblJob> TblJob { get; set; }
        public virtual DbSet<TblJobAttachment> TblJobAttachment { get; set; }
        public virtual DbSet<TblPaymentDeduction> TblPaymentDeduction { get; set; }
        public virtual DbSet<TblProfile> TblProfile { get; set; }
        public virtual DbSet<TblSupportAdmin> TblSupportAdmin { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserCertification> TblUserCertification { get; set; }
        public virtual DbSet<TblUserPaymentHistory> TblUserPaymentHistory { get; set; }
        public virtual DbSet<TblUserSkill> TblUserSkill { get; set; }
        public virtual DbSet<TblWorkspace> TblWorkspace { get; set; }
        public virtual DbSet<Massage> Message { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=dbajira;Trusted_Connection=True;user id=kanyijoshua;password=kanyijoshua1");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //important for identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TblBid>(entity =>
            {
                entity.HasKey(e => e.PkBidId);

                entity.ToTable("tbl_bid");

                entity.Property(e => e.PkBidId).HasColumnName("pk_bid_id");

                entity.Property(e => e.BidAwardTime)
                    .HasColumnName("bid_award_time")
                    .HasMaxLength(20);

                entity.Property(e => e.BidOfferInformation)
                    .HasColumnName("bid_offer_information")
                    .HasColumnType("text");

                entity.Property(e => e.BidStatus)
                    .IsRequired()
                    .HasColumnName("bid_status")
                    .HasMaxLength(20);

                entity.Property(e => e.BidTime)
                    .IsRequired()
                    .HasColumnName("bid_time")
                    .HasMaxLength(50);

                entity.Property(e => e.FkBidUser).HasColumnName("fk_bid_user");

                entity.Property(e => e.FkJobBidded).HasColumnName("fk_job_bidded");

                entity.HasOne(d => d.FkBidUserNavigation)
                    .WithMany(p => p.TblBid)
                    .HasForeignKey(d => d.FkBidUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_bid__fk_bid___59FA5E80");

                entity.HasOne(d => d.FkJobBiddedNavigation)
                    .WithMany(p => p.TblBid)
                    .HasForeignKey(d => d.FkJobBidded)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_bid__fk_job___5AEE82B9");
            });

            modelBuilder.Entity<TblChatBid>(entity =>
            {
                entity.HasKey(e => e.PkBidChatId)
                    .HasName("PK_tbl_bid_chat");

                entity.ToTable("tbl_chat_bid");

                entity.Property(e => e.PkBidChatId).HasColumnName("pk_bid_chat_id");

                entity.Property(e => e.BidChatMessage)
                    .IsRequired()
                    .HasColumnName("bid_chat_message")
                    .HasColumnType("text");

                entity.Property(e => e.BidChatSender)
                    .IsRequired()
                    .HasColumnName("bid_chat_sender")
                    .HasMaxLength(20);

                entity.Property(e => e.BidChatStatus)
                    .IsRequired()
                    .HasColumnName("bid_chat_status")
                    .HasMaxLength(10);

                entity.Property(e => e.BidChatTimeRead)
                    .HasColumnName("bid_chat_time_read")
                    .HasMaxLength(20);

                entity.Property(e => e.BidChatTimeSent)
                    .IsRequired()
                    .HasColumnName("bid_chat_time_sent")
                    .HasMaxLength(20);

                //entity.Property(e => e.FkBidChatAdmin).HasColumnName("fk_bid_chat_admin");

                entity.Property(e => e.FkBidChatBidding).HasColumnName("fk_bid_chat_bidding");

                entity.Property(e => e.FkBidChatUser).HasColumnName("fk_bid_chat_user");

                //entity.HasOne(d => d.FkBidChatAdminNavigation)
                //    .WithMany(p => p.TblChatBid)
                //    .HasForeignKey(d => d.FkBidChatAdmin)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__tbl_chat___fk_bi__5DCAEF64");

                entity.HasOne(d => d.FkBidChatBiddingNavigation)
                    .WithMany(p => p.TblChatBid)
                    .HasForeignKey(d => d.FkBidChatBidding)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_chat___fk_bi__5CD6CB2B");

                entity.HasOne(d => d.FkBidChatUserNavigation)
                    .WithMany(p => p.TblChatBid)
                    .HasForeignKey(d => d.FkBidChatUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_chat___fk_bi__5BE2A6F2");
            });

            modelBuilder.Entity<TblChatDirect>(entity =>
            {
                entity.HasKey(e => e.PkDirectChatId);

                entity.ToTable("tbl_chat_direct");

                entity.Property(e => e.PkDirectChatId).HasColumnName("pk_direct_chat_id");

                entity.Property(e => e.DirectChatMessage)
                    .IsRequired()
                    .HasColumnName("direct_chat_message")
                    .HasColumnType("text");

                entity.Property(e => e.DirectChatSender)
                    .IsRequired()
                    .HasColumnName("direct_chat_sender")
                    .HasMaxLength(20);

                entity.Property(e => e.DirectChatStatus)
                    .IsRequired()
                    .HasColumnName("direct_chat_status")
                    .HasMaxLength(10);

                entity.Property(e => e.DirectChatTimeRead)
                    .HasColumnName("direct_chat_time_read")
                    .HasMaxLength(20);

                entity.Property(e => e.DirectChatTimeSent)
                    .IsRequired()
                    .HasColumnName("direct_chat_time_sent")
                    .HasMaxLength(20);

                //entity.Property(e => e.FkDirectChatAdmin).HasColumnName("fk_direct_chat_admin");

                entity.Property(e => e.FkDirectChatEmployer).HasColumnName("fk_direct_chat_employer");

                //entity.HasOne(d => d.FkDirectChatAdminNavigation)
                //    .WithMany(p => p.TblChatDirect)
                //    .HasForeignKey(d => d.FkDirectChatAdmin)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__tbl_chat___fk_di__5EBF139D");

                entity.HasOne(d => d.FkDirectChatEmployerNavigation)
                    .WithMany(p => p.TblChatDirect)
                    .HasForeignKey(d => d.FkDirectChatEmployer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_chat___fk_di__5FB337D6");
            });

            modelBuilder.Entity<TblChatWorkspace>(entity =>
            {
                entity.HasKey(e => e.PkWkspChatId);

                entity.ToTable("tbl_chat_workspace");

                entity.Property(e => e.PkWkspChatId).HasColumnName("pk_wksp_chat_id");

                //entity.Property(e => e.FkWkspChatEmployer).HasColumnName("fk_wksp_chat_employer");

                entity.Property(e => e.FkWkspChatUser).HasColumnName("fk_wksp_chat_user");

                entity.Property(e => e.FkWkspChatWorkspace).HasColumnName("fk_wksp_chat_workspace");

                entity.Property(e => e.WkspChatMessage)
                    .IsRequired()
                    .HasColumnName("wksp_chat_message")
                    .HasColumnType("text");

                entity.Property(e => e.WkspChatSender)
                    .IsRequired()
                    .HasColumnName("wksp_chat_sender")
                    .HasMaxLength(20);

                entity.Property(e => e.WkspChatStatus)
                    .IsRequired()
                    .HasColumnName("wksp_chat_status")
                    .HasMaxLength(10);

                entity.Property(e => e.WkspChatTimeRead)
                    .HasColumnName("wksp_chat_time_read")
                    .HasMaxLength(20);

                entity.Property(e => e.WkspChatTimeSent)
                    .IsRequired()
                    .HasColumnName("wksp_chat_time_sent")
                    .HasMaxLength(20);

                //entity.HasOne(d => d.FkWkspChatEmployerNavigation)
                //    .WithMany(p => p.TblChatWorkspace)
                //    .HasForeignKey(d => d.FkWkspChatEmployer)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__tbl_chat___fk_wk__628FA481");

                entity.HasOne(d => d.FkWkspChatUserNavigation)
                    .WithMany(p => p.TblChatWorkspace)
                    .HasForeignKey(d => d.FkWkspChatUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_chat___fk_wk__6383C8BA");

                entity.HasOne(d => d.FkWkspChatWorkspaceNavigation)
                    .WithMany(p => p.TblChatWorkspace)
                    .HasForeignKey(d => d.FkWkspChatWorkspace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_chat___fk_wk__60A75C0F");
            });

            modelBuilder.Entity<TblDepositDeduction>(entity =>
            {
                entity.HasKey(e => e.PkDepositDeductionId);

                entity.ToTable("tbl_deposit_deduction");

                entity.Property(e => e.PkDepositDeductionId).HasColumnName("pk_deposit_deduction_id");

                entity.Property(e => e.DepositDeductionAmount)
                    .IsRequired()
                    .HasColumnName("deposit_deduction_amount")
                    .HasMaxLength(20);

                entity.Property(e => e.DepositDeductionDescription)
                    .HasColumnName("deposit_deduction_description")
                    .HasColumnType("text");

                entity.Property(e => e.FkDepositDeductionHistory).HasColumnName("fk_deposit_deduction_history");

                entity.HasOne(d => d.FkDepositDeductionHistoryNavigation)
                    .WithMany(p => p.TblDepositDeduction)
                    .HasForeignKey(d => d.FkDepositDeductionHistory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_depos__fk_de__6477ECF3");
            });

            modelBuilder.Entity<TblDispute>(entity =>
            {
                entity.HasKey(e => e.PkDisptId);

                entity.ToTable("tbl_dispute");

                entity.Property(e => e.PkDisptId).HasColumnName("pk_dispt_id");

                entity.Property(e => e.DisptConclusionTime)
                    .HasColumnName("dispt_conclusion_time")
                    .HasMaxLength(20);

                entity.Property(e => e.DisptOutcome)
                    .HasColumnName("dispt_outcome")
                    .HasColumnType("text");

                entity.Property(e => e.DisptRaiseTime)
                    .IsRequired()
                    .HasColumnName("dispt_raise_time")
                    .HasMaxLength(20);

                entity.Property(e => e.DisptReason)
                    .IsRequired()
                    .HasColumnName("dispt_reason")
                    .HasColumnType("text");

                entity.Property(e => e.DisptStatus)
                    .IsRequired()
                    .HasColumnName("dispt_status")
                    .HasMaxLength(50);

                entity.Property(e => e.FkDisptWorkspace).HasColumnName("fk_dispt_workspace");

                entity.HasOne(d => d.FkDisptWorkspaceNavigation)
                    .WithMany(p => p.TblDispute)
                    .HasForeignKey(d => d.FkDisptWorkspace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_dispu__fk_di__656C112C");
            });

            modelBuilder.Entity<TblEmployer>(entity =>
            {
                entity.HasKey(e => e.PkEmpId);

                entity.ToTable("tbl_employer");

                entity.Property(e => e.PkEmpId).HasColumnName("pk_emp_id");

                entity.Property(e => e.EmpBalance)
                    .IsRequired()
                    .HasColumnName("emp_balance")
                    .HasMaxLength(20);

                entity.Property(e => e.EmpEmail)
                    .IsRequired()
                    .HasColumnName("emp_email")
                    .HasMaxLength(100);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("emp_name")
                    .HasMaxLength(100);

                entity.Property(e => e.EmpPhone)
                    .HasColumnName("emp_phone")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblEmployerCompany>(entity =>
            {
                entity.HasKey(e => e.PkCompanyId);

                entity.ToTable("tbl_employer_company");

                entity.Property(e => e.PkCompanyId).HasColumnName("pk_company_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasMaxLength(150);

                entity.Property(e => e.EmployerIndustry)
                    .IsRequired()
                    .HasColumnName("employer_industry")
                    .HasMaxLength(100);

                entity.Property(e => e.FkCompanyEmployer).HasColumnName("fk_company_employer");

                entity.HasOne(d => d.FkCompanyEmployerNavigation)
                    .WithMany(p => p.TblEmployerCompany)
                    .HasForeignKey(d => d.FkCompanyEmployer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_emplo__fk_co__66603565");
            });

            modelBuilder.Entity<TblEmployerDepositHistory>(entity =>
            {
                entity.HasKey(e => e.PkDepositId)
                    .HasName("PK_tbl_employer_deposit");

                entity.ToTable("tbl_employer_deposit_history");

                entity.Property(e => e.PkDepositId).HasColumnName("pk_deposit_id");

                entity.Property(e => e.DepositAmount)
                    .IsRequired()
                    .HasColumnName("deposit_amount")
                    .HasMaxLength(20);

                entity.Property(e => e.DepositBalance)
                    .IsRequired()
                    .HasColumnName("deposit_balance")
                    .HasMaxLength(20);

                entity.Property(e => e.DepositDate)
                    .IsRequired()
                    .HasColumnName("deposit_date")
                    .HasMaxLength(20);

                entity.Property(e => e.DepositDeductions)
                    .IsRequired()
                    .HasColumnName("deposit_deductions")
                    .HasMaxLength(20);

                entity.Property(e => e.DepositDescription)
                    .HasColumnName("deposit_description")
                    .HasColumnType("text");

                entity.Property(e => e.FinalDepositAmount)
                    .IsRequired()
                    .HasColumnName("final_deposit_amount")
                    .HasMaxLength(20);

                entity.Property(e => e.FkDepositEmployer).HasColumnName("fk_deposit_employer");

                entity.HasOne(d => d.FkDepositEmployerNavigation)
                    .WithMany(p => p.TblEmployerDepositHistory)
                    .HasForeignKey(d => d.FkDepositEmployer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_emplo__fk_de__6754599E");
            });

            modelBuilder.Entity<TblJob>(entity =>
            {
                entity.HasKey(e => e.PkJobId);

                entity.ToTable("tbl_job");

                entity.Property(e => e.PkJobId).HasColumnName("pk_job_id");

                entity.Property(e => e.FkJobEmployer).HasColumnName("fk_job_employer");

                entity.Property(e => e.JobBudget)
                    .IsRequired()
                    .HasColumnName("job_budget")
                    .HasMaxLength(50);

                entity.Property(e => e.JobCategory)
                    .IsRequired()
                    .HasColumnName("job_category")
                    .HasMaxLength(100);

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasColumnName("job_description")
                    .HasColumnType("text");

                entity.Property(e => e.JobDuration)
                    .IsRequired()
                    .HasColumnName("job_duration")
                    .HasMaxLength(50);

                entity.Property(e => e.JobStatus)
                    .IsRequired()
                    .HasColumnName("job_status")
                    .HasMaxLength(20);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("job_title")
                    .HasMaxLength(200);

                entity.HasOne(d => d.FkJobEmployerNavigation)
                    .WithMany(p => p.TblJob)
                    .HasForeignKey(d => d.FkJobEmployer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_job__fk_job___68487DD7");
            });

            modelBuilder.Entity<TblJobAttachment>(entity =>
            {
                entity.HasKey(e => e.PkJobAttachmentId);

                entity.ToTable("tbl_job_attachment");

                entity.Property(e => e.PkJobAttachmentId).HasColumnName("pk_job_attachment_id");

                entity.Property(e => e.FkAttachmentJob).HasColumnName("fk_attachment_job");

                entity.Property(e => e.JobAttachmentDownloadName)
                    .IsRequired()
                    .HasColumnName("job_attachment_download_name")
                    .HasMaxLength(300);

                entity.Property(e => e.JobAttachmentFileName)
                    .IsRequired()
                    .HasColumnName("job_attachment_file_name")
                    .HasMaxLength(300);

                entity.Property(e => e.JobAttachmentFilePath)
                    .IsRequired()
                    .HasColumnName("job_attachment_file_path")
                    .HasMaxLength(500);

                entity.HasOne(d => d.FkAttachmentJobNavigation)
                    .WithMany(p => p.TblJobAttachment)
                    .HasForeignKey(d => d.FkAttachmentJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_job_a__fk_at__693CA210");
            });

            modelBuilder.Entity<TblPaymentDeduction>(entity =>
            {
                entity.HasKey(e => e.PkPayDeductionId);

                entity.ToTable("tbl_payment_deduction");

                entity.Property(e => e.PkPayDeductionId).HasColumnName("pk_pay_deduction_id");

                entity.Property(e => e.FkPayDeductionHistory).HasColumnName("fk_pay_deduction_history");

                entity.Property(e => e.PayDeductionAmount)
                    .IsRequired()
                    .HasColumnName("pay_deduction_amount")
                    .HasMaxLength(20);

                entity.Property(e => e.PayDeductionDescription)
                    .HasColumnName("pay_deduction_description")
                    .HasColumnType("text");

                entity.HasOne(d => d.FkPayDeductionHistoryNavigation)
                    .WithMany(p => p.TblPaymentDeduction)
                    .HasForeignKey(d => d.FkPayDeductionHistory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_payme__fk_pa__6A30C649");
            });

            modelBuilder.Entity<TblProfile>(entity =>
            {
                entity.HasKey(e => e.PkProfileId);

                entity.ToTable("tbl_profile");

                entity.Property(e => e.PkProfileId).HasColumnName("pk_profile_id");

                entity.Property(e => e.FkProfileUser).HasColumnName("fk_profile_user");

                entity.Property(e => e.ProfileExpertiseOverview)
                    .HasColumnName("profile_expertise_overview")
                    .HasColumnType("text");

                entity.Property(e => e.ProfileFeaturedWork)
                    .HasColumnName("profile_featured_work")
                    .HasColumnType("text");

                entity.Property(e => e.ProfilePhoto)
                    .HasColumnName("profile_photo")
                    .HasMaxLength(20);

                entity.HasOne(d => d.FkProfileUserNavigation)
                    .WithMany(p => p.TblProfile)
                    .HasForeignKey(d => d.FkProfileUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_profi__fk_pr__6B24EA82");
            });

            modelBuilder.Entity<TblSupportAdmin>(entity =>
            {
                entity.HasKey(e => e.PkSupportAdminId);

                entity.ToTable("tbl_support_admin");

                entity.Property(e => e.PkSupportAdminId).HasColumnName("pk_support_admin_id");

                entity.Property(e => e.SupportAdminEmail)
                    .IsRequired()
                    .HasColumnName("support_admin_email")
                    .HasMaxLength(100);

                entity.Property(e => e.SupportAdminFname)
                    .IsRequired()
                    .HasColumnName("support_admin_fname")
                    .HasMaxLength(100);

                entity.Property(e => e.SupportAdminPassword)
                    .IsRequired()
                    .HasColumnName("support_admin_password")
                    .HasMaxLength(200);

                entity.Property(e => e.SupportAdminPhone)
                    .IsRequired()
                    .HasColumnName("support_admin_phone")
                    .HasMaxLength(20);

                entity.Property(e => e.SupportAdminUsername)
                    .IsRequired()
                    .HasColumnName("support_admin_username")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.PkUserId);

                entity.ToTable("tbl_user");

                entity.Property(e => e.PkUserId).HasColumnName("pk_user_id");

                entity.Property(e => e.UserBalance)
                    .IsRequired()
                    .HasColumnName("user_balance")
                    .HasMaxLength(10);

                entity.Property(e => e.UserCounty)
                    .IsRequired()
                    .HasColumnName("user_county")
                    .HasMaxLength(30);

                entity.Property(e => e.UserDateOfBirth)
                    .IsRequired()
                    .HasColumnName("user_date_of_birth")
                    .HasMaxLength(20);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(70);

                entity.Property(e => e.UserGender)
                    .IsRequired()
                    .HasColumnName("user_gender")
                    .HasMaxLength(15);

                entity.Property(e => e.UserIdNumber)
                    .HasColumnName("user_id_number")
                    .HasMaxLength(30);

                entity.Property(e => e.UserPhone)
                    .HasColumnName("user_phone")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TblUserCertification>(entity =>
            {
                entity.HasKey(e => e.PkCertificationId);

                entity.ToTable("tbl_user_certification");

                entity.Property(e => e.PkCertificationId).HasColumnName("pk_certification_id");

                entity.Property(e => e.CertificationName)
                    .IsRequired()
                    .HasColumnName("certification_name")
                    .HasMaxLength(10);

                entity.Property(e => e.FkCertificationUserId).HasColumnName("fk_certification_user_id");

                entity.HasOne(d => d.FkCertificationUser)
                    .WithMany(p => p.TblUserCertification)
                    .HasForeignKey(d => d.FkCertificationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_user___fk_ce__6C190EBB");
            });

            modelBuilder.Entity<TblUserPaymentHistory>(entity =>
            {
                entity.HasKey(e => e.PkPayId);

                entity.ToTable("tbl_user_payment_history");

                entity.Property(e => e.PkPayId).HasColumnName("pk_pay_id");

                entity.Property(e => e.FinalPay)
                    .IsRequired()
                    .HasColumnName("final_pay")
                    .HasMaxLength(20);

                entity.Property(e => e.FkWorkspacePay).HasColumnName("fk_workspace_pay");

                entity.Property(e => e.PayAmount)
                    .IsRequired()
                    .HasColumnName("pay_amount")
                    .HasMaxLength(20);

                entity.Property(e => e.PayBalance)
                    .IsRequired()
                    .HasColumnName("pay_balance")
                    .HasMaxLength(20);

                entity.Property(e => e.PayDate)
                    .IsRequired()
                    .HasColumnName("pay_date")
                    .HasMaxLength(20);

                entity.Property(e => e.PayDeductions)
                    .IsRequired()
                    .HasColumnName("pay_deductions")
                    .HasMaxLength(20);

                entity.Property(e => e.PayDescription)
                    .HasColumnName("pay_description")
                    .HasColumnType("text");

                entity.HasOne(d => d.FkWorkspacePayNavigation)
                    .WithMany(p => p.TblUserPaymentHistory)
                    .HasForeignKey(d => d.FkWorkspacePay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_user___fk_wo__6D0D32F4");
            });

            modelBuilder.Entity<TblUserSkill>(entity =>
            {
                entity.HasKey(e => e.PkSkillId);

                entity.ToTable("tbl_user_skill");

                entity.Property(e => e.PkSkillId).HasColumnName("pk_skill_id");

                entity.Property(e => e.FkSkillUserId).HasColumnName("fk_skill_user_id");

                entity.Property(e => e.UserSkillName)
                    .IsRequired()
                    .HasColumnName("user_skill_name")
                    .HasColumnType("text");

                entity.HasOne(d => d.FkSkillUser)
                    .WithMany(p => p.TblUserSkill)
                    .HasForeignKey(d => d.FkSkillUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_user___fk_sk__6E01572D");
            });

            modelBuilder.Entity<Massage>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("tbl_massages");

                //entity.Property(e => e.PkDepositDeductionId).HasColumnName("pk_deposit_deduction_id");

                //entity.Property(e => e.DepositDeductionAmount)
                //    .IsRequired()
                //    .HasColumnName("deposit_deduction_amount")
                //    .HasMaxLength(20);

                //entity.Property(e => e.DepositDeductionDescription)
                //    .HasColumnName("deposit_deduction_description")
                //    .HasColumnType("text");

                //entity.Property(e => e.FkDepositDeductionHistory).HasColumnName("fk_deposit_deduction_history");

                entity.HasOne<ApplicationUser>(d => d.FkSender)
                    .WithMany(p => p.massages)
                    .HasForeignKey(d => d.sender_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_mass__fk_se__6477ECF3");

                //entity.HasOne<ApplicationUser>(d => d.FkReciever)
                //    .WithMany(p => p.massages)
                //    .HasForeignKey(d => d.reciever_id)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__tbl_mass__fk_re__6477ECF3");
            });

            modelBuilder.Entity<TblWorkspace>(entity =>
            {
                entity.HasKey(e => e.PkWkspcId);

                entity.ToTable("tbl_workspace");

                entity.Property(e => e.PkWkspcId).HasColumnName("pk_wkspc_id");

                entity.Property(e => e.FkWkspcBid).HasColumnName("fk_wkspc_bid");

                entity.Property(e => e.WkspcActualEndTime)
                    .HasColumnName("wkspc_actual_end_time")
                    .HasMaxLength(20);

                entity.Property(e => e.WkspcAmountAgreed)
                    .IsRequired()
                    .HasColumnName("wkspc_amount_agreed")
                    .HasMaxLength(20);

                entity.Property(e => e.WkspcExpectendEndTime)
                    .IsRequired()
                    .HasColumnName("wkspc_expectend_end_time")
                    .HasMaxLength(20);

                entity.Property(e => e.WkspcFeedback)
                    .HasColumnName("wkspc_feedback")
                    .HasColumnType("text");

                entity.Property(e => e.WkspcRating)
                    .HasColumnName("wkspc_rating")
                    .HasMaxLength(10);

                entity.Property(e => e.WkspcStartTime)
                    .IsRequired()
                    .HasColumnName("wkspc_start_time")
                    .HasMaxLength(20);

                entity.Property(e => e.WkspcStatus)
                    .IsRequired()
                    .HasColumnName("wkspc_status")
                    .HasMaxLength(20);

                entity.HasOne(d => d.FkWkspcB)
                    .WithMany(p => p.TblWorkspace)
                    .HasForeignKey(d => d.FkWkspcBid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_works__fk_wk__6EF57B66");
            });
        }
    }
}
