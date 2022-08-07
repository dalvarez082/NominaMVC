using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NominaMVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using NominaMVC.Data;

namespace NominaMVC.Controllers
{
<<<<<<< HEAD
    //[Authorize]
=======

>>>>>>> ad5ade18e75b6dd54e84c849d752b98c4ef309b7
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

<<<<<<< HEAD
        public IActionResult Privacy()
        {
            return View();
        }





        [Authorize(Roles  = "1")]
       
        public IActionResult ReporteE()
        {
           

            return View();

=======
        // Get the payment info to render in Report for Admins
        public async Task<IActionResult> ReporteE()
        {
            var nominaContext = _DBNomina.Pagos.Include(payment => payment.oPersona);
            return View(await nominaContext.ToListAsync());
>>>>>>> ad5ade18e75b6dd54e84c849d752b98c4ef309b7


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