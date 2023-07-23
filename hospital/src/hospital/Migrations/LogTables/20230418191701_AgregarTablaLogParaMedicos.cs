using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospital.Migrations
{
    public partial class AgregarTablaLogParaMedicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TABLE log_table_tblMedico (
              [pkMedicoID] INT NOT NULL,
              [Nombre] VARCHAR(50) NOT NULL,
              [ApellidoPaterno] VARCHAR(50) NOT NULL,
              [ApellidoMaterno] VARCHAR(50) NOT NULL,
              [CedulaProfesional] VARCHAR(20) NOT NULL,
              [fkEspecialidadID] INT NOT NULL,
              [FechaNacimiento] DATE NOT NULL,
              [CrBy] VARCHAR(50) NOT NULL,
              [CrDt] DATETIME NOT NULL,
              [FechaEliminacion] DATETIME NOT NULL,
              [UsuarioEliminacion] VARCHAR(50) NOT NULL
            );

            GO

            CREATE TRIGGER tr_delete_tblMedico
            ON dbo.tblMedico
            AFTER DELETE
            AS
            BEGIN
              DECLARE @pkMedicoID INT,
                      @Nombre VARCHAR(50),
                      @ApellidoPaterno VARCHAR(50),
                      @ApellidoMaterno VARCHAR(50),
                      @CedulaProfesional VARCHAR(20),
                      @fkEspecialidadID INT,
                      @FechaNacimiento DATE,
                      @CrBy VARCHAR(50),
                      @CrDt DATETIME,
                      @FechaEliminacion DATETIME,
                      @UsuarioEliminacion VARCHAR(50);

              SELECT @pkMedicoID = pkMedicoID,
                     @Nombre = Nombre,
                     @ApellidoPaterno = ApellidoPaterno,
                     @ApellidoMaterno = ApellidoMaterno,
                     @CedulaProfesional = CedulaProfesional,
                     @fkEspecialidadID = fkEspecialidadID,
                     @FechaNacimiento = FechaNacimiento,
                     @CrBy = CrBy,
                     @CrDt = CrDt,
                     @FechaEliminacion = GETDATE(),
                     @UsuarioEliminacion = SYSTEM_USER
              FROM deleted;

              INSERT INTO dbo.log_table_tblMedico (
                pkMedicoID,
                Nombre,
                ApellidoPaterno,
                ApellidoMaterno,
                CedulaProfesional,
                fkEspecialidadID,
                FechaNacimiento,
                CrBy,
                CrDt,
                FechaEliminacion,
                UsuarioEliminacion
              )
              VALUES (
                @pkMedicoID,
                @Nombre,
                @ApellidoPaterno,
                @ApellidoMaterno,
                @CedulaProfesional,
                @fkEspecialidadID,
                @FechaNacimiento,
                @CrBy,
                @CrDt,
                @FechaEliminacion,
                @UsuarioEliminacion
              );
            END;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DROP TRIGGER tr_delete_tblMedico;
            DROP TABLE log_table_tblMedico;
        ");
        }
    }
}
