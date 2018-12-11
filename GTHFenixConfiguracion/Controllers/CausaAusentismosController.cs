using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entidades;
using GTHFenixConfiguracion.Repositorios;

namespace GTHFenixConfiguracion.Controllers
{
    public class CausaAusentismosController : Controller
    {
        private readonly FenixContexto _context;

        public CausaAusentismosController(FenixContexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.causaAusentismos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var causaAusentismo = await _context.causaAusentismos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (causaAusentismo == null)
            {
                return NotFound();
            }

            return View(causaAusentismo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Remunerado,DescuentaDomingo,IdItem,Activo")] CausaAusentismo causaAusentismo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(causaAusentismo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(causaAusentismo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var causaAusentismo = await _context.causaAusentismos.FindAsync(id);
            if (causaAusentismo == null)
            {
                return NotFound();
            }
            return View(causaAusentismo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Remunerado,DescuentaDomingo,IdItem,Activo")] CausaAusentismo causaAusentismo)
        {
            if (id != causaAusentismo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(causaAusentismo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CausaAusentismoExists(causaAusentismo.Id))
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
            return View(causaAusentismo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var causaAusentismo = await _context.causaAusentismos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (causaAusentismo == null)
            {
                return NotFound();
            }

            return View(causaAusentismo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var causaAusentismo = await _context.causaAusentismos.FindAsync(id);
            _context.causaAusentismos.Remove(causaAusentismo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CausaAusentismoExists(int id)
        {
            return _context.causaAusentismos.Any(e => e.Id == id);
        }
    }
}
