using BlogApi.Domain.Entities;
using BlogApi.Domain.Interfaces;
using BlogApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BlogPost post)
        {
            await _context.BlogPost.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task AddCommentAsync(int postId, Comment comment)
        {
            var post = await _context.BlogPost.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == postId);
            if (post != null)
            {
                post.Comments.Add(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPost.Include(p => p.Comments).ToListAsync();
        }

        public async Task<BlogPost?> GetByIdAsync(int id)
        {
            return await _context.BlogPost.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
