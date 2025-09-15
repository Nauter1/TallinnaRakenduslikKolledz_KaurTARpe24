namespace TallinnaRakenduslikKolledzKaur.Models
{
    public class CourseAssignment
    {
        public string Id { get; set; }
        public int InstructorId { get; set; }
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
