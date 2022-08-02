using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NominaMVC.Models;
using System.Diagnostics;

namespace NominaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly NominaContext _DBNomina;

        public HomeController(NominaContext context)
        {
            _DBNomina = context;
        }

        public IActionResult Index()
        {
            List<Persona> lista = _DBNomina.Personas.Include(c => c.oRol).ToList();
            return View(lista);


        }

    }
}