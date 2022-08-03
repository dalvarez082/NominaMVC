using System;
using System.Collections.Generic;

namespace NominaMVC.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Pagos = new List<Pago>();
        }

        public string IdPersona { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdRol { get; set; }
        public double? Salario { get; set; }
        public string Contrasena { get; set; } = null!;

        public virtual Rol? oRol { get; set; } = null!;
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
