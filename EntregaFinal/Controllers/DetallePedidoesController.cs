﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntregaFinal.Models;

namespace EntregaFinal.Controllers
{
    public class DetallePedidoesController : Controller
    {
        private readonly TrabajoFinalNetContext _context;

        public DetallePedidoesController(TrabajoFinalNetContext context)
        {
            _context = context;
        }

        // GET: DetallePedidoes
        public async Task<IActionResult> Index()
        {
            var trabajoFinalNetContext = _context.DetallePedidos.Include(d => d.Pedido).Include(d => d.Producto);
            return View(await trabajoFinalNetContext.ToListAsync());
        }

        // GET: DetallePedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetallePedidoId == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedidoes/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId");
            return View();
        }

        // POST: DetallePedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetallePedidoId,PedidoId,ProductoId,Cantidad,PrecioUnitario,Subtotal")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", detallePedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detallePedido.ProductoId);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", detallePedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detallePedido.ProductoId);
            return View(detallePedido);
        }

        // POST: DetallePedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetallePedidoId,PedidoId,ProductoId,Cantidad,PrecioUnitario,Subtotal")] DetallePedido detallePedido)
        {
            if (id != detallePedido.DetallePedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.DetallePedidoId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", detallePedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detallePedido.ProductoId);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetallePedidoId == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido != null)
            {
                _context.DetallePedidos.Remove(detallePedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedidos.Any(e => e.DetallePedidoId == id);
        }
    }
}
