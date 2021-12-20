#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App1.Models;

namespace App1.Controllers
{
    public class ComprarsController : Controller
    {
        private readonly Context _context;

        public ComprarsController(Context context)
        {
            _context = context;
        }

        // GET: Comprars
        public async Task<IActionResult> Index()
        {
            var context = _context.Compra.Include(c => c.Cliente).Include(c => c.Destino);
            return View(await context.ToListAsync());
        }

        // GET: Comprars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.Compra
                .Include(c => c.Cliente)
                .Include(c => c.Destino)
                .FirstOrDefaultAsync(m => m.Id_Compra == id);
            if (comprar == null)
            {
                return NotFound();
            }

            return View(comprar);
        }

        // GET: Comprars/Create
        public IActionResult Create()
        {
            ViewData["Email_Cliente"] = new SelectList(_context.Clientes, "Email_Cliente", "Email_Cliente");
            ViewData["Id_Destino"] = new SelectList(_context.Destino, "Id_Destino", "Nome_Destino");
            return View();
        }

        // POST: Comprars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Compra,Email_Cliente,Id_Destino,FormaPagamento,Data_Compra")] Comprar comprar)
        {
            
                _context.Add(comprar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
                ViewData["Email_Cliente"] = new SelectList(_context.Clientes, "Email_Cliente", "Email_Cliente", comprar.Email_Cliente);
                ViewData["Id_Destino"] = new SelectList(_context.Destino, "Id_Destino", "Nome_Destino", comprar.Id_Destino);
            
        }

        // GET: Comprars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.Compra.FindAsync(id);
            if (comprar == null)
            {
                return NotFound();
            }
            ViewData["Email_Cliente"] = new SelectList(_context.Clientes, "Email_Cliente", "Email_Cliente", comprar.Email_Cliente);
            ViewData["Id_Destino"] = new SelectList(_context.Destino, "Id_Destino", "Nome_Destino", comprar.Id_Destino);
            return View(comprar);
        }

        // POST: Comprars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Compra,Email_Cliente,Id_Destino,FormaPagamento,Data_Compra")] Comprar comprar)
        {
            if (id != comprar.Id_Compra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprarExists(comprar.Id_Compra))
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
            ViewData["Email_Cliente"] = new SelectList(_context.Clientes, "Email_Cliente", "Email_Cliente", comprar.Email_Cliente);
            ViewData["Id_Destino"] = new SelectList(_context.Destino, "Id_Destino", "Nome_Destino", comprar.Id_Destino);
            return View(comprar);
        }

        // GET: Comprars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.Compra
                .Include(c => c.Cliente)
                .Include(c => c.Destino)
                .FirstOrDefaultAsync(m => m.Id_Compra == id);
            if (comprar == null)
            {
                return NotFound();
            }

            return View(comprar);
        }

        // POST: Comprars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprar = await _context.Compra.FindAsync(id);
            _context.Compra.Remove(comprar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprarExists(int id)
        {
            return _context.Compra.Any(e => e.Id_Compra == id);
        }
    }
}
