using BlogApi.Application.DTOs;
using BlogApi.Application.Interfaces;
using BlogApi.Domain.Entities;
using BlogApi.Domain.Interfaces;

namespace BlogApi.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task AddAsync(PostDto postDto)
        {
            var post = new BlogPost
            {
                Title = postDto.Title,
                Content = postDto.Content,
                CreatedAt = postDto.CreatedAt
            };

            await _postRepository.AddAsync(post);
        }

        public async Task AddCommentAsync(CommentDto commentDto)
        {
            var comment = new Comment
            {
                Content = commentDto.Content,
                PostId = commentDto.PostId,
                CreatedAt = DateTime.UtcNow
            };

            await _postRepository.AddCommentAsync(commentDto.PostId, comment);
        }

        public async Task<List<PostDto>> GetAllAsync()
        {
            var blogPosts = await _postRepository.GetAllAsync();
            return blogPosts.Select(post => new PostDto
            {
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt
            }).ToList();
        }

        public async Task<PostDto?> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                return null;
            }
            return new PostDto
            {
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                Comments = post.Comments?.Select(c => new CommentDto
                {
                    PostId = post.Id,
                    Content = c.Content,
                }).ToList() ?? new List<CommentDto>() 
            };
        }
    }
}
