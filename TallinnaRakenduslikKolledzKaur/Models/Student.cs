using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledzKaur.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public int? GPA { get; set; }
        public ICollection<Commendation>? Commendations { get; set; } /* Kiitused */
        public ICollection<Mark>? Marks { get; set; } /* Märkused */



    }
}
