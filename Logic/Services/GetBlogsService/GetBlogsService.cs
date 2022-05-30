using DatabaseAccess;
using DatabaseAccess.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services.GetBlogsService
{
    public interface IGetBlogsService
    {
        IEnumerable<Blog> GetBlogsByUser(User user);
        IEnumerable<Blog> GetTopBlogs(int quantity);
    }
    public class GetBlogsService : IGetBlogsService
    {
        private readonly BlogDbContext _context;

        public GetBlogsService(BlogDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Blog> GetBlogsByUser(User user)
        {
            var blogs = _context.Blogs.Where(e => e.Owner.Id == user.Id);
            foreach (var blog in blogs)
                yield return blog;
        }

        public IEnumerable<Blog> GetTopBlogs(int quantity)
        {
            var blogs = _context.Blogs.Include(e=>e.Posts).ToList().OrderBy(e=>e.Views).Take(5);
            foreach (var blog in blogs)
                yield return blog;
        }
    }
}
