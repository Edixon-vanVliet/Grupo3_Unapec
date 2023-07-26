using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grupo3_Unapec.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code_Code = table.Column<string>(type: "TEXT", nullable: false),
                    Code_Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Course = table.Column<int>(type: "INTEGER", nullable: false),
                    Credits_Theoretical = table.Column<float>(type: "REAL", nullable: false),
                    Credits_Laboratory = table.Column<float>(type: "REAL", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: false),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TitleId = table.Column<int>(type: "INTEGER", nullable: false),
                    TitleConfigurationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subject_Title_TitleConfigurationId",
                        column: x => x.TitleConfigurationId,
                        principalTable: "Title",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subject_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name_FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Name_LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Office_Code = table.Column<string>(type: "TEXT", nullable: true),
                    Office_Number = table.Column<int>(type: "INTEGER", nullable: true),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquivalentSubject",
                columns: table => new
                {
                    EquivalentSubjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    Subject1Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquivalentSubject", x => new { x.EquivalentSubjectsId, x.Subject1Id });
                    table.ForeignKey(
                        name: "FK_EquivalentSubject_Subject_EquivalentSubjectsId",
                        column: x => x.EquivalentSubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquivalentSubject_Subject_Subject1Id",
                        column: x => x.Subject1Id,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncompatibleSubject",
                columns: table => new
                {
                    IncompatiblesSubjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncompatibleSubject", x => new { x.IncompatiblesSubjectsId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_IncompatibleSubject_Subject_IncompatiblesSubjectsId",
                        column: x => x.IncompatiblesSubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncompatibleSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredSubject",
                columns: table => new
                {
                    PreRequiredSubjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredForSubjectsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredSubject", x => new { x.PreRequiredSubjectsId, x.RequiredForSubjectsId });
                    table.ForeignKey(
                        name: "FK_RequiredSubject_Subject_PreRequiredSubjectsId",
                        column: x => x.PreRequiredSubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequiredSubject_Subject_RequiredForSubjectsId",
                        column: x => x.RequiredForSubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Day = table.Column<string>(type: "TEXT", nullable: false),
                    FromTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    ToTime = table.Column<TimeOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => new { x.TeacherId, x.Id });
                    table.ForeignKey(
                        name: "FK_Schedule_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeachersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_DepartmentId",
                table: "Area",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquivalentSubject_Subject1Id",
                table: "EquivalentSubject",
                column: "Subject1Id");

            migrationBuilder.CreateIndex(
                name: "IX_IncompatibleSubject_SubjectId",
                table: "IncompatibleSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredSubject_RequiredForSubjectsId",
                table: "RequiredSubject",
                column: "RequiredForSubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_AreaId",
                table: "Subject",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TitleConfigurationId",
                table: "Subject",
                column: "TitleConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TitleId",
                table: "Subject",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AreaId",
                table: "Teacher",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquivalentSubject");

            migrationBuilder.DropTable(
                name: "IncompatibleSubject");

            migrationBuilder.DropTable(
                name: "RequiredSubject");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
