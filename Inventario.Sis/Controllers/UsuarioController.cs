using Inventario.Sis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Sis.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly InventarioSistemasContext _context;

        public UsuarioController(InventarioSistemasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario()
                {
                    Nombre=model.Nombre,
                    Area=model.Area,
                };
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
            
        }

    }
}
