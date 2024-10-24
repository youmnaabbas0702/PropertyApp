using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace propertyProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyServiceManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Property_PropertyId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_PropertyId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Service");

            migrationBuilder.CreateTable(
                name: "PropertyServices",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyServices", x => new { x.PropertyId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_PropertyServices_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyServices_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Wi-Fi" },
                    { 2, "Electricity" },
                    { 3, "Gas" },
                    { 4, "Elevator" },
                    { 5, "Fans" },
                    { 6, "TV" },
                    { 7, "Water Filter" },
                    { 8, "Cleaning Services" },
                    { 9, "Security" },
                    { 10, "Fire Safety" },
                    { 11, "Garbage Disposal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyServices_ServiceId",
                table: "PropertyServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyServices");

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Service_PropertyId",
                table: "Service",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Property_PropertyId",
                table: "Service",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
