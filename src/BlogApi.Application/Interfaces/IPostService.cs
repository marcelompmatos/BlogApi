using BlogApi.Application.DTOs;

namespace BlogApi.Application.Interfaces
{
    public interface IPostService
    {
        Task<List<PostDto>> GetAllAsync();
        Task<PostDto?> GetByIdAsync(int id);
        Task AddAsync(PostDto postDto);
        Task AddCommentAsync(CommentDto commentDto);
    }
}
