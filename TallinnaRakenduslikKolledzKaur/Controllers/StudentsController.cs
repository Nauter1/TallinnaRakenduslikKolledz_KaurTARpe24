using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TallinnaRakenduslikKolledzKaur.Data;
using TallinnaRakenduslikKolledzKaur.Models;

namespace TallinnaRakenduslikKolledzKaur.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;
        public StudentsController(SchoolContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        ///  Lisa uus student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, LastName,FirstName,EnrollmentDate,Commendments")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index))
            }
            return View(student);
        }
        /// <summary>
        ///  Get delete view for student
        /// </summary>
        /// <param name="Id">id of student</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == Id);
            if (student == null) 
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            var student = await _context.Students.FindAsync(Id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == Id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
                     [HttpGet]
        public async Task<IActionResult>Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == Id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Update(student);
            return View(student);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("Id,LastName,FirstName,EnrollmentDate,Commendments")] Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Clone(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == Id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Clone")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CloneConfirmed(int? Id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == Id);
            //ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index))
            }
            return View(student);
        }
        /*
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int? ID)
        {
            var student = await _context.Students.FindAsync(ID);
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }                    */
    }
}
