using AutoMapper;
using Bluedit.Data;
using Bluedit.Dtos;
using Bluedit.Entities;
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
            var ttt = User;
            var username = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = await context.Users.FirstOrDefaultAsync(user => user.Username == username);

            if (user == null) return Unauthorized();

            var post = new Post
            {
                Title = postCreationDto.Title,
                Body = postCreationDto.Body,
                User = user
            };

            context.Posts.Add(post);

            await context.SaveChangesAsync();

            return Ok(mapper.Map<PostDto>(post));
        }
    }
}
