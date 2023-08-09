using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Grupo3_Unapec.Presentation.Models;

namespace Grupo3_Unapec.Presentation.Controllers
{
    public class AreaConocimientoController : Controller
    {
        private List<AreaConocimiento> areasConocimiento = new List<AreaConocimiento>();

        public AreaConocimientoController()
        {
            // Agregar áreas de conocimiento de ejemplo para demostración
            areasConocimiento.Add(new AreaConocimiento(1, 101, "Ciencias Computacionales"));
            areasConocimiento.Add(new AreaConocimiento(2, 102, "Matemáticas"));
        }

        public IActionResult Index()
        {
            List<AreaConocimiento> areas = areasConocimiento; // Obtener áreas de conocimiento (simulación de datos)
            return View(areas);
        }

        public IActionResult Crear()
        {
            // Aquí puedes manejar la lógica para crear una nueva área de conocimiento en la lista
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Actualizar(int id)
        {
            AreaConocimiento area = areasConocimiento.Find(a => a.ID_Area == id);
            if (area == null)
            {
                return NotFound();
            }
            return View(area);
        }

        [HttpPost]
        public IActionResult Actualizar(AreaConocimiento area)
        {
            AreaConocimiento areaExistente = areasConocimiento.Find(a => a.ID_Area == area.ID_Area);
            if (areaExistente != null)
            {
                areaExistente.ID_Departamento = area.ID_Departamento;
                areaExistente.Nombre_Area = area.Nombre_Area;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            AreaConocimiento area = areasConocimiento.Find(a => a.ID_Area == id);
            if (area == null)
            {
                return NotFound();
            }
            return View(area);
        }

        [HttpPost]
        public IActionResult EliminarConfirmado(int id)
        {
            AreaConocimiento area = areasConocimiento.Find(a => a.ID_Area == id);
            if (area != null)
            {
                areasConocimiento.Remove(area);
            }
            return RedirectToAction("Index");
        }
    }
}

