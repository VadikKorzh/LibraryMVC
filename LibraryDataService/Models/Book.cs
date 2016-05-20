using System.ComponentModel.DataAnnotations;

namespace LibraryDataService.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        public string ISBN { get; set; }

        public virtual Writer Author { get; set; }
    }
}