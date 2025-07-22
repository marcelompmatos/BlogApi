namespace BlogApi.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public BlogPost? Post { get; set; }
    }
}
