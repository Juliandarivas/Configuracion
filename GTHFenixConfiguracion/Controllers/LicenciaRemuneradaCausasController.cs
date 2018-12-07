using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entidades;
using GTHFenixConfiguracion.Repositorios;

namespace GTHFenixConfiguracion.Controllers
{
    public class LicenciaRemuneradaCausasController : Controller
    {
        private readonly FenixContexto _context;

        public LicenciaRemuneradaCausasController(FenixContexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.LicenciaRemuneradaCausas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenciaRemuneradaCausa = await _context.LicenciaRemuneradaCausas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licenciaRemuneradaCausa == null)
            {
                return NotFound();
            }

            return View(licenciaRemuneradaCausa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,IdItem,Activo")] LicenciaRemuneradaCausa licenciaRemuneradaCausa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licenciaRemuneradaCausa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(licenciaRemuneradaCausa);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenciaRemuneradaCausa = await _context.LicenciaRemuneradaCausas.FindAsync(id);
            if (licenciaRemuneradaCausa == null)
            {
                return NotFound();
            }
            return View(licenciaRemuneradaCausa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,IdItem,Activo")] LicenciaRemuneradaCausa licenciaRemuneradaCausa)
        {
            if (id != licenciaRemuneradaCausa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licenciaRemuneradaCausa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenciaRemuneradaCausaExists(licenciaRemuneradaCausa.Id))
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
            return View(licenciaRemuneradaCausa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenciaRemuneradaCausa = await _context.LicenciaRemuneradaCausas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licenciaRemuneradaCausa == null)
            {
                return NotFound();
            }

            return View(licenciaRemuneradaCausa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licenciaRemuneradaCausa = await _context.LicenciaRemuneradaCausas.FindAsync(id);
            _context.LicenciaRemuneradaCausas.Remove(licenciaRemuneradaCausa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenciaRemuneradaCausaExists(int id)
        {
            return _context.LicenciaRemuneradaCausas.Any(e => e.Id == id);
        }
    }
}
