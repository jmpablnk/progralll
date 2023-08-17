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
    public class TareasController : Controller
    {
        private readonly PROYECTOFINALContext _context;

        public TareasController(PROYECTOFINALContext context)
        {
            _context = context;
        }

        // GET: Tareas
        public async Task<IActionResult> Index()
        {
            var pROYECTOFINALContext = _context.TTarea.Include(t => t.IdProyectoNavigation).Include(t => t.IdUsuarioNavigation);
            return View(await pROYECTOFINALContext.ToListAsync());
        }

        // GET: Tareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TTarea == null)
            {
                return NotFound();
            }

            var tTarea = await _context.TTarea
                .Include(t => t.IdProyectoNavigation)
                .Include(t => t.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdTarea == id);
            if (tTarea == null)
            {
                return NotFound();
            }

            return View(tTarea);
        }

        // GET: Tareas/Create
        public IActionResult Create()
        {
            ViewData["IdProyecto"] = new SelectList(_context.TProyecto, "IdProyecto", "Titulo");
            ViewData["IdUsuario"] = new SelectList(_context.TUsuario, "IdUsuario", "Usuario");
            return View();
        }

        // POST: Tareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTarea,IdProyecto,Titulo,Descripcion,NivelDificultad,FechaInicio,FechaFin,IdUsuario")] TTarea tTarea)
        {
            try
            {
                _context.Add(tTarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                throw;
            }
            ViewData["IdProyecto"] = new SelectList(_context.TProyecto, "IdProyecto", "IdProyecto", tTarea.IdProyecto);
            ViewData["IdUsuario"] = new SelectList(_context.TUsuario, "IdUsuario", "IdUsuario", tTarea.IdUsuario);
            return View(tTarea);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TTarea == null)
            {
                return NotFound();
            }

            var tTarea = await _context.TTarea.FindAsync(id);
            if (tTarea == null)
            {
                return NotFound();
            }
            ViewData["IdProyecto"] = new SelectList(_context.TProyecto, "IdProyecto", "Titulo", tTarea.IdProyecto);
            ViewData["IdUsuario"] = new SelectList(_context.TUsuario, "IdUsuario", "Usuario", tTarea.IdUsuario);
            return View(tTarea);
        }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarea,IdProyecto,Titulo,Descripcion,NivelDificultad,FechaInicio,FechaFin,IdUsuario")] TTarea tTarea)
        {
            if (id != tTarea.IdTarea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tTarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TTareaExists(tTarea.IdTarea))
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
            ViewData["IdProyecto"] = new SelectList(_context.TProyecto, "IdProyecto", "IdProyecto", tTarea.IdProyecto);
            ViewData["IdUsuario"] = new SelectList(_context.TUsuario, "IdUsuario", "IdUsuario", tTarea.IdUsuario);
            return View(tTarea);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TTarea == null)
            {
                return NotFound();
            }

            var tTarea = await _context.TTarea
                .Include(t => t.IdProyectoNavigation)
                .Include(t => t.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdTarea == id);
            if (tTarea == null)
            {
                return NotFound();
            }

            return View(tTarea);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TTarea == null)
            {
                return Problem("Entity set 'PROYECTOFINALContext.TTarea'  is null.");
            }
            var tTarea = await _context.TTarea.FindAsync(id);
            if (tTarea != null)
            {
                _context.TTarea.Remove(tTarea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TTareaExists(int id)
        {
          return (_context.TTarea?.Any(e => e.IdTarea == id)).GetValueOrDefault();
        }
    }
}
