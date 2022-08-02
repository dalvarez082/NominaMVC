using System;
using System.Collections.Generic;

namespace NominaMVC.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
