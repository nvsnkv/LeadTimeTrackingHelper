using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TeamUtils.LeadTimeTrackingHelper.Migrations
{
    public partial class Remove_Tags_From_Solution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Tag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Key = table.Column<string>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Key);
                });
        }
    }
}
