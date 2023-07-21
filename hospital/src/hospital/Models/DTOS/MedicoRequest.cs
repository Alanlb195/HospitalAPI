namespace hospital.Models.DTOS
{
    public class MedicoRequest
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
}
