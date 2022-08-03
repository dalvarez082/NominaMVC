using Microsoft.AspNetCore.Mvc;
using NominaMVC.Models;
using NominaMVC.Data;

namespace NominaMVC.Controllers
{
    public class AccesoController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Persona _persona)
        {
            Logica logica = new Logica();

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



    }
}
