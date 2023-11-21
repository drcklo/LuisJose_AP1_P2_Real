using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisJose_AP1_P2_Real.Shared
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public DateTime Fecha { get; set; }
        public double TotalCobrado { get; set; }
        public string? Observaciones { get; set; }
        [ForeignKey("CobroId")]
        public ICollection<CobrosDetalle> CobrosDetalle { get; set; } = new List<CobrosDetalle>();
    }
}
