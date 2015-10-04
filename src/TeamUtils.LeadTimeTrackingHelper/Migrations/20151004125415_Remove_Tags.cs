using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TeamUtils.LeadTimeTrackingHelper.Migrations
{
    public partial class Remove_Tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Tag_Activity_ActivityKey", table: "Tag");
            migrationBuilder.DropColumn(name: "ActivityKey", table: "Tag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityKey",
                table: "Tag",
                isNullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Activity_ActivityKey",
                table: "Tag",
                column: "ActivityKey",
                principalTable: "Activity",
                principalColumn: "Key");
        }
    }
}
