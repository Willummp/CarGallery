using CarGallery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarGalleryContext _context;
        public HomeController(ILogger<HomeController> logger, CarGalleryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Carro> carros = _context.Carros.ToList();

            ViewBag.Carros = carros;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
