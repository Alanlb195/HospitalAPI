using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospital.Migrations
{
    public partial class sp_delete_medico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.deleteMedico
                @pkMedicoID int,
                @DeleteSuccess bit OUTPUT -- Variable de salida para indicar si la eliminación fue exitosa (1) o no (0)
            AS
            BEGIN
                SET NOCOUNT ON;

                BEGIN TRY
                    DELETE FROM TblMedico
                    WHERE pkMedicoID = @pkMedicoID;
                    SET @DeleteSuccess = 1; -- La eliminación fue exitosa
                END TRY
                BEGIN CATCH
                    SET @DeleteSuccess = 0; -- La eliminación falló
                END CATCH
            END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.deleteMedico");
        }
    }
}
