using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FieldExpenseTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAddresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIBANs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeIBANs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeIBANs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePhones_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseCategoryId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    ReceiptImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    ExpenseNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ResponsedByUserId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ResponsedByUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResponseDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseCategories_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "Department", "Email", "EmployeeNumber", "FirstName", "InsertedDate", "InsertedUser", "IsActive", "IsManager", "LastName", "Position", "Salary", "UpdatedDate", "UpdatedUser" },
                values: new object[] { 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Management", "first.admin@example.com", "EMP001", "First", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", true, true, "Admin", "Manager", 75000m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "Department", "Email", "EmployeeNumber", "FirstName", "InsertedDate", "InsertedUser", "IsActive", "LastName", "Position", "Salary", "UpdatedDate", "UpdatedUser" },
                values: new object[] { 2, new DateTime(2018, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "jane.smith@example.com", "EMP002", "Jane", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", true, "Smith", "Employee", 90000m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Description", "InsertedDate", "InsertedUser", "IsActive", "Name", "UpdatedDate", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, "Expenses related to travel and transportation.", new DateTime(2025, 5, 5, 23, 32, 53, 622, DateTimeKind.Local).AddTicks(2973), "system", true, "Travel", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7736), "system" },
                    { 2, "Expenses related to meals and dining.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7754), "system", true, "Food", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7755), "system" },
                    { 3, "Expenses for office-related supplies and equipment.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7783), "system", true, "Office Supplies", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7784), "system" },
                    { 4, "Expenses for entertainment and team-building activities.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7785), "system", true, "Entertainment", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7786), "system" },
                    { 5, "Expenses for utilities such as electricity and water.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7787), "system", true, "Utilities", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7788), "system" },
                    { 6, "Other expenses that do not fit into the above categories.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7789), "system", true, "Miscellaneous", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7789), "system" },
                    { 7, "Expenses related to training and development.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7791), "system", true, "Training", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7791), "system" },
                    { 8, "Expenses related to marketing and advertising.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7792), "system", true, "Marketing", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7793), "system" },
                    { 9, "Expenses for entertaining clients or customers.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7794), "system", true, "Client Entertainment", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7795), "system" },
                    { 10, "Expenses related to health and safety measures.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7796), "system", true, "Health & Safety", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7797), "system" },
                    { 11, "Expenses for repairs and maintenance of equipment.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7798), "system", true, "Repairs & Maintenance", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7798), "system" },
                    { 12, "Expenses related to insurance premiums.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7800), "system", true, "Insurance", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7800), "system" },
                    { 13, "Expenses for shipping and delivery services.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7801), "system", true, "Shipping & Delivery", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7802), "system" },
                    { 14, "Expenses for subscriptions to services or publications.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7803), "system", true, "Subscriptions", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7804), "system" },
                    { 15, "Expenses for professional services such as consulting.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7805), "system", true, "Professional Fees", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7805), "system" },
                    { 16, "Expenses related to research and development activities.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7807), "system", true, "Research & Development", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7807), "system" },
                    { 17, "Expenses related to legal services and consultations.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7808), "system", true, "Legal", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7809), "system" },
                    { 18, "Expenses for telecommunications services.", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7810), "system", true, "Telecommunications", new DateTime(2025, 5, 5, 23, 32, 53, 623, DateTimeKind.Local).AddTicks(7811), "system" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Description", "InsertedDate", "InsertedUser", "IsActive", "Name", "UpdatedDate", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, "Credit card payment method", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", false, "Credit Card", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" },
                    { 2, "Debit card payment method", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", false, "Debit Card", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" },
                    { 3, "Cash payment method", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", false, "Cash", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" },
                    { 4, "Bank transfer payment method", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", false, "Bank Transfer", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" },
                    { 5, "Other payment method", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", false, "Other", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmployeeId", "FirstName", "InsertedDate", "InsertedUser", "IsActive", "LastLoginDate", "LastName", "OpenDate", "PasswordHash", "Role", "Secret", "UpdatedDate", "UpdatedUser", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@example.com", 1, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", true, null, "Administrator", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "76c6f58ea9461f1ba60e9b85c0ef5848", 1, "bc5b9c39e2771571a6eaf9cd2a56508cd5130bf076d414aa42111136f770cb62", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", "admin" },
                    { 2, "user1@example.com", 2, "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", true, null, "Administrator", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "791782c17b595f2a44490c5430370eb5", 2, "9c0cabb913d2a6a6451f4ffbdb900bd68426b5fef1e19f859d6d1bce35c768f9", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", "user1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_EmployeeId",
                table: "EmployeeAddresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIBANs_EmployeeId",
                table: "EmployeeIBANs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhones_EmployeeId",
                table: "EmployeePhones",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeNumber",
                table: "Employees",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeeId",
                table: "Expenses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaymentMethodId",
                table: "Expenses",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAddresses");

            migrationBuilder.DropTable(
                name: "EmployeeIBANs");

            migrationBuilder.DropTable(
                name: "EmployeePhones");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
