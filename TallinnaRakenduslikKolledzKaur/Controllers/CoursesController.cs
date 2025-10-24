using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledzKaur.Data;
using TallinnaRakenduslikKolledzKaur.Models;

namespace TallinnaRakenduslikKolledzKaur.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var courses = _context.Courses.Include(c => c.Department);
            return View(await courses.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            ViewData["Creation"] = true;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                PopulateDepartmentsDropDownList(course.DepartmentID);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["deletion"] = true;
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }
            var courses = await _context.Courses.Include(c =>c.Department).AsNoTracking().FirstOrDefaultAsync(m => m.CourseId == id);
            if (courses == null)
            {
                return NotFound();
            }
            return View(courses);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            { 
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["deletion"] = false;
            if (id == null)
            {
                return NotFound();
            }
            var courses = await _context.Courses.Include(c => c.Department).AsNoTracking().FirstOrDefaultAsync(m => m.CourseId == id);
            if (courses == null)
            {
                return NotFound();
            }
            return View("Delete", courses);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            PopulateDepartmentsDropDownList();
            ViewData["creation"] = false;
            if (id == null)
            {
                return NotFound();
            }
            var courses = await _context.Courses.Include(c => c.Department).AsNoTracking().FirstOrDefaultAsync(m => m.CourseId == id);
            if (courses == null)
            {
                return NotFound();
            }
            /*_context.Departments.Update(department);        */
            return View("Create", courses);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("CourseId,Title,Credits,Enrollments,Department,DepartmentID,CourseAssignments")] Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
    }
}
