using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceSheduleSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexForUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("bd6ed98b-f839-4a0a-9069-cf5ca1dd56cd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd6ed98b-f839-4a0a-9069-cf5ca1dd56cd"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "HashedPassword", "IsSacked", "Role" },
                values: new object[] { new Guid("dac5f915-53bb-4056-bde6-f4987056c1e7"), "test@domain.ru", "surname name lastname", "$2a$11$rFu15a3nlKXtN1uRT08pNeskp0DTOiX5RKAwVMlxF/fvXHOffrQqi", false, 1 });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "SigningKey" },
                values: new object[] { new Guid("dac5f915-53bb-4056-bde6-f4987056c1e7"), "" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_HashedPassword",
                table: "Users",
                columns: new[] { "Email", "HashedPassword" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email_HashedPassword",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("dac5f915-53bb-4056-bde6-f4987056c1e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dac5f915-53bb-4056-bde6-f4987056c1e7"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "HashedPassword", "IsSacked", "Role" },
                values: new object[] { new Guid("bd6ed98b-f839-4a0a-9069-cf5ca1dd56cd"), "test@domain.ru", "surname name lastname", "$2a$11$d0Iq16lDZtdGB4P0Vlc4g..4/VmghixmHZfT7eo/PpeosDRxe4wLy", false, 1 });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "SigningKey" },
                values: new object[] { new Guid("bd6ed98b-f839-4a0a-9069-cf5ca1dd56cd"), "" });
        }
    }
}
