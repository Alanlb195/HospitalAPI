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
            @FechaNacimiento datetime
            AS
            BEGIN
                SET NOCOUNT ON;
                DECLARE @Edad int
                SET @Edad = DATEDIFF(YEAR, @FechaNacimiento, GETDATE())
                IF @Edad < 25
                    RETURN
    
                INSERT INTO TblMedico(Nombre, ApellidoPaterno, ApellidoMaterno, CedulaProfesional, fkEspecialidadID, FechaNacimiento, CrBy, CrDt)
                VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @CedulaProfesional, @fkEspecialidadID, @FechaNacimiento, user_id(), GETDATE());
            END
            ");

            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.deleteMedico
                @pkMedicoID int
            AS
            BEGIN
                SET NOCOUNT ON;
    
                DELETE FROM TblMedico
                WHERE pkMedicoID = @pkMedicoID;
            END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.InsertMedico");
            migrationBuilder.Sql("DROP PROCEDURE dbo.deleteMedico");
        }
    }
}
