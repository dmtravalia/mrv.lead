using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRV.Lead.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_contact",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullname = table.Column<string>(type: "varchar(200)", nullable: false),
                    phonenumber = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    email = table.Column<string>(type: "varchar(200)", nullable: false),
                    dtinclusao = table.Column<DateTime>(name: "dt_inclusao", type: "datetime2", nullable: false),
                    dtalteracao = table.Column<DateTime>(name: "dt_alteracao", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_lead",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "varchar(200)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    suburb = table.Column<string>(type: "varchar(200)", nullable: false),
                    category = table.Column<string>(type: "varchar(200)", nullable: true),
                    status = table.Column<string>(type: "varchar(1)", nullable: false),
                    contactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dtinclusao = table.Column<DateTime>(name: "dt_inclusao", type: "datetime2", nullable: false),
                    dtalteracao = table.Column<DateTime>(name: "dt_alteracao", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_lead", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_lead_tb_contact_contactId",
                        column: x => x.contactId,
                        principalTable: "tb_contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_lead_contactId",
                table: "tb_lead",
                column: "contactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_lead");

            migrationBuilder.DropTable(
                name: "tb_contact");
        }
    }
}
