using DatabaseAccess;
using DatabaseAccess.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services.AddPostService
{
    public interface IAddPostService
    {
        int AddPost(string title, string content, int blogId, string userId);
    }
    public class AddPostService : ServiceTemplate, IAddPostService
    {
        public int AddPost(string title, string content, int blogId, string userId)
        {
            var blog = Context.Blogs.Include(e=>e.Posts).Single(e => e.BlogId == blogId);
            var user = Context.Users.FirstOrDefault(e => e.Id == userId);
            Post post = new Post()
            {
                Title = title,
                PostText = content,
                OwnerId = user!.Id,
                OwningBlog = blog,
                CreatedDate = DateTime.Now,
            };
            Context.Posts.Add(post);
            Context.SaveChanges();
            return post.PostId;
        }

        public AddPostService(BlogDbContext context) : base(context)
        {
        }
    }
}
