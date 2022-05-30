using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.GetPostService
{
    public interface IGetPostService
    {
        Post? GetPostById(int id);
    }
    public class GetPostService : IGetPostService
    {
        private readonly BlogDbContext _context;

        public GetPostService(BlogDbContext context)
        {
            _context = context;
        }
        public Post? GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(e => e.PostId == id);
        }
    }
}
