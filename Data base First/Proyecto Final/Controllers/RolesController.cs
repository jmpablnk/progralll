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
    public class RolesController : Controller
    {
        private readonly PROYECTOFINALContext _context;

        public RolesController(PROYECTOFINALContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
              return _context.TRole != null ? 
                          View(await _context.TRole.ToListAsync()) :
                          Problem("Entity set 'PROYECTOFINALContext.TRole'  is null.");
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TRole == null)
            {
                return NotFound();
            }

            var tRole = await _context.TRole
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (tRole == null)
            {
                return NotFound();
            }

            return View(tRole);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRol,NombreRol")] TRole tRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tRole);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TRole == null)
            {
                return NotFound();
            }

            var tRole = await _context.TRole.FindAsync(id);
            if (tRole == null)
            {
                return NotFound();
            }
            return View(tRole);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRol,NombreRol")] TRole tRole)
        {
            if (id != tRole.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TRoleExists(tRole.IdRol))
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
            return View(tRole);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TRole == null)
            {
                return NotFound();
            }

            var tRole = await _context.TRole
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (tRole == null)
            {
                return NotFound();
            }

            return View(tRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TRole == null)
            {
                return Problem("Entity set 'PROYECTOFINALContext.TRole'  is null.");
            }
            var tRole = await _context.TRole.FindAsync(id);
            if (tRole != null)
            {
                _context.TRole.Remove(tRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TRoleExists(int id)
        {
          return (_context.TRole?.Any(e => e.IdRol == id)).GetValueOrDefault();
        }
    }
}
