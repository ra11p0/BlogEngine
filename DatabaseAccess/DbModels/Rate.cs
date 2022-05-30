using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DbModels
{
    public enum Reactions{Liked, Disliked}
    public class Rate
    {
        public int RateId { get; set; }
        public Reactions Reaction { get; set; }
        public User Owner { get; set; }
    }
}
