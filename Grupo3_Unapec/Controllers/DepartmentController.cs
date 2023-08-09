using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grupo3_Unapec.Domain.Entities;
using Grupo3_Unapec.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Grupo3_Unapec.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context; // 

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList(); // 

            return View(departments);
        }

        // Details
        public IActionResult Details(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // Edit
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}