using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledzKaur.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int TotalStock { get; set; }
        public int AmountBorrowed { get; set; }
        public int CurrentStock
        {
            get { return TotalStock-AmountBorrowed; }
        }


    }
}