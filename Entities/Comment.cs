namespace Bluedit.Entities
{
    public class Comment : BaseEntity
    {
        public string Identifier { get; set; } = string.Empty;
        public string Body { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
