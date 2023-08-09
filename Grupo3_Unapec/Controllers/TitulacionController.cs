using Grupo3_Unapec.Presentation.data;
using Grupo3_Unapec.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grupo3_Unapec.Presentation.Controllers
{
    public class TitulacionController : Controller
    {
        private readonly TitulacionContext _context;

        public TitulacionController(TitulacionContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var titulaciones = _context.Titulaciones.ToList();
            return View(titulaciones);
        }
        [HttpPost]
        public IActionResult Create(Titulacion titulacion)
        {
            if (ModelState.IsValid)
            {
                _context.Titulaciones.Add(titulacion);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titulacion);
        }
        public IActionResult index()
        {
            var titulaciones = _context.Titulaciones.ToList();
            return View(titulaciones);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var titulacion = _context.Titulaciones.Find(id);
            if (titulacion == null)
            {
                return NotFound();
            }
            return View(titulacion);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var titulacion = _context.Titulaciones.Find(id);
            _context.Titulaciones.Remove(titulacion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
