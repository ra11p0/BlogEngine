using System.ComponentModel.DataAnnotations;

namespace BlogEngine.ViewModels.Post.Partial
{
    public class CommentCreatorViewModel
    {
        [Required]
        public string CommentText { get; set; }
        [Required]
        public int CommendableId { get; set; }
    }
}
