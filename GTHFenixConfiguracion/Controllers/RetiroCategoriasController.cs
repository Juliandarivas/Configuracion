using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entidades;
using GTHFenixConfiguracion.Repositorios;

namespace GTHFenixConfiguracion.Controllers
{
    public class RetiroCategoriasController : Controller
    {
        private readonly FenixContexto _context;

        public RetiroCategoriasController(FenixContexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RetiroCategorias.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiroCategoria = await _context.RetiroCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retiroCategoria == null)
            {
                return NotFound();
            }

            return View(retiroCategoria);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] RetiroCategoria retiroCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retiroCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retiroCategoria);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiroCategoria = await _context.RetiroCategorias.FindAsync(id);
            if (retiroCategoria == null)
            {
                return NotFound();
            }
            return View(retiroCategoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] RetiroCategoria retiroCategoria)
        {
            if (id != retiroCategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retiroCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetiroCategoriaExists(retiroCategoria.Id))
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
            return View(retiroCategoria);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiroCategoria = await _context.RetiroCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retiroCategoria == null)
            {
                return NotFound();
            }

            return View(retiroCategoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retiroCategoria = await _context.RetiroCategorias.FindAsync(id);
            _context.RetiroCategorias.Remove(retiroCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetiroCategoriaExists(int id)
        {
            return _context.RetiroCategorias.Any(e => e.Id == id);
        }
    }
}
