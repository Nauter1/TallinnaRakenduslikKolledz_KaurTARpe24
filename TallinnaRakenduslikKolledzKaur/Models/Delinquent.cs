using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledzKaur.Models
{
    public enum Violations
    {
        Vandalism, IPhoneUser, Smoking, Bullying, AI_User
    }
    public class Delinquent
    {
        [Key]
        public int BreakerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Violations Violations { get; set; }
        public string? Description { get; set; }

    }
}