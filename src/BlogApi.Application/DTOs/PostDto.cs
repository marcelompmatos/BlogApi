namespace BlogApi.Application.DTOs
{
    public class PostDto
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<CommentDto> Comments { get; set; }
    }
}
