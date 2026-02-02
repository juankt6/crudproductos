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

namespace CrudProductos.Controllers
{
    [Authorize]
    public class VendedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vendedores
        public async Task<IActionResult> Index()
        {

            var vendedores = await _context.Users.ToListAsync();
            return View(vendedores);
        }

        // GET: Vendedores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        public IActionResult Create()
        {
            return RedirectToPage("/Account/Register", new { area = "Identity" });
        }
    }
}