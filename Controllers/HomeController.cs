using CRUD_INSITEL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_INSITEL.Controllers
{
    // Controlador para las vistas principales de la aplicación.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor para inicializar el logger.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Vista de inicio.
        public IActionResult Index() => View();

        // Vista de privacidad.
        public IActionResult Privacy() => View();

        // Vista de errores.
        // Se asegura de que las páginas de error no se almacenen en caché.
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}