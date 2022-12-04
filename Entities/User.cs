using System.ComponentModel.DataAnnotations;

namespace Bluedit.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public byte[] Salt { get; set; } = Array.Empty<byte>();
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
