using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisJose_AP1_P2_Real.Shared
{
    public class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int VentaId { get; set; }
        public int CobroId { get; set; }
        public int ClienteId { get; set; }
        public double Cobrado { get; set; }
        public bool Pagado { get; set; }
    }
}
