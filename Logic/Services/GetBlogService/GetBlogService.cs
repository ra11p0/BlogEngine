using DatabaseAccess;
using DatabaseAccess.DbModels;
using Microsoft.EntityFrameworkCore;

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
            return _context.Blogs
                .Include(e=>e.Posts)
                .Include(e=>e.Owner)
                .FirstOrDefault(e => e.BlogId == id);
        }
    }
}
