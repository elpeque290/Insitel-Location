using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_INSITEL.Models;


namespace CRUD_INSITEL.Controllers
{
    public class UbicacionesController : Controller
    {
        private readonly UbicacionesBdContext _context;

        public UbicacionesController(UbicacionesBdContext context)
        {
            _context = context;
        }

        // GET: Ubicaciones
        public async Task<IActionResult> Index()
        {
              return _context.Ubicaciones != null ? 
                          View(await _context.Ubicaciones.ToListAsync()) :
                          Problem("Entity set 'UbicacionesBdContext.Ubicaciones'  is null.");
        }

        // GET: Ubicaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicacione = await _context.Ubicaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ubicacione == null)
            {
                return NotFound();
            }

            return View(ubicacione);
        }

        // GET: Ubicaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ubicaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ubicacion,Longitud,Latitud,TemperaturaActual")] Ubicacione ubicacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ubicacione);
        }

        // GET: Ubicaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicacione = await _context.Ubicaciones.FindAsync(id);
            if (ubicacione == null)
            {
                return NotFound();
            }
            return View(ubicacione);
        }

        // POST: Ubicaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ubicacion,Longitud,Latitud,TemperaturaActual")] Ubicacione ubicacione)
        {
            if (id != ubicacione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubicacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbicacioneExists(ubicacione.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ubicacione);
        }

        // GET: Ubicaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicacione = await _context.Ubicaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ubicacione == null)
            {
                return NotFound();
            }

            return View(ubicacione);
        }

        // POST: Ubicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ubicaciones == null)
            {
                return Problem("Entity set 'UbicacionesBdContext.Ubicaciones'  is null.");
            }
            var ubicacione = await _context.Ubicaciones.FindAsync(id);
            if (ubicacione != null)
            {
                _context.Ubicaciones.Remove(ubicacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacioneExists(int id)
        {
          return (_context.Ubicaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public class UbicacioneController : Controller
        {
            private readonly UbicacionesBdContext _context;

            public UbicacioneController(UbicacionesBdContext context)
            {
                _context = context;
            }

            // GET: Ubicaciones
            public async Task<IActionResult> Index()
            {
                // Obtener todas las ubicaciones de la base de datos
                var ubicaciones = await _context.Ubicaciones.ToListAsync();
                return View(ubicaciones);
            }

            // Resto de acciones CRUD...

            // GET: Ubicaciones/Mapa
            public IActionResult Mapa()
            {
                return View();
            }
        }
    }
}
