using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Models;

namespace Proyecto_Final.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly PROYECTOFINALContext _context;

        public ProyectosController(PROYECTOFINALContext context)
        {
            _context = context;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index()
        {
              return _context.TProyecto != null ? 
                          View(await _context.TProyecto.ToListAsync()) :
                          Problem("Entity set 'PROYECTOFINALContext.TProyecto'  is null.");
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TProyecto == null)
            {
                return NotFound();
            }

            var tProyecto = await _context.TProyecto
                .FirstOrDefaultAsync(m => m.IdProyecto == id);
            if (tProyecto == null)
            {
                return NotFound();
            }

            return View(tProyecto);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProyecto,Titulo,Descripcion,FechaInicio,FechaFin")] TProyecto tProyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tProyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tProyecto);
        }

        // GET: Proyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TProyecto == null)
            {
                return NotFound();
            }

            var tProyecto = await _context.TProyecto.FindAsync(id);
            if (tProyecto == null)
            {
                return NotFound();
            }
            return View(tProyecto);
        }

        // POST: Proyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProyecto,Titulo,Descripcion,FechaInicio,FechaFin")] TProyecto tProyecto)
        {
            if (id != tProyecto.IdProyecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tProyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TProyectoExists(tProyecto.IdProyecto))
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
            return View(tProyecto);
        }

        // GET: Proyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TProyecto == null)
            {
                return NotFound();
            }

            var tProyecto = await _context.TProyecto
                .FirstOrDefaultAsync(m => m.IdProyecto == id);
            if (tProyecto == null)
            {
                return NotFound();
            }

            return View(tProyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TProyecto == null)
            {
                return Problem("Entity set 'PROYECTOFINALContext.TProyecto'  is null.");
            }
            var tProyecto = await _context.TProyecto.FindAsync(id);
            if (tProyecto != null)
            {
                _context.TProyecto.Remove(tProyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TProyectoExists(int id)
        {
          return (_context.TProyecto?.Any(e => e.IdProyecto == id)).GetValueOrDefault();
        }
    }
}
