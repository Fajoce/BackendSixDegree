using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SD");

            migrationBuilder.CreateTable(
                name: "TypeOfusers",
                schema: "SD",
                columns: table => new
                {
                    TypeOfUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfUserName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TypeOfUserDescription = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfusers", x => x.TypeOfUserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "SD",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserLastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TypeOfUserId = table.Column<int>(nullable: false),
                    UserAdress = table.Column<string>(maxLength: 50, nullable: false),
                    UserTelephone = table.Column<string>(maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_TypeOfUserId",
                        column: x => x.TypeOfUserId,
                        principalSchema: "SD",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeOfUserId",
                schema: "SD",
                table: "Users",
                column: "TypeOfUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeOfusers",
                schema: "SD");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "SD");
        }
    }
}
