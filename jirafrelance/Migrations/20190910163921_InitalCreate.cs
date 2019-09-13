using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jirafrelance.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<int>(nullable: false),
                    IdNumber = table.Column<int>(nullable: false),
                    County = table.Column<int>(nullable: false),
                    gender = table.Column<int>(nullable: false),
                    ProfilePhoto = table.Column<string>(nullable: true),
                    ProfileExpertiseOverview = table.Column<string>(nullable: true),
                    ProfileFeaturedWork = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employer",
                columns: table => new
                {
                    pk_emp_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    emp_name = table.Column<string>(maxLength: 100, nullable: false),
                    emp_email = table.Column<string>(maxLength: 100, nullable: false),
                    emp_phone = table.Column<string>(maxLength: 50, nullable: true),
                    emp_balance = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employer", x => x.pk_emp_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_support_admin",
                columns: table => new
                {
                    pk_support_admin_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    support_admin_fname = table.Column<string>(maxLength: 100, nullable: false),
                    support_admin_email = table.Column<string>(maxLength: 100, nullable: false),
                    support_admin_phone = table.Column<string>(maxLength: 20, nullable: false),
                    support_admin_username = table.Column<string>(maxLength: 30, nullable: false),
                    support_admin_password = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_support_admin", x => x.pk_support_admin_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    pk_user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id_number = table.Column<string>(maxLength: 30, nullable: true),
                    user_email = table.Column<string>(maxLength: 70, nullable: false),
                    user_phone = table.Column<string>(maxLength: 30, nullable: true),
                    user_county = table.Column<string>(maxLength: 30, nullable: false),
                    user_gender = table.Column<string>(maxLength: 15, nullable: false),
                    user_date_of_birth = table.Column<string>(maxLength: 20, nullable: false),
                    user_balance = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.pk_user_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employer_company",
                columns: table => new
                {
                    pk_company_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_company_employer = table.Column<string>(nullable: true),
                    company_name = table.Column<string>(maxLength: 150, nullable: false),
                    employer_industry = table.Column<string>(maxLength: 100, nullable: false),
                    TblEmployerPkEmpId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employer_company", x => x.pk_company_id);
                    table.ForeignKey(
                        name: "FK__tbl_emplo__fk_co__66603565",
                        column: x => x.fk_company_employer,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_employer_company_tbl_employer_TblEmployerPkEmpId",
                        column: x => x.TblEmployerPkEmpId,
                        principalTable: "tbl_employer",
                        principalColumn: "pk_emp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employer_deposit_history",
                columns: table => new
                {
                    pk_deposit_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_deposit_employer = table.Column<string>(nullable: true),
                    deposit_description = table.Column<string>(type: "text", nullable: true),
                    deposit_amount = table.Column<string>(maxLength: 20, nullable: false),
                    deposit_balance = table.Column<string>(maxLength: 20, nullable: false),
                    deposit_date = table.Column<string>(maxLength: 20, nullable: false),
                    deposit_deductions = table.Column<string>(maxLength: 20, nullable: false),
                    final_deposit_amount = table.Column<string>(maxLength: 20, nullable: false),
                    TblEmployerPkEmpId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employer_deposit", x => x.pk_deposit_id);
                    table.ForeignKey(
                        name: "FK__tbl_emplo__fk_de__6754599E",
                        column: x => x.fk_deposit_employer,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_employer_deposit_history_tbl_employer_TblEmployerPkEmpId",
                        column: x => x.TblEmployerPkEmpId,
                        principalTable: "tbl_employer",
                        principalColumn: "pk_emp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_job",
                columns: table => new
                {
                    pk_job_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_job_employer = table.Column<string>(nullable: true),
                    job_title = table.Column<string>(maxLength: 200, nullable: false),
                    job_budget = table.Column<string>(maxLength: 50, nullable: false),
                    job_category = table.Column<string>(maxLength: 100, nullable: false),
                    job_duration = table.Column<string>(maxLength: 50, nullable: false),
                    job_description = table.Column<string>(type: "text", nullable: false),
                    job_status = table.Column<string>(maxLength: 20, nullable: false),
                    TblEmployerPkEmpId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_job", x => x.pk_job_id);
                    table.ForeignKey(
                        name: "FK__tbl_job__fk_job___68487DD7",
                        column: x => x.fk_job_employer,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_job_tbl_employer_TblEmployerPkEmpId",
                        column: x => x.TblEmployerPkEmpId,
                        principalTable: "tbl_employer",
                        principalColumn: "pk_emp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_chat_direct",
                columns: table => new
                {
                    pk_direct_chat_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_direct_chat_employer = table.Column<string>(nullable: true),
                    direct_chat_message = table.Column<string>(type: "text", nullable: false),
                    direct_chat_time_sent = table.Column<string>(maxLength: 20, nullable: false),
                    direct_chat_sender = table.Column<string>(maxLength: 20, nullable: false),
                    direct_chat_status = table.Column<string>(maxLength: 10, nullable: false),
                    direct_chat_time_read = table.Column<string>(maxLength: 20, nullable: true),
                    TblEmployerPkEmpId = table.Column<int>(nullable: true),
                    TblSupportAdminPkSupportAdminId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_chat_direct", x => x.pk_direct_chat_id);
                    table.ForeignKey(
                        name: "FK__tbl_chat___fk_di__5FB337D6",
                        column: x => x.fk_direct_chat_employer,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_chat_direct_tbl_employer_TblEmployerPkEmpId",
                        column: x => x.TblEmployerPkEmpId,
                        principalTable: "tbl_employer",
                        principalColumn: "pk_emp_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_chat_direct_tbl_support_admin_TblSupportAdminPkSupportAdminId",
                        column: x => x.TblSupportAdminPkSupportAdminId,
                        principalTable: "tbl_support_admin",
                        principalColumn: "pk_support_admin_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_profile",
                columns: table => new
                {
                    pk_profile_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_profile_user = table.Column<string>(nullable: true),
                    profile_photo = table.Column<string>(maxLength: 20, nullable: true),
                    profile_expertise_overview = table.Column<string>(type: "text", nullable: true),
                    profile_featured_work = table.Column<string>(type: "text", nullable: true),
                    TblUserPkUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_profile", x => x.pk_profile_id);
                    table.ForeignKey(
                        name: "FK__tbl_profi__fk_pr__6B24EA82",
                        column: x => x.fk_profile_user,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_profile_tbl_user_TblUserPkUserId",
                        column: x => x.TblUserPkUserId,
                        principalTable: "tbl_user",
                        principalColumn: "pk_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_certification",
                columns: table => new
                {
                    pk_certification_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_certification_user_id = table.Column<string>(nullable: true),
                    certification_name = table.Column<string>(maxLength: 10, nullable: false),
                    TblUserPkUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_certification", x => x.pk_certification_id);
                    table.ForeignKey(
                        name: "FK__tbl_user___fk_ce__6C190EBB",
                        column: x => x.fk_certification_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_user_certification_tbl_user_TblUserPkUserId",
                        column: x => x.TblUserPkUserId,
                        principalTable: "tbl_user",
                        principalColumn: "pk_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_skill",
                columns: table => new
                {
                    pk_skill_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_skill_user_id = table.Column<string>(nullable: true),
                    user_skill_name = table.Column<string>(type: "text", nullable: false),
                    TblUserPkUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_skill", x => x.pk_skill_id);
                    table.ForeignKey(
                        name: "FK__tbl_user___fk_sk__6E01572D",
                        column: x => x.fk_skill_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_user_skill_tbl_user_TblUserPkUserId",
                        column: x => x.TblUserPkUserId,
                        principalTable: "tbl_user",
                        principalColumn: "pk_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_deposit_deduction",
                columns: table => new
                {
                    pk_deposit_deduction_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_deposit_deduction_history = table.Column<int>(nullable: false),
                    deposit_deduction_description = table.Column<string>(type: "text", nullable: true),
                    deposit_deduction_amount = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_deposit_deduction", x => x.pk_deposit_deduction_id);
                    table.ForeignKey(
                        name: "FK__tbl_depos__fk_de__6477ECF3",
                        column: x => x.fk_deposit_deduction_history,
                        principalTable: "tbl_employer_deposit_history",
                        principalColumn: "pk_deposit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bid",
                columns: table => new
                {
                    pk_bid_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_job_bidded = table.Column<int>(nullable: false),
                    bid_time = table.Column<string>(maxLength: 20, nullable: false),
                    bid_award_time = table.Column<string>(maxLength: 20, nullable: true),
                    fk_bid_user = table.Column<string>(nullable: true),
                    bid_offer_information = table.Column<string>(type: "text", nullable: true),
                    bid_status = table.Column<string>(maxLength: 20, nullable: false),
                    TblUserPkUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bid", x => x.pk_bid_id);
                    table.ForeignKey(
                        name: "FK__tbl_bid__fk_bid___59FA5E80",
                        column: x => x.fk_bid_user,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_bid__fk_job___5AEE82B9",
                        column: x => x.fk_job_bidded,
                        principalTable: "tbl_job",
                        principalColumn: "pk_job_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_bid_tbl_user_TblUserPkUserId",
                        column: x => x.TblUserPkUserId,
                        principalTable: "tbl_user",
                        principalColumn: "pk_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_job_attachment",
                columns: table => new
                {
                    pk_job_attachment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_attachment_job = table.Column<int>(nullable: false),
                    job_attachment_file_path = table.Column<string>(maxLength: 20, nullable: false),
                    job_attachment_file_name = table.Column<string>(maxLength: 100, nullable: false),
                    job_attachment_download_name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_job_attachment", x => x.pk_job_attachment_id);
                    table.ForeignKey(
                        name: "FK__tbl_job_a__fk_at__693CA210",
                        column: x => x.fk_attachment_job,
                        principalTable: "tbl_job",
                        principalColumn: "pk_job_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_chat_bid",
                columns: table => new
                {
                    pk_bid_chat_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_bid_chat_bidding = table.Column<int>(nullable: false),
                    fk_bid_chat_user = table.Column<string>(nullable: true),
                    bid_chat_message = table.Column<string>(type: "text", nullable: false),
                    bid_chat_time_sent = table.Column<string>(maxLength: 20, nullable: false),
                    bid_chat_sender = table.Column<string>(maxLength: 20, nullable: false),
                    bid_chat_status = table.Column<string>(maxLength: 10, nullable: false),
                    bid_chat_time_read = table.Column<string>(maxLength: 20, nullable: true),
                    TblSupportAdminPkSupportAdminId = table.Column<int>(nullable: true),
                    TblUserPkUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bid_chat", x => x.pk_bid_chat_id);
                    table.ForeignKey(
                        name: "FK__tbl_chat___fk_bi__5CD6CB2B",
                        column: x => x.fk_bid_chat_bidding,
                        principalTable: "tbl_bid",
                        principalColumn: "pk_bid_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_chat___fk_bi__5BE2A6F2",
                        column: x => x.fk_bid_chat_user,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_chat_bid_tbl_support_admin_TblSupportAdminPkSupportAdminId",
                        column: x => x.TblSupportAdminPkSupportAdminId,
                        principalTable: "tbl_support_admin",
                        principalColumn: "pk_support_admin_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_chat_bid_tbl_user_TblUserPkUserId",
                        column: x => x.TblUserPkUserId,
                        principalTable: "tbl_user",
                        principalColumn: "pk_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_workspace",
                columns: table => new
                {
                    pk_wkspc_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_wkspc_bid = table.Column<int>(nullable: false),
                    wkspc_start_time = table.Column<string>(maxLength: 20, nullable: false),
                    wkspc_expectend_end_time = table.Column<string>(maxLength: 20, nullable: false),
                    wkspc_actual_end_time = table.Column<string>(maxLength: 20, nullable: true),
                    wkspc_rating = table.Column<string>(maxLength: 10, nullable: true),
                    wkspc_status = table.Column<string>(maxLength: 20, nullable: false),
                    wkspc_feedback = table.Column<string>(type: "text", nullable: true),
                    wkspc_amount_agreed = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_workspace", x => x.pk_wkspc_id);
                    table.ForeignKey(
                        name: "FK__tbl_works__fk_wk__6EF57B66",
                        column: x => x.fk_wkspc_bid,
                        principalTable: "tbl_bid",
                        principalColumn: "pk_bid_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_chat_workspace",
                columns: table => new
                {
                    pk_wksp_chat_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_wksp_chat_workspace = table.Column<int>(nullable: false),
                    fk_wksp_chat_user = table.Column<string>(nullable: true),
                    wksp_chat_message = table.Column<string>(type: "text", nullable: false),
                    wksp_chat_time_sent = table.Column<string>(maxLength: 20, nullable: false),
                    wksp_chat_sender = table.Column<string>(maxLength: 20, nullable: false),
                    wksp_chat_status = table.Column<string>(maxLength: 10, nullable: false),
                    wksp_chat_time_read = table.Column<string>(maxLength: 20, nullable: true),
                    TblEmployerPkEmpId = table.Column<int>(nullable: true),
                    TblUserPkUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_chat_workspace", x => x.pk_wksp_chat_id);
                    table.ForeignKey(
                        name: "FK__tbl_chat___fk_wk__6383C8BA",
                        column: x => x.fk_wksp_chat_user,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_chat___fk_wk__60A75C0F",
                        column: x => x.fk_wksp_chat_workspace,
                        principalTable: "tbl_workspace",
                        principalColumn: "pk_wkspc_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_chat_workspace_tbl_employer_TblEmployerPkEmpId",
                        column: x => x.TblEmployerPkEmpId,
                        principalTable: "tbl_employer",
                        principalColumn: "pk_emp_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_chat_workspace_tbl_user_TblUserPkUserId",
                        column: x => x.TblUserPkUserId,
                        principalTable: "tbl_user",
                        principalColumn: "pk_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dispute",
                columns: table => new
                {
                    pk_dispt_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_dispt_workspace = table.Column<int>(nullable: false),
                    dispt_reason = table.Column<string>(type: "text", nullable: false),
                    dispt_status = table.Column<string>(maxLength: 50, nullable: false),
                    dispt_raise_time = table.Column<string>(maxLength: 20, nullable: false),
                    dispt_conclusion_time = table.Column<string>(maxLength: 20, nullable: true),
                    dispt_outcome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_dispute", x => x.pk_dispt_id);
                    table.ForeignKey(
                        name: "FK__tbl_dispu__fk_di__656C112C",
                        column: x => x.fk_dispt_workspace,
                        principalTable: "tbl_workspace",
                        principalColumn: "pk_wkspc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_payment_history",
                columns: table => new
                {
                    pk_pay_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_workspace_pay = table.Column<int>(nullable: false),
                    pay_description = table.Column<string>(type: "text", nullable: true),
                    pay_amount = table.Column<string>(maxLength: 20, nullable: false),
                    pay_balance = table.Column<string>(maxLength: 20, nullable: false),
                    pay_date = table.Column<string>(maxLength: 20, nullable: false),
                    pay_deductions = table.Column<string>(maxLength: 20, nullable: false),
                    final_pay = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_payment_history", x => x.pk_pay_id);
                    table.ForeignKey(
                        name: "FK__tbl_user___fk_wo__6D0D32F4",
                        column: x => x.fk_workspace_pay,
                        principalTable: "tbl_workspace",
                        principalColumn: "pk_wkspc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_payment_deduction",
                columns: table => new
                {
                    pk_pay_deduction_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_pay_deduction_history = table.Column<int>(nullable: false),
                    pay_deduction_description = table.Column<string>(type: "text", nullable: true),
                    pay_deduction_amount = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_payment_deduction", x => x.pk_pay_deduction_id);
                    table.ForeignKey(
                        name: "FK__tbl_payme__fk_pa__6A30C649",
                        column: x => x.fk_pay_deduction_history,
                        principalTable: "tbl_user_payment_history",
                        principalColumn: "pk_pay_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bid_fk_bid_user",
                table: "tbl_bid",
                column: "fk_bid_user");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bid_fk_job_bidded",
                table: "tbl_bid",
                column: "fk_job_bidded");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bid_TblUserPkUserId",
                table: "tbl_bid",
                column: "TblUserPkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_bid_fk_bid_chat_bidding",
                table: "tbl_chat_bid",
                column: "fk_bid_chat_bidding");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_bid_fk_bid_chat_user",
                table: "tbl_chat_bid",
                column: "fk_bid_chat_user");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_bid_TblSupportAdminPkSupportAdminId",
                table: "tbl_chat_bid",
                column: "TblSupportAdminPkSupportAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_bid_TblUserPkUserId",
                table: "tbl_chat_bid",
                column: "TblUserPkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_direct_fk_direct_chat_employer",
                table: "tbl_chat_direct",
                column: "fk_direct_chat_employer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_direct_TblEmployerPkEmpId",
                table: "tbl_chat_direct",
                column: "TblEmployerPkEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_direct_TblSupportAdminPkSupportAdminId",
                table: "tbl_chat_direct",
                column: "TblSupportAdminPkSupportAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_workspace_fk_wksp_chat_user",
                table: "tbl_chat_workspace",
                column: "fk_wksp_chat_user");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_workspace_fk_wksp_chat_workspace",
                table: "tbl_chat_workspace",
                column: "fk_wksp_chat_workspace");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_workspace_TblEmployerPkEmpId",
                table: "tbl_chat_workspace",
                column: "TblEmployerPkEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_chat_workspace_TblUserPkUserId",
                table: "tbl_chat_workspace",
                column: "TblUserPkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_deposit_deduction_fk_deposit_deduction_history",
                table: "tbl_deposit_deduction",
                column: "fk_deposit_deduction_history");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_dispute_fk_dispt_workspace",
                table: "tbl_dispute",
                column: "fk_dispt_workspace");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employer_company_fk_company_employer",
                table: "tbl_employer_company",
                column: "fk_company_employer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employer_company_TblEmployerPkEmpId",
                table: "tbl_employer_company",
                column: "TblEmployerPkEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employer_deposit_history_fk_deposit_employer",
                table: "tbl_employer_deposit_history",
                column: "fk_deposit_employer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employer_deposit_history_TblEmployerPkEmpId",
                table: "tbl_employer_deposit_history",
                column: "TblEmployerPkEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_job_fk_job_employer",
                table: "tbl_job",
                column: "fk_job_employer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_job_TblEmployerPkEmpId",
                table: "tbl_job",
                column: "TblEmployerPkEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_job_attachment_fk_attachment_job",
                table: "tbl_job_attachment",
                column: "fk_attachment_job");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_payment_deduction_fk_pay_deduction_history",
                table: "tbl_payment_deduction",
                column: "fk_pay_deduction_history");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_profile_fk_profile_user",
                table: "tbl_profile",
                column: "fk_profile_user");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_profile_TblUserPkUserId",
                table: "tbl_profile",
                column: "TblUserPkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_certification_fk_certification_user_id",
                table: "tbl_user_certification",
                column: "fk_certification_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_certification_TblUserPkUserId",
                table: "tbl_user_certification",
                column: "TblUserPkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_payment_history_fk_workspace_pay",
                table: "tbl_user_payment_history",
                column: "fk_workspace_pay");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_skill_fk_skill_user_id",
                table: "tbl_user_skill",
                column: "fk_skill_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_skill_TblUserPkUserId",
                table: "tbl_user_skill",
                column: "TblUserPkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_workspace_fk_wkspc_bid",
                table: "tbl_workspace",
                column: "fk_wkspc_bid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbl_chat_bid");

            migrationBuilder.DropTable(
                name: "tbl_chat_direct");

            migrationBuilder.DropTable(
                name: "tbl_chat_workspace");

            migrationBuilder.DropTable(
                name: "tbl_deposit_deduction");

            migrationBuilder.DropTable(
                name: "tbl_dispute");

            migrationBuilder.DropTable(
                name: "tbl_employer_company");

            migrationBuilder.DropTable(
                name: "tbl_job_attachment");

            migrationBuilder.DropTable(
                name: "tbl_payment_deduction");

            migrationBuilder.DropTable(
                name: "tbl_profile");

            migrationBuilder.DropTable(
                name: "tbl_user_certification");

            migrationBuilder.DropTable(
                name: "tbl_user_skill");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tbl_support_admin");

            migrationBuilder.DropTable(
                name: "tbl_employer_deposit_history");

            migrationBuilder.DropTable(
                name: "tbl_user_payment_history");

            migrationBuilder.DropTable(
                name: "tbl_workspace");

            migrationBuilder.DropTable(
                name: "tbl_bid");

            migrationBuilder.DropTable(
                name: "tbl_job");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbl_employer");
        }
    }
}
