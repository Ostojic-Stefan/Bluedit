namespace Bluedit.Dtos
{
    public class PostsWithUserDto
    {
        public string Title { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public UserDto User { get; set; }
    }
}
