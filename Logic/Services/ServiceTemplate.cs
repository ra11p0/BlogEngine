using DatabaseAccess;

namespace Logic.Services
{
    public abstract class ServiceTemplate
    {
        protected readonly BlogDbContext Context;

        protected ServiceTemplate(BlogDbContext context)
        {
            Context = context;
        }
    }
}
