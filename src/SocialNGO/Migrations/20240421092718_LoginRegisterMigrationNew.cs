using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNGO.Migrations
{
    /// <inheritdoc />
    public partial class LoginRegisterMigrationNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "UserLogin",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "UserLogin");
        }
    }
}
