using BlogApi.Domain.Entities;

namespace BlogApi.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<List<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(int id);
        Task AddAsync(BlogPost post);
        Task AddCommentAsync(int postId, Comment comment);
    }
}
