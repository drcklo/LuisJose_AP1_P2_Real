﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisJose_AP1_P2_Real.Shared
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
    }
}
