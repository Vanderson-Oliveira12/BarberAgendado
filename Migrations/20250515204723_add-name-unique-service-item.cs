using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberAgendado.Migrations
{
    /// <inheritdoc />
    public partial class addnameuniqueserviceitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ServicesItems_Name",
                table: "ServicesItems",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServicesItems_Name",
                table: "ServicesItems");
        }
    }
}
