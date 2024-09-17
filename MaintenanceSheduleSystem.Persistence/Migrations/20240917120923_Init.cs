using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaintenanceSheduleSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Article = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StoragePlace = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    IsInStock = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    IsSacked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaName = table.Column<string>(type: "text", nullable: false),
                    AreaDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAreas_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SigningKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannerEngineers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannerEngineers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannerEngineers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicemen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicemen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicemen_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeOfWork = table.Column<int>(type: "integer", nullable: false),
                    Instructions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructions_MachineAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "MachineAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PlannerEngineerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServicemanId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BeginWorkDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeadlineDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CompliteDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TypeOfWork = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_MachineAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "MachineAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PlannerEngineers_PlannerEngineerId",
                        column: x => x.PlannerEngineerId,
                        principalTable: "PlannerEngineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Servicemen_ServicemanId",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructionEquipment",
                columns: table => new
                {
                    InstructionId = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionEquipment", x => new { x.InstructionId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_InstructionEquipment_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructionEquipment_Instructions_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "Instructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderEquipment",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEquipment", x => new { x.OrderId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_OrderEquipment_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEquipment_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Article", "Count", "IsInStock", "Name", "StoragePlace", "Type" },
                values: new object[,]
                {
                    { new Guid("1a1db12d-0106-4d06-afc9-8cea47ff876e"), "3421", 2, true, "TestInstrument", "A2", 1 },
                    { new Guid("f84c16d1-5373-46b1-8340-db980e94bf32"), "12345", 10, true, "TestSpare", "A1", 2 }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Name", "SerialNumber" },
                values: new object[] { new Guid("baf57b0d-d6dd-481e-8b7b-ba03f57dab9c"), "TestLine", "123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "HashedPassword", "IsSacked", "Role" },
                values: new object[,]
                {
                    { new Guid("5ac264b6-7490-48b2-93ca-63204fb0bc7b"), "test@domain.ru", "surname name lastname", "$2a$11$x8bWa043.gamnoLShZzhd.5pnkgFjao7KLpXN7Vg5nJQW1O6XGiiu", false, 1 },
                    { new Guid("69fc24dd-44ed-460e-b183-36da93374664"), "testService@domain.ru", "Test Test Serviceman", "$2a$11$LiU42UKhNy4rPTDCHpBVwOAG61HbRNlyQMGGR2iuPE3wyW.YqRMw.", false, 3 },
                    { new Guid("a69b942d-6024-4cb9-99ab-fdb813dda151"), "testPlanner@domain.ru", "Test, Test, Planner", "$2a$11$G9kLyGRTrQDdyU0l92d80uU/J2shCzQzaFxZjMLbdAQumJUhbk.8C", false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "SigningKey" },
                values: new object[] { new Guid("5ac264b6-7490-48b2-93ca-63204fb0bc7b"), "" });

            migrationBuilder.InsertData(
                table: "MachineAreas",
                columns: new[] { "Id", "AreaDescription", "AreaName", "MachineId" },
                values: new object[] { new Guid("f6cd323f-9c21-4dc6-8533-493a89d6459a"), "TestDesc", "TestArea", new Guid("baf57b0d-d6dd-481e-8b7b-ba03f57dab9c") });

            migrationBuilder.InsertData(
                table: "PlannerEngineers",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("a69b942d-6024-4cb9-99ab-fdb813dda151"), "TestTitle" });

            migrationBuilder.InsertData(
                table: "Servicemen",
                column: "Id",
                value: new Guid("69fc24dd-44ed-460e-b183-36da93374664"));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AreaId", "BeginWorkDateTime", "CompliteDateTime", "CreatedDateTime", "DeadlineDateTime", "Description", "MachineId", "Name", "PlannerEngineerId", "ServicemanId", "TypeOfWork" },
                values: new object[] { new Guid("12055903-390d-42e7-b98f-16dfe77f053e"), new Guid("f6cd323f-9c21-4dc6-8533-493a89d6459a"), null, null, new DateTime(2024, 9, 17, 12, 9, 22, 657, DateTimeKind.Utc).AddTicks(949), null, "TestOrderDesc", new Guid("baf57b0d-d6dd-481e-8b7b-ba03f57dab9c"), "TestOrder", new Guid("a69b942d-6024-4cb9-99ab-fdb813dda151"), new Guid("69fc24dd-44ed-460e-b183-36da93374664"), 1 });

            migrationBuilder.InsertData(
                table: "OrderEquipment",
                columns: new[] { "EquipmentId", "OrderId", "EquipmentCount" },
                values: new object[,]
                {
                    { new Guid("1a1db12d-0106-4d06-afc9-8cea47ff876e"), new Guid("12055903-390d-42e7-b98f-16dfe77f053e"), 1 },
                    { new Guid("f84c16d1-5373-46b1-8340-db980e94bf32"), new Guid("12055903-390d-42e7-b98f-16dfe77f053e"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructionEquipment_EquipmentId",
                table: "InstructionEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_AreaId",
                table: "Instructions",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreas_MachineId",
                table: "MachineAreas",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEquipment_EquipmentId",
                table: "OrderEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AreaId",
                table: "Orders",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlannerEngineerId",
                table: "Orders",
                column: "PlannerEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServicemanId",
                table: "Orders",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "InstructionEquipment");

            migrationBuilder.DropTable(
                name: "OrderEquipment");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "MachineAreas");

            migrationBuilder.DropTable(
                name: "PlannerEngineers");

            migrationBuilder.DropTable(
                name: "Servicemen");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
