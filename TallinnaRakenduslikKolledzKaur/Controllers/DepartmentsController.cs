using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledzKaur.Data;

namespace TallinnaRakenduslikKolledzKaur.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;
        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(d => d.Administrator);
            return View(await schoolContext.ToListAsync());
        }
    }
}
