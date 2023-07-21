using System;
using System.Collections.Generic;

namespace hospital.Models.HospitalDB
{
    public partial class TblTipoDosi
    {
        public TblTipoDosi()
        {
            TblMedicamentosReceta = new HashSet<TblMedicamentosRecetum>();
        }

        public int PkTipoDosisId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }

        public virtual ICollection<TblMedicamentosRecetum> TblMedicamentosReceta { get; set; }
    }
}
