using System;
using System.Collections.Generic;

namespace hospital.Models.HospitalDB
{
    public partial class TblRecetum
    {
        public TblRecetum()
        {
            TblMedicamentosReceta = new HashSet<TblMedicamentosRecetum>();
        }

        public int PkRecetaId { get; set; }
        public int FkHistorialClinicoId { get; set; }
        public int FkMedicamentoId { get; set; }
        public short Dosis { get; set; }
        public int FkTipoDosisId { get; set; }
        public short Cada { get; set; }
        public int FkTipoLapsoId { get; set; }
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }

        public virtual TblHistorialClinico FkHistorialClinico { get; set; } = null!;
        public virtual ICollection<TblMedicamentosRecetum> TblMedicamentosReceta { get; set; }
    }
}
