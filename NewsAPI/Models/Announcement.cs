using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Models
{
    public class Announcement
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public String Message { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Range(1, 3, ErrorMessage = "Id must be between 1 and 3")]
        public String CategoryId { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public String Author { get; set; }
    }
}
