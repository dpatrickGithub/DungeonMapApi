using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DungeonMap_Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    GameType = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    PreferredCharacterName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Biography = table.Column<string>(nullable: true),
                    SkypeHandle = table.Column<string>(nullable: true),
                    SubscriptionType = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserSettings_Id",
                        column: x => x.Id,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    RoleType = table.Column<short>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CharacterName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => new { x.FriendId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "GameType", "Name", "UpdatedBy" },
                values: new object[] { 1, 1, new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3416), (short)0, "Out Of The Abyss", 1 });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "Biography", "CreatedBy", "CreatedDate", "PhoneNumber", "PreferredCharacterName", "SkypeHandle", "SubscriptionType", "UpdatedBy" },
                values: new object[] { 1, "I silence things", 1, new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(7523), "5554443210", "Letherna: The Silencer", "critical.bailure", (short)1, 1 });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "Biography", "CreatedBy", "CreatedDate", "PhoneNumber", "PreferredCharacterName", "SkypeHandle", "SubscriptionType", "UpdatedBy" },
                values: new object[] { 2, "Malevolent Dungeonmaster", 1, new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9544), "5554441234", "God", "dustin.patrick", (short)1, 1 });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "Biography", "CreatedBy", "CreatedDate", "PhoneNumber", "PreferredCharacterName", "SkypeHandle", "SubscriptionType", "UpdatedBy" },
                values: new object[] { 3, "New to the game. Also you just lost the game", 1, new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9578), "5554443210", "Lia", "jk_its_kj", (short)1, 1 });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "Biography", "CreatedBy", "CreatedDate", "PhoneNumber", "PreferredCharacterName", "SkypeHandle", "SubscriptionType", "UpdatedBy" },
                values: new object[] { 4, "I'm just here so I don't get fined", 1, new DateTime(2019, 1, 11, 18, 24, 34, 927, DateTimeKind.Utc).AddTicks(9580), "5554443210", "Dreyfus", "something_creative", (short)0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "Salt", "UpdatedBy", "UserName" },
                values: new object[] { 1, 1, new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(112), "fakeEmailNumber1@gmail.com", "Bailey", "Stoddard", "change", null, 1, "critical.bailure" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "Salt", "UpdatedBy", "UserName" },
                values: new object[] { 2, 1, new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3044), "dustin.patrick@fakeEmail.io", "Dustin", "Patrick", "change", null, 1, "dpatrick" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "Salt", "UpdatedBy", "UserName" },
                values: new object[] { 3, 1, new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3071), "something@gmail.com", "Kaylin", "Jones", "change", null, 1, "xXxLiaxXx" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "Salt", "UpdatedBy", "UserName" },
                values: new object[] { 4, 1, new DateTime(2019, 1, 11, 18, 24, 34, 912, DateTimeKind.Utc).AddTicks(3072), "something_else@gmail.com", "Russell", "Patrick", "change", null, 1, "_dreyfus" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "CharacterName", "CreatedBy", "CreatedDate", "GameId", "RoleType", "UpdatedBy", "UserId" },
                values: new object[] { 1, "Letherna", 1, new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(4031), 1, (short)1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "CharacterName", "CreatedBy", "CreatedDate", "GameId", "RoleType", "UpdatedBy", "UserId" },
                values: new object[] { 2, "Lia", 1, new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5815), 1, (short)1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "CharacterName", "CreatedBy", "CreatedDate", "GameId", "RoleType", "UpdatedBy", "UserId" },
                values: new object[] { 3, "Dungeon Master", 1, new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5829), 1, (short)1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "CharacterName", "CreatedBy", "CreatedDate", "GameId", "RoleType", "UpdatedBy", "UserId" },
                values: new object[] { 4, "Dreyfus", 1, new DateTime(2019, 1, 11, 18, 24, 34, 930, DateTimeKind.Utc).AddTicks(5831), 1, (short)1, 1, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameId",
                table: "Characters",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_UserId",
                table: "UserFriends",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSettings");
        }
    }
}
