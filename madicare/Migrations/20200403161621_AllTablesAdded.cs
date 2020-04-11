using Microsoft.EntityFrameworkCore.Migrations;

namespace madicare.Migrations
{
    public partial class AllTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    aid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aname = table.Column<string>(nullable: false),
                    aphone = table.Column<string>(nullable: false),
                    aaddress = table.Column<string>(nullable: false),
                    agender = table.Column<string>(nullable: false),
                    aemail = table.Column<string>(nullable: false),
                    apassword = table.Column<string>(nullable: false),
                    adate_of_brith = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.aid);
                });

            migrationBuilder.CreateTable(
                name: "admin_medi_care",
                columns: table => new
                {
                    aid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aname = table.Column<string>(nullable: false),
                    aphone = table.Column<string>(nullable: false),
                    aaddress = table.Column<string>(nullable: false),
                    agender = table.Column<string>(nullable: false),
                    aemail = table.Column<string>(nullable: false),
                    apassword = table.Column<string>(nullable: false),
                    adate_of_brith = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_medi_care", x => x.aid);
                });

            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(nullable: false),
                    Medicineinfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    mid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mname = table.Column<string>(nullable: true),
                    minfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.mid);
                });

            migrationBuilder.CreateTable(
                name: "VillageDetails",
                columns: table => new
                {
                    VillageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageName = table.Column<string>(nullable: false),
                    District = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillageDetails", x => x.VillageId);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pname = table.Column<string>(nullable: false),
                    pphone = table.Column<string>(nullable: false),
                    paddress = table.Column<string>(nullable: false),
                    pgender = table.Column<string>(nullable: false),
                    pweight = table.Column<string>(nullable: false),
                    phight = table.Column<string>(nullable: false),
                    pbmi = table.Column<string>(nullable: true),
                    pbmr = table.Column<string>(nullable: true),
                    pbp = table.Column<string>(nullable: true),
                    pdate_of_brith = table.Column<string>(nullable: false),
                    ppassword = table.Column<string>(nullable: false),
                    pdisease = table.Column<string>(nullable: true),
                    pdiseaseSlove = table.Column<string>(nullable: true),
                    mid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.pid);
                    table.ForeignKey(
                        name: "FK_patient_tests_mid",
                        column: x => x.mid,
                        principalTable: "tests",
                        principalColumn: "mid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    did = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dname = table.Column<string>(nullable: false),
                    dphone = table.Column<string>(nullable: false),
                    daddress = table.Column<string>(nullable: false),
                    dgender = table.Column<string>(nullable: false),
                    demail = table.Column<string>(nullable: false),
                    dpassword = table.Column<string>(nullable: false),
                    ddate_of_brith = table.Column<string>(nullable: false),
                    dqualification = table.Column<string>(nullable: false),
                    VillageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.did);
                    table.ForeignKey(
                        name: "FK_doctors_VillageDetails_VillageId",
                        column: x => x.VillageId,
                        principalTable: "VillageDetails",
                        principalColumn: "VillageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctors_VillageId",
                table: "doctors",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_mid",
                table: "patient",
                column: "mid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "admin_medi_care");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "VillageDetails");

            migrationBuilder.DropTable(
                name: "tests");
        }
    }
}
