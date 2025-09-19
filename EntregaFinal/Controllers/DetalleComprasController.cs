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
    public class DetalleComprasController : Controller
    {
        private readonly TrabajoFinalNetContext _context;

        public DetalleComprasController(TrabajoFinalNetContext context)
        {
            _context = context;
        }

        // GET: DetalleCompras
        public async Task<IActionResult> Index()
        {
            var trabajoFinalNetContext = _context.DetalleCompras.Include(d => d.Compra).Include(d => d.Producto);
            return View(await trabajoFinalNetContext.ToListAsync());
        }

        // GET: DetalleCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompras
                .Include(d => d.Compra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleCompraId == id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            return View(detalleCompra);
        }

        // GET: DetalleCompras/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId");
            return View();
        }

        // POST: DetalleCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleCompraId,CompraId,ProductoId,Cantidad,CostoUnitario,Subtotal")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", detalleCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detalleCompra.ProductoId);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompra == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", detalleCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detalleCompra.ProductoId);
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleCompraId,CompraId,ProductoId,Cantidad,CostoUnitario,Subtotal")] DetalleCompra detalleCompra)
        {
            if (id != detalleCompra.DetalleCompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCompraExists(detalleCompra.DetalleCompraId))
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
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", detalleCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", detalleCompra.ProductoId);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompras
                .Include(d => d.Compra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleCompraId == id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            return View(detalleCompra);
        }

        // POST: DetalleCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleCompra = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompra != null)
            {
                _context.DetalleCompras.Remove(detalleCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCompraExists(int id)
        {
            return _context.DetalleCompras.Any(e => e.DetalleCompraId == id);
        }
    }
}
