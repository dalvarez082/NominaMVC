using Microsoft.AspNetCore.Mvc;
using NominaMVC.Models;
using NominaMVC.Data;


using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

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
        public async Task<IActionResult> IndexAsync(Persona _persona)
        {
            Logica logica = new Logica(_DBNomina);

            var persona = logica.validarPersona(_persona.IdPersona, _persona.Contrasena);

            if(persona != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, persona.Nombre),
                    new Claim("IdPersona", persona.IdPersona),
                    new Claim(ClaimTypes.Role,Convert.ToString( persona.IdRol)),
                };

                
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));






                return RedirectToAction("Index", "Home");
            }

            else
            {
                return View();
            }
           
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }

    }
}
