using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace propertyProject.Migrations
{
    /// <inheritdoc />
    public partial class servicesIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "Icon",
                value: "bi-wifi");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "Icon",
                value: "bi-lightning");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "Icon",
                value: "bi-droplet-half");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "Icon",
                value: "fa-solid fa-elevator");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "Icon",
                value: "bi bi-fan");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "Icon",
                value: "bi bi-tv");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "Icon",
                value: "fa-solid fa-faucet");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "Icon",
                value: "fa-regular fa-washing-machine");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "Icon",
                value: "fa-solid fa-person-military-pointing");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "Icon",
                value: "fa fa-fire-extinguisher");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "Icon",
                value: "bi bi-trash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Service");
        }
    }
}
