using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.CreateBlogService
{
    public interface ICreateBlogService
    {
        int CreateBlog(string name, string description, User owner);
    }
    public class CreateBlogService :ServiceTemplate, ICreateBlogService
    {
        public int CreateBlog(string name, string description, User owner)
        {
            owner = Context.Users.FirstOrDefault(e => e.Id == owner.Id) ?? owner;
            Blog blog = new Blog()
            {
                BlogName = name,
                Description = description,
                OwnerId = owner.Id
            };
            Context.Add(blog);
            Context.SaveChanges();
            return blog.BlogId;
        }

        public CreateBlogService(BlogDbContext context) : base(context)
        {
        }
    }
}
