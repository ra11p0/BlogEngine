using DatabaseAccess;
using DatabaseAccess.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services.GetBlogService
{
    public interface IGetBlogService
    {
        Blog? GetBlog(int id);
    }
    public class GetBlogService :ServiceTemplate, IGetBlogService
    {
        public Blog? GetBlog(int id)
        {
            return Context.Blogs
                .Include(e=>e.Posts)
                .FirstOrDefault(e => e.BlogId == id);
        }

        public GetBlogService(BlogDbContext context) : base(context)
        {
        }
    }
}
