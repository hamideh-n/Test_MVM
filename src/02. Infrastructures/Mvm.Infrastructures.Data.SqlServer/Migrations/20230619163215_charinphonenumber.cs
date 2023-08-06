using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvm.Infrastructures.Data.SqlServer.Migrations
{
    public partial class charinphonenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                type: "datetime2",
                unicode: false,
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(48)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "Customers",
                type: "char(48)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 11);
        }
    }
}
