using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionPolizas.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentificationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdentificationType = table.Column<int>(nullable: false),
                    IdentificationNumber = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_IdentificationType_IdentificationType",
                        column: x => x.IdentificationType,
                        principalTable: "IdentificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PolicyTypeId = table.Column<int>(nullable: false),
                    Coverage = table.Column<double>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    RiskTypeId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_PolicyType_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "PolicyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_RiskType_RiskTypeId",
                        column: x => x.RiskTypeId,
                        principalTable: "RiskType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPolicy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PolicyId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    BeginningValidity = table.Column<DateTimeOffset>(nullable: false),
                    CancellationDate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPolicy_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPolicy_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdentificationType",
                table: "Customer",
                column: "IdentificationType");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicy_CustomerId",
                table: "CustomerPolicy",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicy_PolicyId",
                table: "CustomerPolicy",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PolicyTypeId",
                table: "Policy",
                column: "PolicyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_RiskTypeId",
                table: "Policy",
                column: "RiskTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPolicy");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "IdentificationType");

            migrationBuilder.DropTable(
                name: "PolicyType");

            migrationBuilder.DropTable(
                name: "RiskType");
        }
    }
}
