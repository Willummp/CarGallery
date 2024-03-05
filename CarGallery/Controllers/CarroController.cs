using CarGallery.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarGallery.Controllers
{
    public class CarroController : Controller
    {
        private readonly CarGalleryContext _context;

        public CarroController(CarGalleryContext context)
        {
            _context = context;
        }


        public IActionResult Create()
        {
            var fabricantes = _context.Fabricantes.ToList();

            ViewBag.fabricantes = fabricantes;

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Carro carro, [Bind("idFabricante")] int idFabricante)
        {
            var fabricante = this._context.Fabricantes.FirstOrDefault(x => x.Id == idFabricante);

            if (fabricante == null)
                throw new Exception("Fabricante não encontrado");

            fabricante.Carros.Add(carro);
           
            this._context.Fabricantes.Update(fabricante);
            this._context.SaveChanges();

            return Redirect("/fabricante");
        }
    }
}
