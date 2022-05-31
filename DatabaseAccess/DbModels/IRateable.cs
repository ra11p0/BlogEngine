namespace DatabaseAccess.DbModels
{
    public interface IRateable
    {
        public string OwnerId { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public int LikedCounter => Rates.Count(e => e.Reaction == Reactions.Liked);
        public int DislikedCounter => Rates.Count(e => e.Reaction == Reactions.Disliked);
    }
}
