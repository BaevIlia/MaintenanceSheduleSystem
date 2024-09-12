using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceSheduleSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderEntityFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("e9b35245-a567-4802-9fac-a4ff20d7c0c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9b35245-a567-4802-9fac-a4ff20d7c0c3"));

            migrationBuilder.AddColumn<Guid>(
                name: "MachineId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "HashedPassword", "IsSacked", "Role" },
                values: new object[] { new Guid("bd6ed98b-f839-4a0a-9069-cf5ca1dd56cd"), "test@domain.ru", "surname name lastname", "$2a$11$d0Iq16lDZtdGB4P0Vlc4g..4/VmghixmHZfT7eo/PpeosDRxe4wLy", false, 1 });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "SigningKey" },
                values: new object[] { new Guid("bd6ed98b-f839-4a0a-9069-cf5ca1dd56cd"), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("bd6ed98b-f839-4a0a-9069-cf5ca1dd56cd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd6ed98b-f839-4a0a-9069-cf5ca1dd56cd"));

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "HashedPassword", "IsSacked", "Role" },
                values: new object[] { new Guid("e9b35245-a567-4802-9fac-a4ff20d7c0c3"), "test@domain.ru", "surname name lastname", "$2a$11$eVLVS62s2vfRQF6ANM7qoutNfbA0r4pcR6BUDv5Hr5N6dZizSr4Di", false, 1 });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "SigningKey" },
                values: new object[] { new Guid("e9b35245-a567-4802-9fac-a4ff20d7c0c3"), "" });
        }
    }
}
