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
    public class QuejasController : Controller
    {
        private readonly TrabajoFinalNetContext _context;

        public QuejasController(TrabajoFinalNetContext context)
        {
            _context = context;
        }

        // GET: Quejas
        public async Task<IActionResult> Index()
        {
            var trabajoFinalNetContext = _context.Quejas.Include(q => q.Cliente).Include(q => q.Pedido).Include(q => q.Producto);
            return View(await trabajoFinalNetContext.ToListAsync());
        }

        // GET: Quejas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queja = await _context.Quejas
                .Include(q => q.Cliente)
                .Include(q => q.Pedido)
                .Include(q => q.Producto)
                .FirstOrDefaultAsync(m => m.QuejaId == id);
            if (queja == null)
            {
                return NotFound();
            }

            return View(queja);
        }

        // GET: Quejas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId");
            return View();
        }

        // POST: Quejas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuejaId,ClienteId,ProductoId,PedidoId,Titulo,Descripcion,FechaCreacion,Estado,FechaResolucion")] Queja queja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(queja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", queja.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", queja.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", queja.ProductoId);
            return View(queja);
        }

        // GET: Quejas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queja = await _context.Quejas.FindAsync(id);
            if (queja == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", queja.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", queja.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", queja.ProductoId);
            return View(queja);
        }

        // POST: Quejas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuejaId,ClienteId,ProductoId,PedidoId,Titulo,Descripcion,FechaCreacion,Estado,FechaResolucion")] Queja queja)
        {
            if (id != queja.QuejaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(queja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuejaExists(queja.QuejaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", queja.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", queja.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", queja.ProductoId);
            return View(queja);
        }

        // GET: Quejas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queja = await _context.Quejas
                .Include(q => q.Cliente)
                .Include(q => q.Pedido)
                .Include(q => q.Producto)
                .FirstOrDefaultAsync(m => m.QuejaId == id);
            if (queja == null)
            {
                return NotFound();
            }

            return View(queja);
        }

        // POST: Quejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var queja = await _context.Quejas.FindAsync(id);
            if (queja != null)
            {
                _context.Quejas.Remove(queja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuejaExists(int id)
        {
            return _context.Quejas.Any(e => e.QuejaId == id);
        }
    }
}
