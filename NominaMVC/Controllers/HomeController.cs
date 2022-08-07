using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NominaMVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using NominaMVC.Data;

namespace NominaMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly NominaContext _DBNomina;

        public HomeController(NominaContext context)
        {
            _DBNomina = context;
        }


        public async Task<IActionResult> Privacy()
        {
            return View();
        }



        public IActionResult Index()
        {
            List<Persona> lista = _DBNomina.Personas.Include(c => c.oRol).ToList();
            return View(lista);


        }

        // Get the payment info to render in Report for Admins
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

        public ActionResult GetPaymentsTotal()
        {
            ViewData["TotalPayments"] = _DBNomina.Pagos.Sum(payment => payment.MontoPago);
            return View();

        }
    }
}