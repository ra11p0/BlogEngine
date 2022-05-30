using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DbModels
{
    public abstract class Rateable
    {
        public IEnumerable<Rate> Rates { get; set; }
        public int LikedCounter => Rates.Count(e => e.Reaction == Reactions.Liked);
        public int DislikedCounter => Rates.Count(e => e.Reaction == Reactions.Disliked);
    }
}
