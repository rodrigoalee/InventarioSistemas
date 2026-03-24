using Inventario.Sis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Sis.Controllers
{
    public class AsignacionController : Controller
    {
        private readonly InventarioSistemasContext _context;

        public AsignacionController(InventarioSistemasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Usuarios = new SelectList(await _context.Usuarios.ToListAsync(), "Idusuario", "Nombre");
            ViewBag.Computadoras = new SelectList(await _context.Computadoras.ToListAsync(), "IdCompu", "Marca");
            ViewBag.Monitores = new SelectList(await _context.Monitores.ToListAsync(), "IdMonitor", "Marca");
            ViewBag.Impresoras = new SelectList(await _context.Impresoras.ToListAsync(), "IdImpresora", "Marca");
            ViewBag.Perifericos = new SelectList(await _context.Perifericos.ToListAsync(), "Idperiferico", "Nombre");
            ViewBag.Ups = new SelectList(await _context.Ups.ToListAsync(), "IdUps", "Marca");

            var lista = await _context.Asignacions
                .Include(a => a.IdusuarioNavigation)
                .Include(a => a.IdCompuNavigation)
                .Include(a => a.IdMonitorNavigation)
                .Include(a => a.IdImpresoraNavigation)
                .Include(a => a.IdperifericoNavigation)
                .Include(a => a.IdUpsNavigation)
                .ToListAsync();

            return View(lista);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Asignacion model)
        {
            ModelState.Remove("IdusuarioNavigation");
            ModelState.Remove("IdCompuNavigation");
            ModelState.Remove("IdMonitorNavigation");
            ModelState.Remove("IdImpresoraNavigation");
            ModelState.Remove("IdperifericoNavigation");
            ModelState.Remove("IdUpsNavigation");

            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}