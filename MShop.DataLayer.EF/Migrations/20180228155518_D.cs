using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.EF.Migrations
{
    public partial class D : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnsweredUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PollId = table.Column<Guid>(nullable: false),
                    PollOptionId = table.Column<Guid>(nullable: false),
                    UserIpAdress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnsweredUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnsweredUsers");
        }
    }
}
