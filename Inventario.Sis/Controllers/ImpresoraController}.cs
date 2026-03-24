using Inventario.Sis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Sis.Controllers
{
    public class ImpresoraController : Controller
    {
        private readonly InventarioSistemasContext _context;

        public ImpresoraController(InventarioSistemasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Impresoras.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Impresora model)
        {
            if (ModelState.IsValid)
            {
                var impresora = new Impresora()
                {
                    Marca = model.Marca,
                    Serie = model.Serie,
                    Tipotinta = model.Tipotinta,
                    Observacion = model.Observacion,
                    Estado = 1
                };

                _context.Add(impresora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}