using Microsoft.AspNetCore.Identity;

namespace DatabaseAccess.DbModels
{
    public class User : IdentityUser
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public User(string userName) : base(userName){}
    }
}
