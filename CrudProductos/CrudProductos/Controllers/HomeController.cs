using CrudProductos.Data;
using CrudProductos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudProductos.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; 


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {

            ViewBag.ListaProductos = new SelectList(_context.Productos, "Id", "Nombre");


            var clientes = await _context.Clientes
                                         .Include(c => c.Producto)
                                         .OrderByDescending(c => c.Id) 
                                         .Take(10) 
                                         .ToListAsync();


            return View(clientes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.ListaProductos = new SelectList(_context.Productos, "Id", "Nombre", cliente.ProductoId);
            var listaClientes = await _context.Clientes.Include(c => c.Producto).ToListAsync();
            return View("Index", listaClientes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}