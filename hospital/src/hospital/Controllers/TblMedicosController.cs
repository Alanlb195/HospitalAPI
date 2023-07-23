using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hospital.Models.HospitalDB;
using AutoMapper;
using hospital.Models.HospitalDB.DTOS;
using Microsoft.Data.SqlClient;

namespace hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblMedicosController : ControllerBase
    {
        private readonly dbExamen1Context _context;
        private readonly IMapper _mapper;

        public TblMedicosController(dbExamen1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        #region GetTblMedicos
        // GET: api/TblMedicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoView>>> GetTblMedicos()
        {
            if (_context.TblMedicos == null)
            {
                return NotFound();
            }

            IEnumerable<TblMedico> medicos = await _context.TblMedicos.ToListAsync();

            var response = _mapper.Map<List<MedicoView>>(medicos);

            return response;
        }
        #endregion



        #region SpInsertMedico
        // POST: api/TblMedicos/SpInsertMedico
        [HttpPost("SpInsertMedico")]
        public IActionResult InsertarMedico([FromBody] MedicoRequest request)
        {
            try
            {
                // Validar el modelo
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var parameters = new[]
                {
                    new SqlParameter("@Nombre", request.Nombre),
                    new SqlParameter("@ApellidoPaterno", request.ApellidoPaterno),
                    new SqlParameter("@ApellidoMaterno", request.ApellidoMaterno),
                    new SqlParameter("@CedulaProfesional", request.CedulaProfesional),
                    new SqlParameter("@fkEspecialidadID", request.EspecialidadId),
                    new SqlParameter("@FechaNacimiento", request.FechaNacimiento),
                    new SqlParameter("@InsertSuccess", System.Data.SqlDbType.Bit)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    }
                };

                var insertSuccessParameter = parameters.Last(); // Referencia al último parámetro (@InsertSuccess)

                _context.Database.
                    ExecuteSqlRaw("EXECUTE dbo.InsertMedico @Nombre, @ApellidoPaterno, @ApellidoMaterno, @CedulaProfesional, @fkEspecialidadID, @FechaNacimiento, @InsertSuccess OUTPUT", parameters);

                bool insertSuccess = (bool)insertSuccessParameter.Value;

                if (insertSuccess)
                {
                    return Ok("Se ha insertado correctamente el registro");
                }
                else
                {
                    return BadRequest("No se pudo insertar el registro.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("No se pudo insertar el registro. Error: " + ex.Message);
            }
        }
        #endregion
        


        #region DeleteTblMedico
        // DELETE: api/TblMedicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMedico(int id)
        {
            if (_context.TblMedicos == null)
            {
                return NotFound();
            }
            var tblMedico = await _context.TblMedicos.FindAsync(id);
            if (tblMedico == null)
            {
                return NotFound();
            }

            _context.TblMedicos.Remove(tblMedico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion


    }
}
