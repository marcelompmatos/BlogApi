using BlogApi.Domain.Entities;

namespace BlogApi.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task AddAsync(Comment comment);
    }
}
