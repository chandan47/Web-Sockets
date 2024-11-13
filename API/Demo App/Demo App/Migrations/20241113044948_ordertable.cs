using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Demo_App.Migrations
{
    /// <inheritdoc />
    public partial class ordertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false),
                    VehicleNo = table.Column<string>(type: "text", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    ServiceAdvisorId = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    VehicleNo = table.Column<string>(type: "text", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    ServiceAdvisorId = table.Column<string>(type: "text", nullable: false),
                    OrderStatus = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
