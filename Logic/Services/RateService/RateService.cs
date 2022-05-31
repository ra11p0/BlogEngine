using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.RateService
{
    public interface IRateService
    {
        void Rate(IRateable rateable, Reactions reaction, string userId);
        int GetLikedCount(IRateable rateable);
        int GetDislikedCount(IRateable rateable);
    }
    public class RateService :ServiceTemplate, IRateService
    {

        public void Rate(IRateable rateable, Reactions reaction, string userId)
        {
            var entity = Context.Entry(rateable);
            if (entity.Entity.OwnerId == userId) throw new Exception("Cannot rate owned post.");
            entity.Collection(e=>e.Rates).Load();
            if(entity.Entity.Rates.Any(e=>e.OwnerId == userId)) throw new Exception("Cannot rate post multiple times.");
            var user = Context.Users.First(e => e.Id == userId);
            Rate rate = new()
            {
                OwnerId = user.Id,
                Reaction = reaction
            };
            entity.Entity.Rates.Add(rate);
            Context.SaveChanges();
        }

        public int GetLikedCount(IRateable rateable)
        {
            var entity = Context.Entry(rateable);
            entity.Collection(e => e.Rates).Load();
            return entity.Entity.LikedCounter;
        }

        public int GetDislikedCount(IRateable rateable)
        {
            var entity = Context.Entry(rateable);
            entity.Collection(e => e.Rates).Load();
            return entity.Entity.DislikedCounter;
        }

        public RateService(BlogDbContext context) : base(context)
        {
        }
    }
}
