using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntregaFinal.Models;

namespace EntregaFinal.Controllers
{
    public class CalificacionesProductoesController : Controller
    {
        private readonly TrabajoFinalNetContext _context;

        public CalificacionesProductoesController(TrabajoFinalNetContext context)
        {
            _context = context;
        }

        // GET: CalificacionesProductoes
        public async Task<IActionResult> Index()
        {
            var trabajoFinalNetContext = _context.CalificacionesProductos.Include(c => c.Cliente).Include(c => c.Producto);
            return View(await trabajoFinalNetContext.ToListAsync());
        }

        // GET: CalificacionesProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionesProducto = await _context.CalificacionesProductos
                .Include(c => c.Cliente)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.CalificacionId == id);
            if (calificacionesProducto == null)
            {
                return NotFound();
            }

            return View(calificacionesProducto);
        }

        // GET: CalificacionesProductoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId");
            return View();
        }

        // POST: CalificacionesProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalificacionId,ProductoId,ClienteId,Puntuacion,Comentario,Fecha")] CalificacionesProducto calificacionesProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacionesProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", calificacionesProducto.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", calificacionesProducto.ProductoId);
            return View(calificacionesProducto);
        }

        // GET: CalificacionesProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionesProducto = await _context.CalificacionesProductos.FindAsync(id);
            if (calificacionesProducto == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", calificacionesProducto.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", calificacionesProducto.ProductoId);
            return View(calificacionesProducto);
        }

        // POST: CalificacionesProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalificacionId,ProductoId,ClienteId,Puntuacion,Comentario,Fecha")] CalificacionesProducto calificacionesProducto)
        {
            if (id != calificacionesProducto.CalificacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacionesProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionesProductoExists(calificacionesProducto.CalificacionId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", calificacionesProducto.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", calificacionesProducto.ProductoId);
            return View(calificacionesProducto);
        }

        // GET: CalificacionesProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionesProducto = await _context.CalificacionesProductos
                .Include(c => c.Cliente)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.CalificacionId == id);
            if (calificacionesProducto == null)
            {
                return NotFound();
            }

            return View(calificacionesProducto);
        }

        // POST: CalificacionesProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacionesProducto = await _context.CalificacionesProductos.FindAsync(id);
            if (calificacionesProducto != null)
            {
                _context.CalificacionesProductos.Remove(calificacionesProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionesProductoExists(int id)
        {
            return _context.CalificacionesProductos.Any(e => e.CalificacionId == id);
        }
    }
}
