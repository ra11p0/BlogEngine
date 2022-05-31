using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.AddUserService
{
    public interface IAddUserService
    {
        void AddUser(User user);
    }
    public class AddUserService : ServiceTemplate, IAddUserService
    {

        public void AddUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public AddUserService(BlogDbContext context) : base(context)
        {
        }
    }
}
