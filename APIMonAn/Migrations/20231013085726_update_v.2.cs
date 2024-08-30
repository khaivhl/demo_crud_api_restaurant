using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMonAn.Migrations
{
    /// <inheritdoc />
    public partial class update_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CongThuc_MonAn_MonAnId",
                table: "CongThuc");

            migrationBuilder.AlterColumn<int>(
                name: "MonAnId",
                table: "CongThuc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CongThuc_MonAn_MonAnId",
                table: "CongThuc",
                column: "MonAnId",
                principalTable: "MonAn",
                principalColumn: "MonAnId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CongThuc_MonAn_MonAnId",
                table: "CongThuc");

            migrationBuilder.AlterColumn<int>(
                name: "MonAnId",
                table: "CongThuc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CongThuc_MonAn_MonAnId",
                table: "CongThuc",
                column: "MonAnId",
                principalTable: "MonAn",
                principalColumn: "MonAnId");
        }
    }
}
