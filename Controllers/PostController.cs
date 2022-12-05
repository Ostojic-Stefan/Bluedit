using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bluedit.Data;
using Bluedit.Dtos;
using Bluedit.Entities;
using Bluedit.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bluedit.Controllers
{
    public class PostController : BaseApiController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PostController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost(PostCreationDto postCreationDto)
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = await context.Users.FirstOrDefaultAsync(user => user.Username == username);

            if (user == null) return Unauthorized();

            var post = mapper.Map<Post>(postCreationDto);

            post.User = user;

            context.Posts.Add(post);

            await context.SaveChangesAsync();

            return Ok(mapper.Map<PostDto>(post));
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetPosts()
        {
            var posts = await context.Posts
                .AsNoTracking()
                .ProjectTo<PostsWithUserDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            if (posts.Count == 0) return NoContent();

            return Ok(posts);
        }

        [HttpGet("{identifier}/{slug}")]
        public async Task<ActionResult<PostDto>> GetPost(string identifier, string slug)
        {
            return Ok(await context.Posts
                .ProjectTo<PostsWithUserDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(post => post.Identifier == identifier && slug == post.Slug)
            );
        }

    }
}
