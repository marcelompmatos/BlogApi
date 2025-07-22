using BlogApi.Application.DTOs;
using BlogApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAll()
        {
            var posts = await _postService.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto?>> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostDto dto)
        {
            await _postService.AddAsync(dto);
            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpPost("comment")]
        public async Task<IActionResult> AddComment(CommentDto dto)
        {
            await _postService.AddCommentAsync(dto);
            return Ok();
        }
    }
}
