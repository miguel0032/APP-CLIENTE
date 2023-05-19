using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quimera.Models;

namespace Quimera.Controllers
{
    public class DireccionController : Controller
    {
        private readonly ClientesDbContext _context;

        public DireccionController(ClientesDbContext context)
        {
            _context = context;
        }

        // GET: Direccion
        public async Task<IActionResult> Index()
        {
            var clientesDbContext = _context.Direccions.Include(d => d.Cliente);
            return View(await clientesDbContext.ToListAsync());
        }

        // GET: Direccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Direccions == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // GET: Direccion/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: Direccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle,Ciudad,CodigoPostal,Pais,ClienteId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", direccion.ClienteId);
            return View(direccion);
        }

        // GET: Direccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Direccions == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", direccion.ClienteId);
            return View(direccion);
        }

        // POST: Direccion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,Ciudad,CodigoPostal,Pais,ClienteId")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", direccion.ClienteId);
            return View(direccion);
        }

        // GET: Direccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Direccions == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // POST: Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Direccions == null)
            {
                return Problem("Entity set 'ClientesDbContext.Direccions'  is null.");
            }
            var direccion = await _context.Direccions.FindAsync(id);
            if (direccion != null)
            {
                _context.Direccions.Remove(direccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
          return (_context.Direccions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
