using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledzKaur.Data;
using TallinnaRakenduslikKolledzKaur.Models;

namespace TallinnaRakenduslikKolledzKaur.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;
        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Delinquents.ToListAsync());
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Add(delinquent);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(d => d.BreakerId == Id);
            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(d => d.BreakerId == Id);
            if (delinquent == null)
            {
                return NotFound();
            }
            _context.Delinquents.Update(delinquent);
            return View(delinquent);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("BreakerId,FirstName,LastName,Violations,Description,Position")] Delinquent delinquent)
        {
            _context.Delinquents.Update(delinquent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        /*
[HttpGet]
public async Task<IActionResult> Delete(int? id)
{
ViewData["deletion"] = true;
if (id == null)
{
    return NotFound();
}
var books = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
if (books == null)
{
    return NotFound();
}
return View(books);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Delete(Book book)
{
if (await _context.Books.AnyAsync(b => b.BookId == book.BookId))
{
    _context.Books.Remove(book);
    await _context.SaveChangesAsync();
}
return RedirectToAction("Index");
}



private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
{
var departmentsQuery = from d in _context.Departments
                       orderby d.Name
                       select d;
ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
}                                                                                                                 */
    }
}
