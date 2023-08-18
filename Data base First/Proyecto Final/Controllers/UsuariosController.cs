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
    public class UsuariosController : Controller
    {
        private readonly PROYECTOFINALContext _context;

        public UsuariosController(PROYECTOFINALContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var pROYECTOFINALContext = _context.TUsuario.Include(t => t.IdRolNavigation);
            return View(await pROYECTOFINALContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TUsuario == null)
            {
                return NotFound();
            }

            var tUsuario = await _context.TUsuario
                .Include(t => t.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tUsuario == null)
            {
                return NotFound();
            }

            return View(tUsuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.TRole, "IdRol", "NombreRol");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Usuario,Contrasena,Cedula,IdRol")] TUsuario tUsuario)
        {
            try
            {
                _context.Add(tUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                throw;
            }
            ViewData["IdRol"] = new SelectList(_context.TRole, "IdRol", "IdRol", tUsuario.IdRol);
            return View(tUsuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TUsuario == null)
            {
                return NotFound();
            }

            var tUsuario = await _context.TUsuario.FindAsync(id);
            if (tUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.TRole, "IdRol", "NombreRol", tUsuario.IdRol);
            return View(tUsuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Usuario,Contrasena,Cedula,IdRol")] TUsuario tUsuario)
        {
            if (id != tUsuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TUsuarioExists(tUsuario.IdUsuario))
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
            ViewData["IdRol"] = new SelectList(_context.TRole, "IdRol", "IdRol", tUsuario.IdRol);
            return View(tUsuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TUsuario == null)
            {
                return NotFound();
            }

            var tUsuario = await _context.TUsuario
                .Include(t => t.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tUsuario == null)
            {
                return NotFound();
            }

            return View(tUsuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TUsuario == null)
            {
                return Problem("Entity set 'PROYECTOFINALContext.TUsuario'  is null.");
            }
            var tUsuario = await _context.TUsuario.FindAsync(id);
            if (tUsuario != null)
            {
                _context.TUsuario.Remove(tUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TUsuarioExists(int id)
        {
          return (_context.TUsuario?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
