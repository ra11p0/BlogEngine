using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DbModels
{
    public class Post : Rateable
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public string PostText { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public User Owner { get; set; }
        public int Views { get; set; }
    }
}
