using System;
using System.Collections.Generic;

namespace NominaMVC.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public string IdPersona { get; set; } = null!;
        public DateTime FechaPago { get; set; }
        public double MontoPago { get; set; }

        public virtual Persona? oPersona { get; set; } = null!;
    }
}
