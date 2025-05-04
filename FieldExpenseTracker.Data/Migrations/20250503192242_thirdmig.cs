using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FieldExpenseTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class thirdmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "Department", "Email", "EmployeeNumber", "FirstName", "InsertedDate", "InsertedUser", "IsActive", "IsManager", "LastName", "Position", "Salary", "UpdatedDate", "UpdatedUser" },
                values: new object[] { 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Management", "first.admin@example.com", "EMP001", "First", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(2902), "system", true, true, "Admin", "Manager", 75000m, new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(2913), "system" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "Department", "Email", "EmployeeNumber", "FirstName", "InsertedDate", "InsertedUser", "IsActive", "LastName", "Position", "Salary", "UpdatedDate", "UpdatedUser" },
                values: new object[] { 2, new DateTime(2018, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "jane.smith@example.com", "EMP002", "Jane", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(2920), "system", true, "Smith", "Employee", 90000m, new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(2921), "system" });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Description", "InsertedDate", "InsertedUser", "IsActive", "Name", "UpdatedDate", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, "Expenses related to travel and transportation.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3069), "system", true, "Travel", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3070), "system" },
                    { 2, "Expenses related to meals and dining.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3072), "system", true, "Food", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3073), "system" },
                    { 3, "Expenses for office-related supplies and equipment.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3075), "system", true, "Office Supplies", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3075), "system" },
                    { 4, "Expenses for entertainment and team-building activities.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3129), "system", true, "Entertainment", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3130), "system" },
                    { 5, "Expenses for utilities such as electricity and water.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3132), "system", true, "Utilities", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3132), "system" },
                    { 6, "Other expenses that do not fit into the above categories.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3134), "system", true, "Miscellaneous", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3134), "system" },
                    { 7, "Expenses related to training and development.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3137), "system", true, "Training", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3138), "system" },
                    { 8, "Expenses related to marketing and advertising.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3140), "system", true, "Marketing", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3140), "system" },
                    { 9, "Expenses for entertaining clients or customers.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3142), "system", true, "Client Entertainment", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3143), "system" },
                    { 10, "Expenses related to health and safety measures.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3145), "system", true, "Health & Safety", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3145), "system" },
                    { 11, "Expenses for repairs and maintenance of equipment.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3147), "system", true, "Repairs & Maintenance", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3147), "system" },
                    { 12, "Expenses related to insurance premiums.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3149), "system", true, "Insurance", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3149), "system" },
                    { 13, "Expenses for shipping and delivery services.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3150), "system", true, "Shipping & Delivery", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3151), "system" },
                    { 14, "Expenses for subscriptions to services or publications.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3152), "system", true, "Subscriptions", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3153), "system" },
                    { 15, "Expenses for professional services such as consulting.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3154), "system", true, "Professional Fees", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3155), "system" },
                    { 16, "Expenses related to research and development activities.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3156), "system", true, "Research & Development", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3157), "system" },
                    { 17, "Expenses related to legal services and consultations.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3158), "system", true, "Legal", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3159), "system" },
                    { 18, "Expenses for telecommunications services.", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3160), "system", true, "Telecommunications", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3161), "system" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmployeeId", "FirstName", "InsertedDate", "InsertedUser", "IsActive", "LastLoginDate", "LastName", "OpenDate", "PasswordHash", "Role", "Secret", "UpdatedDate", "UpdatedUser", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "System", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3204), "system", true, null, "Administrator", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3202), "76c6f58ea9461f1ba60e9b85c0ef5848", 1, "bc5b9c39e2771571a6eaf9cd2a56508cd5130bf076d414aa42111136f770cb62", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3204), "system", "admin" },
                    { 2, 2, "System", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3208), "system", true, null, "Administrator", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3207), "791782c17b595f2a44490c5430370eb5", 1, "9c0cabb913d2a6a6451f4ffbdb900bd68426b5fef1e19f859d6d1bce35c768f9", new DateTime(2025, 5, 3, 22, 22, 41, 697, DateTimeKind.Local).AddTicks(3208), "system", "user1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
