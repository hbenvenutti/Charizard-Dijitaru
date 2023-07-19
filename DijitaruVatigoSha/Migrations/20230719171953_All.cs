using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DijitaruVatigoSha.Migrations
{
    /// <inheritdoc />
    public partial class All : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nchar(1)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modality = table.Column<int>(type: "int", nullable: false),
                    CollaboratorRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorProject",
                columns: table => new
                {
                    CollaboratorsId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorProject", x => new { x.CollaboratorsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_CollaboratorProject_Collaborators_CollaboratorsId",
                        column: x => x.CollaboratorsId,
                        principalTable: "Collaborators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaboratorProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PendingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ApproverId = table.Column<int>(type: "int", nullable: false),
                    HourAmount = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendingHours_Collaborators_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Collaborators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PendingHours_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PendingHours_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectApprover",
                columns: table => new
                {
                    ApprovableProjectsId = table.Column<int>(type: "int", nullable: false),
                    ApproversId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectApprover", x => new { x.ApprovableProjectsId, x.ApproversId });
                    table.ForeignKey(
                        name: "FK_ProjectApprover_Collaborators_ApproversId",
                        column: x => x.ApproversId,
                        principalTable: "Collaborators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectApprover_Projects_ApprovableProjectsId",
                        column: x => x.ApprovableProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorProject_ProjectsId",
                table: "CollaboratorProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingHours_ApproverId",
                table: "PendingHours",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingHours_CollaboratorId",
                table: "PendingHours",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingHours_ProjectId",
                table: "PendingHours",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApprover_ApproversId",
                table: "ProjectApprover",
                column: "ApproversId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaboratorProject");

            migrationBuilder.DropTable(
                name: "PendingHours");

            migrationBuilder.DropTable(
                name: "ProjectApprover");

            migrationBuilder.DropTable(
                name: "Collaborators");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
