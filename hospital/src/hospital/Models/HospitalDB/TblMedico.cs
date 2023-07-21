using System;
using System.Collections.Generic;

namespace hospital.Models.HospitalDB
{
    public partial class TblMedico
    {
        public TblMedico()
        {
            TblHistorialClinicos = new HashSet<TblHistorialClinico>();
        }

        public int PkMedicoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public string CedulaProfesional { get; set; } = null!;
        public int FkEspecialidadId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }

        public virtual TblEspecialidad FkEspecialidad { get; set; } = null!;
        public virtual ICollection<TblHistorialClinico> TblHistorialClinicos { get; set; }
    }
}
