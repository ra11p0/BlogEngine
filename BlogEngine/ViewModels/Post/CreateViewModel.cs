using System.ComponentModel.DataAnnotations;

namespace BlogEngine.ViewModels.Post
{
    public class CreateViewModel
    {
        [Required]
        [MinLength(10)]
        public string Title { get; set; }
        [Required]
        [MinLength(50)]
        public string PostText { get; set; }
        public int OwningBlogId { get; set; }
    }
}
