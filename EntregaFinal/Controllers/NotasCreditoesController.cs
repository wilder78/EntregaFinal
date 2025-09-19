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
    public class NotasCreditoesController : Controller
    {
        private readonly TrabajoFinalNetContext _context;

        public NotasCreditoesController(TrabajoFinalNetContext context)
        {
            _context = context;
        }

        // GET: NotasCreditoes
        public async Task<IActionResult> Index()
        {
            var trabajoFinalNetContext = _context.NotasCreditos.Include(n => n.Cliente).Include(n => n.Pedido);
            return View(await trabajoFinalNetContext.ToListAsync());
        }

        // GET: NotasCreditoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notasCredito = await _context.NotasCreditos
                .Include(n => n.Cliente)
                .Include(n => n.Pedido)
                .FirstOrDefaultAsync(m => m.NotaCreditoId == id);
            if (notasCredito == null)
            {
                return NotFound();
            }

            return View(notasCredito);
        }

        // GET: NotasCreditoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId");
            return View();
        }

        // POST: NotasCreditoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotaCreditoId,ClienteId,PedidoId,Monto,FechaEmision,Motivo,Estado")] NotasCredito notasCredito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notasCredito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notasCredito.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", notasCredito.PedidoId);
            return View(notasCredito);
        }

        // GET: NotasCreditoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notasCredito = await _context.NotasCreditos.FindAsync(id);
            if (notasCredito == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notasCredito.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", notasCredito.PedidoId);
            return View(notasCredito);
        }

        // POST: NotasCreditoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotaCreditoId,ClienteId,PedidoId,Monto,FechaEmision,Motivo,Estado")] NotasCredito notasCredito)
        {
            if (id != notasCredito.NotaCreditoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notasCredito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasCreditoExists(notasCredito.NotaCreditoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", notasCredito.ClienteId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", notasCredito.PedidoId);
            return View(notasCredito);
        }

        // GET: NotasCreditoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notasCredito = await _context.NotasCreditos
                .Include(n => n.Cliente)
                .Include(n => n.Pedido)
                .FirstOrDefaultAsync(m => m.NotaCreditoId == id);
            if (notasCredito == null)
            {
                return NotFound();
            }

            return View(notasCredito);
        }

        // POST: NotasCreditoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notasCredito = await _context.NotasCreditos.FindAsync(id);
            if (notasCredito != null)
            {
                _context.NotasCreditos.Remove(notasCredito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasCreditoExists(int id)
        {
            return _context.NotasCreditos.Any(e => e.NotaCreditoId == id);
        }
    }
}
