using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPIntegradorProgIII.Migrations
{
    public partial class MigracionConSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetName = table.Column<string>(type: "TEXT", nullable: false),
                    MeetDate = table.Column<string>(type: "TEXT", nullable: false),
                    MeetPlace = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false),
                    Style = table.Column<string>(type: "TEXT", nullable: false),
                    MeetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trials_Meets_MeetId",
                        column: x => x.MeetId,
                        principalTable: "Meets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantSwimmersInMeets",
                columns: table => new
                {
                    MeetsAttendedId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantSwimmersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantSwimmersInMeets", x => new { x.MeetsAttendedId, x.ParticipantSwimmersId });
                    table.ForeignKey(
                        name: "FK_ParticipantSwimmersInMeets_Meets_MeetsAttendedId",
                        column: x => x.MeetsAttendedId,
                        principalTable: "Meets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantSwimmersInMeets_Users_ParticipantSwimmersId",
                        column: x => x.ParticipantSwimmersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredSwimmersInTrials",
                columns: table => new
                {
                    RegisteredSwimmersId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrialsAttendedId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredSwimmersInTrials", x => new { x.RegisteredSwimmersId, x.TrialsAttendedId });
                    table.ForeignKey(
                        name: "FK_RegisteredSwimmersInTrials_Trials_TrialsAttendedId",
                        column: x => x.TrialsAttendedId,
                        principalTable: "Trials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredSwimmersInTrials_Users_RegisteredSwimmersId",
                        column: x => x.RegisteredSwimmersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meets",
                columns: new[] { "Id", "MeetDate", "MeetName", "MeetPlace" },
                values: new object[] { 1, "20/12/2022", "MeetPiola", "Piolalandia" });

            migrationBuilder.InsertData(
                table: "Meets",
                columns: new[] { "Id", "MeetDate", "MeetName", "MeetPlace" },
                values: new object[] { 2, "25/12/2022", "MeetPiola2", "Piolalandia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname", "UserType" },
                values: new object[] { 1, "nbologna31@gmail.com", "Nicolas", "415e36e03bf7f89e299f31b30d00af049b55795f108e4e0f659e730cc6720c3d2a073b1f222044245a662be01e1f16a7c60f77839c5df6f36e9720b98ecc4968", "Bologna", "Swimmer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname", "UserType" },
                values: new object[] { 2, "Jperez@gmail.com", "Juan", "415e36e03bf7f89e299f31b30d00af049b55795f108e4e0f659e730cc6720c3d2a073b1f222044245a662be01e1f16a7c60f77839c5df6f36e9720b98ecc4968", "Perez", "Swimmer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname", "UserType" },
                values: new object[] { 3, "pgarcia@gmail.com", "Pedro", "415e36e03bf7f89e299f31b30d00af049b55795f108e4e0f659e730cc6720c3d2a073b1f222044245a662be01e1f16a7c60f77839c5df6f36e9720b98ecc4968", "Garcia", "Swimmer" });

            migrationBuilder.InsertData(
                table: "ParticipantSwimmersInMeets",
                columns: new[] { "MeetsAttendedId", "ParticipantSwimmersId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ParticipantSwimmersInMeets",
                columns: new[] { "MeetsAttendedId", "ParticipantSwimmersId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Trials",
                columns: new[] { "Id", "Distance", "MeetId", "Style" },
                values: new object[] { 1, 100, 1, "Croll" });

            migrationBuilder.InsertData(
                table: "Trials",
                columns: new[] { "Id", "Distance", "MeetId", "Style" },
                values: new object[] { 2, 150, 2, "Croll" });

            migrationBuilder.InsertData(
                table: "RegisteredSwimmersInTrials",
                columns: new[] { "RegisteredSwimmersId", "TrialsAttendedId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "RegisteredSwimmersInTrials",
                columns: new[] { "RegisteredSwimmersId", "TrialsAttendedId" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantSwimmersInMeets_ParticipantSwimmersId",
                table: "ParticipantSwimmersInMeets",
                column: "ParticipantSwimmersId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredSwimmersInTrials_TrialsAttendedId",
                table: "RegisteredSwimmersInTrials",
                column: "TrialsAttendedId");

            migrationBuilder.CreateIndex(
                name: "IX_Trials_MeetId",
                table: "Trials",
                column: "MeetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantSwimmersInMeets");

            migrationBuilder.DropTable(
                name: "RegisteredSwimmersInTrials");

            migrationBuilder.DropTable(
                name: "Trials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Meets");
        }
    }
}
