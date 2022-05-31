using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DbModels
{
    public class Post : IRateable, ICommendable
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public string PostText { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Blog OwningBlog { get; set; }
        public int Views { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string OwnerId { get; set; }
        public ICollection<Rate> Rates { get; set; }
    }
}
