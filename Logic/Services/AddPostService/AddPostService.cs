using DatabaseAccess;
using DatabaseAccess.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services.AddPostService
{
    public interface IAddPostService
    {
        int AddPost(string title, string content, int blogId, string userId);
    }
    public class AddPostService : IAddPostService
    {
        private readonly BlogDbContext _context;

        public AddPostService(BlogDbContext context)
        {
            _context = context;
        }
        public int AddPost(string title, string content, int blogId, string userId)
        {
            var blog = _context.Blogs.Include(e=>e.Posts).FirstOrDefault(e => e.BlogId == blogId);
            var user = _context.Users.FirstOrDefault(e => e.Id == userId);
            Post post = new Post()
            {
                Title = title,
                PostText = content,
                Owner = user!,
                OwningBlog = blog!,
                CreatedDate = DateTime.Now,
            };
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post.PostId;
        }
    }
}
