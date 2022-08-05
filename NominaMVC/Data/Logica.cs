using Microsoft.EntityFrameworkCore.Storage;
using NominaMVC.Models;

namespace NominaMVC.Data
{
    public class Logica 
    {
        private NominaContext context;

        public Logica(NominaContext context)
        {
            this.context = context;
        }

        public List<Persona> listaPersona()
        {

           
            List<Persona> lista = context.Personas.ToList();
            return lista;

        }

        public Persona validarPersona(string identificacion, string clave)
        {
            return listaPersona().Where(e => e.IdPersona == identificacion && e.Contrasena == clave).FirstOrDefault();
        }

       
       
        
    }
}
