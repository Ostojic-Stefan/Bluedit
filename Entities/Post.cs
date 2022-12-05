namespace Bluedit.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
