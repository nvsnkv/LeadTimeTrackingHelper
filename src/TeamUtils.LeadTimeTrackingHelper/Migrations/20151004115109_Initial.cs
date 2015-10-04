using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace TeamUtils.LeadTimeTrackingHelper.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Key = table.Column<string>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Key);
                });
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Key = table.Column<string>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Key);
                });
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Key = table.Column<string>(isNullable: false),
                    ActivityKey = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Tag_Activity_ActivityKey",
                        column: x => x.ActivityKey,
                        principalTable: "Activity",
                        principalColumn: "Key");
                });
            migrationBuilder.CreateTable(
                name: "Change",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    ActivityKey = table.Column<string>(isNullable: true),
                    FromKey = table.Column<string>(isNullable: true),
                    Timestamp = table.Column<DateTime>(isNullable: false),
                    ToKey = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Change", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Change_Activity_ActivityKey",
                        column: x => x.ActivityKey,
                        principalTable: "Activity",
                        principalColumn: "Key");
                    table.ForeignKey(
                        name: "FK_Change_State_FromKey",
                        column: x => x.FromKey,
                        principalTable: "State",
                        principalColumn: "Key");
                    table.ForeignKey(
                        name: "FK_Change_State_ToKey",
                        column: x => x.ToKey,
                        principalTable: "State",
                        principalColumn: "Key");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Change");
            migrationBuilder.DropTable("Tag");
            migrationBuilder.DropTable("State");
            migrationBuilder.DropTable("Activity");
        }
    }
}
