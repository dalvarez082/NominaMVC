using Microsoft.AspNetCore.Mvc;
using NominaMVC.Models;
using NominaMVC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net.Security;


namespace NominaMVC.Controllers
{
    public class AccesoController : Controller
    {
        private readonly NominaContext _DBNomina;

        public AccesoController(NominaContext context)
        {
            _DBNomina = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Persona _persona)
        {
            Logica logica = new Logica(_DBNomina);

            var persona = logica.validarPersona(_persona.IdPersona, _persona.Contrasena);

            if(persona != null)
            {

             





                return RedirectToAction("Index", "Home");

            }

            else
            {
                return View();
            }
           
        }

        public IActionResult Salir()
        {
            return RedirectToAction("Index", "Acceso");
        }

    }
}
