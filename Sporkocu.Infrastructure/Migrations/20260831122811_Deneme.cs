using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sporkocu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    VideoLinkPath = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Calorie = table.Column<string>(type: "TEXT", nullable: false),
                    Protein = table.Column<string>(type: "TEXT", nullable: false),
                    Carbonhydrate = table.Column<string>(type: "TEXT", nullable: false),
                    Oil = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleLesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartHour = table.Column<string>(type: "TEXT", nullable: false),
                    EndHour = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLesson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PremiumPackage = table.Column<int>(type: "INTEGER", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    ProfilePicPath = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    SubTitle = table.Column<string>(type: "TEXT", nullable: false),
                    HtmlContent = table.Column<string>(type: "TEXT", nullable: false),
                    CoverImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCoach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCoach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCoach_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionPlanDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NutritionPlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Meal = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionPlanDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionPlanDetail_NutritionPlan_NutritionPlanId",
                        column: x => x.NutritionPlanId,
                        principalTable: "NutritionPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Step = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Right",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Right", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Right_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Right_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Status", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3124), "Fitness ve egzersiz içerikleri", 0, "Fitness", null, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImagePath", "Status", "Title", "UpdatedBy", "UpdatedDate", "VideoLinkPath" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3385), "Haftada en fazla 3 gün yapılması önerilir", "benchpress.png", 0, "BenchPress", null, null, null });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Calorie", "Carbonhydrate", "CreatedBy", "CreatedDate", "Description", "Image", "Oil", "Protein", "Status", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "320 kalori", "30 gram", 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3310), "Zengin içerikli kahvaltı.", "avokado-tost.png", "35 gram", "14 gram", 0, "Avokadolu Yumurtalı Kızarmış Ekmek", null, null });

            migrationBuilder.InsertData(
                table: "NutritionPlan",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "EndDate", "StartDate", "Status", "Title", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3872), "1 ayda 3-4 kilo verdirecek o liste.", new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3871), new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3870), 0, "Diyet Listesi", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Status", "Title", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3682), "Boyum 174 cm kilom da 65, yeni başlayan biri olarak günde kaç set benchpress yapmalıyım?", 0, "1 günde kaç set benchpress yapılmalı?", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Status", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3010), "Admin", 0, "ADMIN", null, null });

            migrationBuilder.InsertData(
                table: "ScheduleLesson",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EndHour", "Note", "StartHour", "StartTime", "Status", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(4133), "11.00", null, "09.00", new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(4129), 1, null, null, "1" });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Icon", "Status", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3210), "Kilo vermek için tüyolar", "kilo-verme.png", 1, "Kilo Verme", null, null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "Email", "FullName", "Password", "Phone", "PremiumPackage", "ProfilePicPath", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "", 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(2444), "admin@admin.com", "Yasemin İnce", "123123", "", 1, "", 0, null, null });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "QuestionId", "Status", "Step", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(4050), "Günde 10 set ile başlamanız idealdir. Her haftada 5er set şeklinde çıkarın", 1, 0, 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "Id", "CategoryId", "CoverImagePath", "CreatedBy", "CreatedDate", "HtmlContent", "Status", "SubTitle", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, "blog1.jpg", 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3557), "<p>Düzenli antrenman ve doğru beslenme kas gelişiminin temelidir.</p>", 0, "Yeni Başlayanlar İçin Rehber", "Kas Gelişimi İçin Temel Kurallar", null, null });

            migrationBuilder.InsertData(
                table: "NutritionPlanDetail",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FoodId", "Meal", "NutritionPlanId", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3961), 1, "Kahvaltı", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "StudentCoach",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Description", "Status", "Title", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, 1, new DateTime(2026, 8, 31, 15, 28, 11, 469, DateTimeKind.Local).AddTicks(3473), "Kilo verme yolculuğunda yardımcı olacak hocalarımız mevcuttur.", 1, "Kilo Verme Koçluğu ", null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserId",
                table: "Answer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_CategoryId",
                table: "Blog",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPlanDetail_NutritionPlanId",
                table: "NutritionPlanDetail",
                column: "NutritionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Right_RoleId",
                table: "Right",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Right_UserId",
                table: "Right",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Title",
                table: "Role",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCoach_CategoryId",
                table: "StudentCoach",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "NutritionPlanDetail");

            migrationBuilder.DropTable(
                name: "Right");

            migrationBuilder.DropTable(
                name: "ScheduleLesson");

            migrationBuilder.DropTable(
                name: "StudentCoach");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "NutritionPlan");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
