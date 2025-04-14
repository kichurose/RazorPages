using System.ComponentModel.DataAnnotations;

namespace RazorPages.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public string Title { get; set; }

        public string ISBN { get; set; }
    }
}
