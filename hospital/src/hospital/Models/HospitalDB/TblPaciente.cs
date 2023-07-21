using System;
using System.Collections.Generic;

namespace hospital.Models.HospitalDB
{
    public partial class TblPaciente
    {
        public TblPaciente()
        {
            TblHistorialClinicos = new HashSet<TblHistorialClinico>();
        }

        public int PkPacienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public string? Domicillio { get; set; }
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }

        public virtual ICollection<TblHistorialClinico> TblHistorialClinicos { get; set; }
    }
}
