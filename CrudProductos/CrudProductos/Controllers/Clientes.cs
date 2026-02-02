using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProductos.Data;
using CrudProductos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CrudProductos.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UsuarioAplicacion> _userManager;

        public ClientesController(ApplicationDbContext context, UserManager<UsuarioAplicacion> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var lista = _context.Clientes
                .Include(c => c.Producto)
                .Include(c => c.Usuario);
            return View(await lista.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes
                .Include(c => c.Producto)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Direccion,Email,ProductoId")] Cliente cliente)
        {
            cliente.UsuarioId = _userManager.GetUserId(User);

            ModelState.Remove("Usuario");
            ModelState.Remove("UsuarioId");
            ModelState.Remove("Producto");

            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si falla, recargamos
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", cliente.ProductoId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) return NotFound();

            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", cliente.ProductoId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id) return NotFound();
            var clienteDb = await _context.Clientes.FindAsync(id);
            if (clienteDb == null) return NotFound();

            clienteDb.Nombres = cliente.Nombres;
            clienteDb.Apellidos = cliente.Apellidos;
            clienteDb.Direccion = cliente.Direccion;
            clienteDb.Email = cliente.Email;
            clienteDb.ProductoId = cliente.ProductoId;

            try
            {
                _context.Update(clienteDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

            }

            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", cliente.ProductoId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes
                .Include(c => c.Producto)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}