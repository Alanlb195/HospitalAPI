using System;
using System.Collections.Generic;

namespace hospital.Models.HospitalDB
{
    public partial class TblMedicamento
    {
        public TblMedicamento()
        {
            TblMedicamentosReceta = new HashSet<TblMedicamentosRecetum>();
        }

        public int PkMedicamentoId { get; set; }
        public string CodigoMedicamento { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public int CrBy { get; set; }
        public DateTime CrDt { get; set; }

        public virtual ICollection<TblMedicamentosRecetum> TblMedicamentosReceta { get; set; }
    }
}
