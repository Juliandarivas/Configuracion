using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades;
using GTHFenixConfiguracion.Repositorios;
using Enumerables;

namespace GTHFenixConfiguracion.Controllers
{
    public class CausaIncapacidadesController : Controller
    {
        private readonly FenixContexto _context;

        public CausaIncapacidadesController(FenixContexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CausaIncapacidad.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var causaIncapacidad = await _context.CausaIncapacidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (causaIncapacidad == null)
            {
                return NotFound();
            }

            return View(causaIncapacidad);
        }

        public IActionResult Create()
        {
            ViewData["TipoCalendario"] = new SelectList(ObtenerListaTipoConteoDias(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricpcion,MesesPromedio,PorcentajeEmpleador,PorcentajeEntidad,DiasEmpleador,DiasMaximos,TipoConteoDias,Activo,Entidad")] CausaIncapacidad causaIncapacidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(causaIncapacidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(causaIncapacidad);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["TipoCalendario"] = new SelectList(ObtenerListaTipoConteoDias(), "Id", "Descripcion");

            if (id == null)
            {
                return NotFound();
            }

            var causaIncapacidad = await _context.CausaIncapacidad.FindAsync(id);
            if (causaIncapacidad == null)
            {
                return NotFound();
            }
            return View(causaIncapacidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricpcion,MesesPromedio,PorcentajeEmpleador,PorcentajeEntidad,DiasEmpleador,DiasMaximos,TipoConteoDias,Activo,Entidad")] CausaIncapacidad causaIncapacidad)
        {
            if (id != causaIncapacidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(causaIncapacidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CausaIncapacidadExists(causaIncapacidad.Id))
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
            return View(causaIncapacidad);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var causaIncapacidad = await _context.CausaIncapacidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (causaIncapacidad == null)
            {
                return NotFound();
            }

            return View(causaIncapacidad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var causaIncapacidad = await _context.CausaIncapacidad.FindAsync(id);
            _context.CausaIncapacidad.Remove(causaIncapacidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CausaIncapacidadExists(int id)
        {
            return _context.CausaIncapacidad.Any(e => e.Id == id);
        }

        private IEnumerable<object> ObtenerListaTipoConteoDias()
        {
            return Enum.GetValues(typeof(TipoConteoDias))
                .Cast<TipoConteoDias>()
                .Select(tipo => new
                {
                    Id = tipo,
                    Descripcion = tipo.ToString()
                });
        }
    }
}
