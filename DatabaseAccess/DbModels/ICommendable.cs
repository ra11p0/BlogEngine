namespace DatabaseAccess.DbModels
{
    public interface ICommendable
    {
        public ICollection<Comment> Comments { get; set; }
    }
}
