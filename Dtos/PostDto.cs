using Bluedit.Entities;

namespace Bluedit.Dtos
{
    public class PostDto
    {
        public string Title { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
