using BlogApi.Domain.Entities;
using BlogApi.Domain.Interfaces;
using BlogApi.Infrastructure.Context;

namespace BlogApi.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Comment comment)
        {
            await _context.Comment.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
    }
}
