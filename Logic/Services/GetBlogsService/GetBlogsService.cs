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
    public class GetBlogsService :ServiceTemplate, IGetBlogsService
    {
        public IEnumerable<Blog> GetBlogsByUser(User user)
        {
            var blogs = Context.Blogs.Where(e => e.OwnerId == user.Id);
            foreach (var blog in blogs)
                yield return blog;
        }

        public IEnumerable<Blog> GetTopBlogs(int quantity)
        {
            var blogs = Context.Blogs.Include(e=>e.Posts).ToList().OrderBy(e=>e.Views).Take(5);
            foreach (var blog in blogs)
                yield return blog;
        }

        public GetBlogsService(BlogDbContext context) : base(context)
        {
        }
    }
}
