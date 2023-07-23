using System.ComponentModel.DataAnnotations;

namespace hospital.Models.HospitalDB.DTOS
{
    public class MedicoView
    {
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public string CedulaProfesional { get; set; } = null!;
        public int FkEspecialidadId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }
    }

    public class MedicoRequest
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidoMaterno { get; set; }

        [Required]
        [StringLength(10)]
        public string CedulaProfesional { get; set; }

        public int EspecialidadId { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }

}
