using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades;
using GTHFenixConfiguracion.Repositorios;

namespace GTHFenixConfiguracion.Controllers
{
    public class RetiroCausasController : Controller
    {
        private readonly FenixContexto _context;

        public RetiroCausasController(FenixContexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var fenixContexto = _context.RetirosCausa.Include(r => r.RetiroCategoria);
            return View(await fenixContexto.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiroCausa = await _context.RetirosCausa
                .Include(r => r.RetiroCategoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retiroCausa == null)
            {
                return NotFound();
            }

            return View(retiroCausa);
        }

        public IActionResult Create()
        {
            ViewData["IdRetiroCategoria"] = new SelectList(_context.RetiroCategorias, "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,IdRetiroCategoria")] RetiroCausa retiroCausa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retiroCausa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRetiroCategoria"] = new SelectList(_context.RetiroCategorias, "Id", "Descripcion", retiroCausa.IdRetiroCategoria);
            return View(retiroCausa);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiroCausa = await _context.RetirosCausa.FindAsync(id);
            if (retiroCausa == null)
            {
                return NotFound();
            }
            ViewData["IdRetiroCategoria"] = new SelectList(_context.RetiroCategorias, "Id", "Descripcion", retiroCausa.IdRetiroCategoria);
            return View(retiroCausa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,IdRetiroCategoria")] RetiroCausa retiroCausa)
        {
            if (id != retiroCausa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retiroCausa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetiroCausaExists(retiroCausa.Id))
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
            ViewData["IdRetiroCategoria"] = new SelectList(_context.RetiroCategorias, "Id", "Descripcion", retiroCausa.IdRetiroCategoria);
            return View(retiroCausa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retiroCausa = await _context.RetirosCausa
                .Include(r => r.RetiroCategoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retiroCausa == null)
            {
                return NotFound();
            }

            return View(retiroCausa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retiroCausa = await _context.RetirosCausa.FindAsync(id);
            _context.RetirosCausa.Remove(retiroCausa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetiroCausaExists(int id)
        {
            return _context.RetirosCausa.Any(e => e.Id == id);
        }
    }
}
