using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.GetBlogService
{
    public interface IGetBlogService
    {
        Blog? GetBlog(int id);
    }
    public class GetBlogService : IGetBlogService
    {
        private readonly BlogDbContext _context;

        public GetBlogService(BlogDbContext context)
        {
            _context = context;
        }
        public Blog? GetBlog(int id)
        {
            return _context.Blogs.FirstOrDefault(e => e.BlogId == id);
        }
    }
}
