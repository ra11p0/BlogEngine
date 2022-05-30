using DatabaseAccess.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity
{
    public class BlogIdentityDbContext : IdentityDbContext<User>
    {
        public BlogIdentityDbContext(DbContextOptions<BlogIdentityDbContext> options) : base(options){}
    }
}
