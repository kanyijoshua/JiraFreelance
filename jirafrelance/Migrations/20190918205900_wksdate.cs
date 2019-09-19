using Microsoft.EntityFrameworkCore.Migrations;

namespace jirafrelance.Migrations
{
    public partial class wksdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "wkspc_start_time",
                table: "tbl_workspace",
                newName: "wkspc_starttime");

            migrationBuilder.RenameColumn(
                name: "wkspc_expectend_end_time",
                table: "tbl_workspace",
                newName: "wkspc_expectend_endtime");

            migrationBuilder.RenameColumn(
                name: "wkspc_actual_end_time",
                table: "tbl_workspace",
                newName: "wkspc_actual_endtime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "wkspc_starttime",
                table: "tbl_workspace",
                newName: "wkspc_start_time");

            migrationBuilder.RenameColumn(
                name: "wkspc_expectend_endtime",
                table: "tbl_workspace",
                newName: "wkspc_expectend_end_time");

            migrationBuilder.RenameColumn(
                name: "wkspc_actual_endtime",
                table: "tbl_workspace",
                newName: "wkspc_actual_end_time");
        }
    }
}
