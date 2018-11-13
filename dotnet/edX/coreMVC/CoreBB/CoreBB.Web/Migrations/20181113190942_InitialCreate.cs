using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBB.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    IsAdministrator = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    RegisterDateTime = table.Column<DateTime>(nullable: false),
                    LastLogInDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Forum_Owner",
                        column: x => x.OwnerID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromUserID = table.Column<int>(nullable: false),
                    ToUserID = table.Column<int>(nullable: false),
                    SendDateTime = table.Column<DateTime>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Message_FromUser",
                        column: x => x.FromUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_ToUser",
                        column: x => x.ToUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerID = table.Column<int>(nullable: false),
                    ForumID = table.Column<int>(nullable: false),
                    RootTopicID = table.Column<int>(nullable: true),
                    ReplyToTopicID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    PostDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedByUserID = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Topic_Forum",
                        column: x => x.ForumID,
                        principalTable: "Forum",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Topic_ModifiedByUser",
                        column: x => x.ModifiedByUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topic_Owner",
                        column: x => x.OwnerID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topic_ReplyToTopic",
                        column: x => x.ReplyToTopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topic_RootTopic",
                        column: x => x.RootTopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forum_OwnerID",
                table: "Forum",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FromUserID",
                table: "Message",
                column: "FromUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ToUserID",
                table: "Message",
                column: "ToUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ForumID",
                table: "Topic",
                column: "ForumID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ModifiedByUserID",
                table: "Topic",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_OwnerID",
                table: "Topic",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ReplyToTopicID",
                table: "Topic",
                column: "ReplyToTopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_RootTopicID",
                table: "Topic",
                column: "RootTopicID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
