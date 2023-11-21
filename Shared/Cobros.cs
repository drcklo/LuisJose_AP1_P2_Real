using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisJose_AP1_P2_Real.Shared
{
    public class Cobros
    {
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }
        public int Balance { get; set; }
        public int Cobrado { get; set; }
        public bool Pagado { get; set; }
    }
}
