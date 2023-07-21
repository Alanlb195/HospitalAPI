using System;
using System.Collections.Generic;

namespace hospital.Models.HospitalDB
{
    public partial class TblMedicamentosRecetum
    {
        public int PkMedicametosRecetaId { get; set; }
        public int FkRecetaId { get; set; }
        public int FkMedicamentoId { get; set; }
        public short Dosis { get; set; }
        public int FkTipoDosis { get; set; }
        public short Lapso { get; set; }
        public int FkTipoLapsoId { get; set; }
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }

        public virtual TblMedicamento FkMedicamento { get; set; } = null!;
        public virtual TblRecetum FkReceta { get; set; } = null!;
        public virtual TblTipoDosi FkTipoDosisNavigation { get; set; } = null!;
        public virtual TblTipoLapso FkTipoLapso { get; set; } = null!;
    }
}
