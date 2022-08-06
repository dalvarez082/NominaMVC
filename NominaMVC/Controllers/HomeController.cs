using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NominaMVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using NominaMVC.Data;

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

        // Get the payment info to reender in Report for Admins
        public async Task<IActionResult> ReporteE()
        {
            var nominaContext = _DBNomina.Pagos.Include(payment => payment.oPersona);
            return View(await nominaContext.ToListAsync());


        }
        // Get the payment info to reender in Report for Admins
        public async Task<IActionResult> ReporteA()
        {
            var nominaContext = _DBNomina.Pagos.Include(payment => payment.oPersona);
            return View(await nominaContext.ToListAsync());
        }
    }
}