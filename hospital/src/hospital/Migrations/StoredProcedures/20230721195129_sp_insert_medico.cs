using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospital.Migrations
{
    public partial class sp_insert_medico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.InsertMedico
                @Nombre nvarchar(50),
                @ApellidoPaterno nvarchar(50),
                @ApellidoMaterno varchar(50),
                @CedulaProfesional char(10),
                @fkEspecialidadID int,
                @FechaNacimiento datetime,
                @InsertSuccess bit OUTPUT -- Variable de salida para indicar si la inserción fue exitosa (1) o no (0)
            AS
            BEGIN
                SET NOCOUNT ON;
                DECLARE @Edad int
                SET @Edad = DATEDIFF(YEAR, @FechaNacimiento, GETDATE())
                IF @Edad < 25
                BEGIN
                    SET @InsertSuccess = 0; -- No se cumple la condición de edad mínima
                    RETURN;
                END

                BEGIN TRY
                    INSERT INTO TblMedico(Nombre, ApellidoPaterno, ApellidoMaterno, CedulaProfesional, fkEspecialidadID, FechaNacimiento, CrBy, CrDt)
                    VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @CedulaProfesional, @fkEspecialidadID, @FechaNacimiento, user_id(), GETDATE());
                    SET @InsertSuccess = 1; -- La inserción fue exitosa
                END TRY
                BEGIN CATCH
                    SET @InsertSuccess = 0; -- La inserción falló
                END CATCH
            END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.InsertMedico");
        }
    }
}
