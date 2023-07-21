using System;
using System.Collections.Generic;

namespace hospital.Models.HospitalDB
{
    public partial class TblEspecialidad
    {
        public TblEspecialidad()
        {
            TblMedicos = new HashSet<TblMedico>();
        }

        public int PkEspecialidadId { get; set; }
        public string CodigoEspecialidad { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }

        public virtual ICollection<TblMedico> TblMedicos { get; set; }
    }
}
