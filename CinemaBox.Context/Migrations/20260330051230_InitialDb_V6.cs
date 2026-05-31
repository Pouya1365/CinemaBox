using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountCollection",
                schema: "Entertainment",
                table: "Collections",
                type: "int",
                nullable: true,
                comment: "تعداد فیلم های کالکشن موجود");

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                schema: "Entertainment",
                table: "Collections",
                type: "int",
                nullable: true,
                comment: "تعداد کل فیلم های کالکشن");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountCollection",
                schema: "Entertainment",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                schema: "Entertainment",
                table: "Collections");
        }
    }
}
