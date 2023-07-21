using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospital.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEspecialidad",
                columns: table => new
                {
                    pkEspecialidadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoEspecialidad = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEspecialidad", x => x.pkEspecialidadID);
                });

            migrationBuilder.CreateTable(
                name: "tblMedicamento",
                columns: table => new
                {
                    pkMedicamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoMedicamento = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    Marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedicamento", x => x.pkMedicamentoID);
                });

            migrationBuilder.CreateTable(
                name: "tblPaciente",
                columns: table => new
                {
                    pkPacienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    ApellidoPaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    ApellidoMaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, collation: "Traditional_Spanish_CI_AS"),
                    Domicillio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, collation: "Traditional_Spanish_CI_AS"),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedicos", x => x.pkPacienteID);
                });

            migrationBuilder.CreateTable(
                name: "tblTipoDosis",
                columns: table => new
                {
                    pkTipoDosisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTipoDosis", x => x.pkTipoDosisID);
                });

            migrationBuilder.CreateTable(
                name: "tblTipoLapso",
                columns: table => new
                {
                    pkTipoLapsoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTipoLapso", x => x.pkTipoLapsoID);
                });

            migrationBuilder.CreateTable(
                name: "tblMedico",
                columns: table => new
                {
                    pkMedicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    ApellidoPaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    ApellidoMaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, collation: "Traditional_Spanish_CI_AS"),
                    CedulaProfesional = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false, collation: "Traditional_Spanish_CI_AS"),
                    fkEspecialidadID = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedico", x => x.pkMedicoID);
                    table.ForeignKey(
                        name: "FK_tblMedico_tblEspecialidad",
                        column: x => x.fkEspecialidadID,
                        principalTable: "tblEspecialidad",
                        principalColumn: "pkEspecialidadID");
                });

            migrationBuilder.CreateTable(
                name: "tblHistorialClinico",
                columns: table => new
                {
                    pkHitorialClinicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtFechaConsulta = table.Column<DateTime>(type: "datetime", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: true),
                    Estatura = table.Column<double>(type: "float", nullable: true),
                    TemperaturaCorporal = table.Column<double>(type: "float", nullable: true),
                    Sitomas = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true, collation: "Traditional_Spanish_CI_AS"),
                    Observaciones = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true, collation: "Traditional_Spanish_CI_AS"),
                    Diagnostico = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, collation: "Traditional_Spanish_CI_AS"),
                    fkPacienteID = table.Column<int>(type: "int", nullable: false),
                    fkMedicoID = table.Column<int>(type: "int", nullable: false),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHistorialClinico", x => x.pkHitorialClinicoID);
                    table.ForeignKey(
                        name: "FK_tblHistorialClinico_tblMedico",
                        column: x => x.fkMedicoID,
                        principalTable: "tblMedico",
                        principalColumn: "pkMedicoID");
                    table.ForeignKey(
                        name: "FK_tblHistorialClinico_tblPaciente",
                        column: x => x.fkPacienteID,
                        principalTable: "tblPaciente",
                        principalColumn: "pkPacienteID");
                });

            migrationBuilder.CreateTable(
                name: "tblReceta",
                columns: table => new
                {
                    pkRecetaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkHistorialClinicoID = table.Column<int>(type: "int", nullable: false),
                    fkMedicamentoID = table.Column<int>(type: "int", nullable: false),
                    Dosis = table.Column<short>(type: "smallint", nullable: false),
                    fkTipoDosisID = table.Column<int>(type: "int", nullable: false),
                    Cada = table.Column<short>(type: "smallint", nullable: false),
                    fkTipoLapsoID = table.Column<int>(type: "int", nullable: false),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReceta", x => x.pkRecetaID);
                    table.ForeignKey(
                        name: "FK_tblReceta_tblHistorialClinico",
                        column: x => x.fkHistorialClinicoID,
                        principalTable: "tblHistorialClinico",
                        principalColumn: "pkHitorialClinicoID");
                });

            migrationBuilder.CreateTable(
                name: "tblMedicamentosReceta",
                columns: table => new
                {
                    pkMedicametosRecetaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkRecetaID = table.Column<int>(type: "int", nullable: false),
                    fkMedicamentoID = table.Column<int>(type: "int", nullable: false),
                    Dosis = table.Column<short>(type: "smallint", nullable: false),
                    fkTipoDosis = table.Column<int>(type: "int", nullable: false),
                    Lapso = table.Column<short>(type: "smallint", nullable: false),
                    fkTipoLapsoID = table.Column<int>(type: "int", nullable: false),
                    CrBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(user_id())"),
                    CrDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedicamentosReceta", x => x.pkMedicametosRecetaID);
                    table.ForeignKey(
                        name: "FK_tblMedicamentosReceta_tblMedicamento",
                        column: x => x.fkMedicamentoID,
                        principalTable: "tblMedicamento",
                        principalColumn: "pkMedicamentoID");
                    table.ForeignKey(
                        name: "FK_tblMedicamentosReceta_tblReceta",
                        column: x => x.fkRecetaID,
                        principalTable: "tblReceta",
                        principalColumn: "pkRecetaID");
                    table.ForeignKey(
                        name: "FK_tblMedicamentosReceta_tblTipoDosis",
                        column: x => x.fkTipoDosis,
                        principalTable: "tblTipoDosis",
                        principalColumn: "pkTipoDosisID");
                    table.ForeignKey(
                        name: "FK_tblMedicamentosReceta_tblTipoLapso",
                        column: x => x.fkTipoLapsoID,
                        principalTable: "tblTipoLapso",
                        principalColumn: "pkTipoLapsoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblHistorialClinico_fkMedicoID",
                table: "tblHistorialClinico",
                column: "fkMedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_tblHistorialClinico_fkPacienteID",
                table: "tblHistorialClinico",
                column: "fkPacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedicamentosReceta_fkMedicamentoID",
                table: "tblMedicamentosReceta",
                column: "fkMedicamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedicamentosReceta_fkRecetaID",
                table: "tblMedicamentosReceta",
                column: "fkRecetaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedicamentosReceta_fkTipoDosis",
                table: "tblMedicamentosReceta",
                column: "fkTipoDosis");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedicamentosReceta_fkTipoLapsoID",
                table: "tblMedicamentosReceta",
                column: "fkTipoLapsoID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedico_fkEspecialidadID",
                table: "tblMedico",
                column: "fkEspecialidadID");

            migrationBuilder.CreateIndex(
                name: "IX_tblReceta_fkHistorialClinicoID",
                table: "tblReceta",
                column: "fkHistorialClinicoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMedicamentosReceta");

            migrationBuilder.DropTable(
                name: "tblMedicamento");

            migrationBuilder.DropTable(
                name: "tblReceta");

            migrationBuilder.DropTable(
                name: "tblTipoDosis");

            migrationBuilder.DropTable(
                name: "tblTipoLapso");

            migrationBuilder.DropTable(
                name: "tblHistorialClinico");

            migrationBuilder.DropTable(
                name: "tblMedico");

            migrationBuilder.DropTable(
                name: "tblPaciente");

            migrationBuilder.DropTable(
                name: "tblEspecialidad");
        }
    }
}
