using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledzKaur.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }
        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public byte? RowVersion { get; set; }
        public int? Staplers { get; set; }
        public string? Accomplishments { get; set; }
        public int? WastedHours { get; set; }
    }
}
