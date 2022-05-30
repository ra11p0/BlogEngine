using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.CreateBlogService
{
    public interface ICreateBlogService
    {
        int CreateBlog(string name, string description, User owner);
    }
    public class CreateBlogService : ICreateBlogService
    {
        private readonly BlogDbContext _context;

        public CreateBlogService(BlogDbContext context)
        {
            _context = context;
        }
        public int CreateBlog(string name, string description, User owner)
        {
            owner = _context.Users.FirstOrDefault(e => e.Id == owner.Id) ?? owner;
            Blog blog = new Blog()
            {
                BlogName = name,
                Description = description,
                Owner = owner
            };
            _context.Add(blog);
            _context.SaveChanges();
            return blog.BlogId;
        }
    }
}
