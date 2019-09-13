using Microsoft.EntityFrameworkCore.Migrations;

namespace jirafrelance.Migrations
{
    public partial class morechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "job_attachment_file_path",
                table: "tbl_job_attachment",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "job_attachment_file_name",
                table: "tbl_job_attachment",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "job_attachment_download_name",
                table: "tbl_job_attachment",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "job_attachment_file_path",
                table: "tbl_job_attachment",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "job_attachment_file_name",
                table: "tbl_job_attachment",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "job_attachment_download_name",
                table: "tbl_job_attachment",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);
        }
    }
}
