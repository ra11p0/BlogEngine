using System.ComponentModel.DataAnnotations;

namespace BlogEngine.ViewModels.Blog
{
    public class CreateViewModel
    {
        [Required]
        public string BlogName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
