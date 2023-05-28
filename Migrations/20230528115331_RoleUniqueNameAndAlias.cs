using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace feedApi.Migrations
{
    /// <inheritdoc />
    public partial class RoleUniqueNameAndAlias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Role_Alias",
                table: "Role",
                column: "Alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Role_Alias",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_Name",
                table: "Role");
        }
    }
}
