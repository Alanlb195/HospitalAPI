using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hospital.Models.HospitalDB;
using hospital.Models.DTOS;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

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

        // GET: api/TblMedicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoRequest>>> GetTblMedicos()
        {
            if (_context.TblMedicos == null)
            {
                return NotFound();
            }

            IEnumerable<TblMedico> medicos = await _context.TblMedicos.ToListAsync();

            var response = _mapper.Map<List<MedicoRequest>>(medicos);

            return response;
        }


        // POST: api/TblMedicos/SpInsertMedico
        [HttpPost("SpInsertMedico")]
        public IActionResult InsertarMedico(
            [StringLength(50)] string nombre,
            [StringLength(50)] string apellidoPaterno,
            [StringLength(50)] string apellidoMaterno,
            [StringLength(10)] string cedulaProfesional,
            int especialidadId,
            DateTime fechaNacimiento)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($@"
            EXECUTE dbo.InsertMedico
            {nombre}, 
            {apellidoPaterno}, 
            {apellidoMaterno}, 
            {cedulaProfesional}, 
            {especialidadId}, 
            {fechaNacimiento}");

                return Ok("Se ha insertado correctamente el registro");
            }
            catch (Exception ex)
            {
                return BadRequest("No se pudo insertar el registro. Error: " + ex.Message);
            }
        }



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


    }
}
