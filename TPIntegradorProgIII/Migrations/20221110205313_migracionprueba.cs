using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPIntegradorProgIII.Migrations
{
    public partial class migracionprueba : Migration
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
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
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
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password", "Surname", "UserName" },
                values: new object[] { 1, "Swimmer", "nbologna31@gmail.com", "Nicolas", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Bologna", "NicoBo" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password", "Surname", "UserName" },
                values: new object[] { 2, "Swimmer", "Jperez@gmail.com", "Juan", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Perez", "JuanPe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password", "Surname", "UserName" },
                values: new object[] { 3, "Swimmer", "pgarcia@gmail.com", "Pedro", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Garcia", "PeGarcía" });

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
