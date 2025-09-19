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
    public class ComisionesController : Controller
    {
        private readonly TrabajoFinalNetContext _context;

        public ComisionesController(TrabajoFinalNetContext context)
        {
            _context = context;
        }

        // GET: Comisiones
        public async Task<IActionResult> Index()
        {
            var trabajoFinalNetContext = _context.Comisiones.Include(c => c.Pedido).Include(c => c.Vendedor);
            return View(await trabajoFinalNetContext.ToListAsync());
        }

        // GET: Comisiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comisione = await _context.Comisiones
                .Include(c => c.Pedido)
                .Include(c => c.Vendedor)
                .FirstOrDefaultAsync(m => m.ComisionId == id);
            if (comisione == null)
            {
                return NotFound();
            }

            return View(comisione);
        }

        // GET: Comisiones/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId");
            ViewData["VendedorId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId");
            return View();
        }

        // POST: Comisiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComisionId,VendedorId,PedidoId,PorcentajeComision,MontoComision,FechaCalculo,Pagada")] Comisione comisione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comisione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", comisione.PedidoId);
            ViewData["VendedorId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", comisione.VendedorId);
            return View(comisione);
        }

        // GET: Comisiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comisione = await _context.Comisiones.FindAsync(id);
            if (comisione == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", comisione.PedidoId);
            ViewData["VendedorId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", comisione.VendedorId);
            return View(comisione);
        }

        // POST: Comisiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComisionId,VendedorId,PedidoId,PorcentajeComision,MontoComision,FechaCalculo,Pagada")] Comisione comisione)
        {
            if (id != comisione.ComisionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comisione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComisioneExists(comisione.ComisionId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", comisione.PedidoId);
            ViewData["VendedorId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", comisione.VendedorId);
            return View(comisione);
        }

        // GET: Comisiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comisione = await _context.Comisiones
                .Include(c => c.Pedido)
                .Include(c => c.Vendedor)
                .FirstOrDefaultAsync(m => m.ComisionId == id);
            if (comisione == null)
            {
                return NotFound();
            }

            return View(comisione);
        }

        // POST: Comisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comisione = await _context.Comisiones.FindAsync(id);
            if (comisione != null)
            {
                _context.Comisiones.Remove(comisione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComisioneExists(int id)
        {
            return _context.Comisiones.Any(e => e.ComisionId == id);
        }
    }
}
