using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.GetUserService
{
    public interface IGetUserService
    {
        User GetUserById(string userId);
    }
    public class GetUserService : ServiceTemplate, IGetUserService
    {
        public GetUserService(BlogDbContext context) : base(context)
        {
        }

        public User GetUserById(string userId)
        {
            return Context.Users.First(e => e.Id == userId);
        }
    }
}
