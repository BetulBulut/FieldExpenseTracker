using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FieldExpenseTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class fourthmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResponsedByUserName",
                table: "Expenses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "ResponsedByUserId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "Expenses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseDescription",
                table: "Expenses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(3898), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(3909) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(3915), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(3915) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4091), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4094), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4095) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4096), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4098), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4100), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4102), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4103) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4106), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4106) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4107), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4108) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4109), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4111), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4112) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4113), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4115), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4116), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4118), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4119) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4120), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4122), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4124), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4126), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertedDate", "OpenDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4163), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4162), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertedDate", "OpenDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4167), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4166), new DateTime(2025, 5, 4, 12, 10, 53, 955, DateTimeKind.Local).AddTicks(4168) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ResponseDescription",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsedByUserName",
                table: "Expenses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResponsedByUserId",
                table: "Expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(2902), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(2913) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(2920), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3069), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3072), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3073) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3075), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3075) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3129), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3132), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3132) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3134), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3134) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3137), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3138) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3140), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3142), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3143) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3145), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3147), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3147) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3149), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3149) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3150), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3152), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3153) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3154), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3155) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3156), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3157) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3158), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3159) });

            migrationBuilder.UpdateData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "InsertedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3160), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3161) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertedDate", "OpenDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3204), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3202), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3204) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertedDate", "OpenDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3208), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3207), new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3208) });
        }
    }
}
