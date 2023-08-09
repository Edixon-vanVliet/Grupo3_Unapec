using AutoMapper;
using Grupo3_Unapec.Application.Common.Interfaces;
using Grupo3_Unapec.Application.Subjects;
using Grupo3_Unapec.Domain.Entities;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Grupo3_Unapec.Presentation.Models;

namespace Grupo3_Unapec.Presentation.Controllers
{
    public class ProfesorController : Controller
    {
        private static List<Profesor> _profesores = new List<Profesor>();

        // Listar todos los profesores
        public IActionResult Listar()
        {
            return View(_profesores);
        }

        // Crear un nuevo profesor
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                profesor.Id = ObtenerNuevoId();
                _profesores.Add(profesor);
                return RedirectToAction("Listar");
            }
            return View(profesor);
        }

        // Actualizar información de un profesor
        public IActionResult Actualizar(int id)
        {
            var profesor = _profesores.Find(p => p.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        [HttpPost]
        public IActionResult Actualizar(int id, Profesor profesorEditado)
        {
            var profesor = _profesores.Find(p => p.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                profesor.Nombre = profesorEditado.Nombre;
                profesor.Apellido = profesorEditado.Apellido;
                profesor.Email = profesorEditado.Email;
                profesor.Especialidad = profesorEditado.Especialidad;
                profesor.FechaNacimiento = profesorEditado.FechaNacimiento;
                profesor.Telefono = profesorEditado.Telefono;

                return RedirectToAction("Listar");
            }
            return View(profesorEditado);
        }

        // Eliminar un profesor
        public IActionResult Eliminar(int id)
        {
            var profesor = _profesores.Find(p => p.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public IActionResult ConfirmarEliminar(int id)
        {
            var profesor = _profesores.Find(p => p.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }
            _profesores.Remove(profesor);
            return RedirectToAction("Listar");
        }

        // Método para obtener un nuevo ID único
        private int ObtenerNuevoId()
        {
            int maxId = 0;
            foreach (var profesor in _profesores)
            {
                if (profesor.Id > maxId)
                {
                    maxId = profesor.Id;
                }
            }
            return maxId + 1;
        }
    }
}
