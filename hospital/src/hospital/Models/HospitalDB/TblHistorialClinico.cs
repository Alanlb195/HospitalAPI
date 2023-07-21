using System;
using System.Collections.Generic;

namespace hospital.Models.HospitalDB
{
    public partial class TblHistorialClinico
    {
        public TblHistorialClinico()
        {
            TblReceta = new HashSet<TblRecetum>();
        }

        public int PkHitorialClinicoId { get; set; }
        public DateTime DtFechaConsulta { get; set; }
        public double? Peso { get; set; }
        public double? Estatura { get; set; }
        public double? TemperaturaCorporal { get; set; }
        public string? Sitomas { get; set; }
        public string? Observaciones { get; set; }
        public string? Diagnostico { get; set; }
        public int FkPacienteId { get; set; }
        public int FkMedicoId { get; set; }
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }

        public virtual TblMedico FkMedico { get; set; } = null!;
        public virtual TblPaciente FkPaciente { get; set; } = null!;
        public virtual ICollection<TblRecetum> TblReceta { get; set; }
    }
}
