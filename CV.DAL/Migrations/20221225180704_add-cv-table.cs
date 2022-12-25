using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addcvtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    ExpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CV_PersonalInfo_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CV_experiances_ExpId",
                        column: x => x.ExpId,
                        principalTable: "experiances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CV_ExpId",
                table: "CV",
                column: "ExpId");

            migrationBuilder.CreateIndex(
                name: "IX_CV_PersonalId",
                table: "CV",
                column: "PersonalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CV");
        }
    }
}
