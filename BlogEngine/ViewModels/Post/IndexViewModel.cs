using Logic.Dtos;

namespace BlogEngine.ViewModels.Post
{
    public class IndexViewModel
    {
        public DatabaseAccess.DbModels.Post Post { get; set; }
        public int Liked { get; set; }
        public int Disliked { get; set; }
        public IEnumerable<CommentViewModelDto> CommentsDtos { get; set; }
    }
}
