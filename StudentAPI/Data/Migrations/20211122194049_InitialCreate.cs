using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "City", "Email", "Employer", "FirstName", "LastName", "MobileNumber", "Province", "Specialization" },
                values: new object[] { "64a40c33-a4c3-443b-9744-3c738d53ef14", "London", "tom@gmail.com", "Google", "Tom", "Day", "1234567890", "Ontario", "Science" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "City", "Email", "Employer", "FirstName", "LastName", "MobileNumber", "Province", "Specialization" },
                values: new object[] { "fcf18638-e817-4192-ba0e-aae646088a09", "Vancouver", "john@gmail.com", "Apple", "John", "Doe", "1234567890", "British Columbia", "Engineering" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "City", "Email", "Employer", "FirstName", "LastName", "MobileNumber", "Province", "Specialization" },
                values: new object[] { "045538b7-5763-4c6e-81ec-fbe270801c65", "Toronto", "jane@gmail.com", "Microsoft", "Jane", "Doe", "1234567890", "Ontario", "Engineering" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
