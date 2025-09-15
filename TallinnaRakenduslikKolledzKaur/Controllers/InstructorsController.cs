using TallinnaRakenduslikKolledzKaur.Data;
using Microsoft.AspNetCore.Mvc;
using TallinnaRakenduslikKolledzKaur.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TallinnaRakenduslikKolledzKaur.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;
        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var vm = new InstructorIndexData();
            vm.Instructors = await _context.Instructors
            .Include(i => i.OfficeAssignment)
            .Include(i => i.CourseAssignments)
            .ToListAsync();
            return View(vm);
        }
    }
}
                                                                 
