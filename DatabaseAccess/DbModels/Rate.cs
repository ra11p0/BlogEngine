using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.DbModels
{
    public enum Reactions{Liked, Disliked}
    public class Rate
    {
        public int RateId { get; set; }
        public Reactions Reaction { get; set; }
        [Required]
        public string OwnerId { get; set; }
    }
}
