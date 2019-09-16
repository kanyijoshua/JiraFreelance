using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jirafrelance.Migrations
{
    public partial class messages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_massages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sender_id = table.Column<string>(nullable: true),
                    reciever_id = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_massages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_tbl_massages_AspNetUsers_reciever_id",
                        column: x => x.reciever_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_mass__fk_se__6477ECF3",
                        column: x => x.sender_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_massages_reciever_id",
                table: "tbl_massages",
                column: "reciever_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_massages_sender_id",
                table: "tbl_massages",
                column: "sender_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_massages");
        }
    }
}
