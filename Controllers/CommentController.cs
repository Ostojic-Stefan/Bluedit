using AutoMapper.QueryableExtensions;
using AutoMapper;
using Bluedit.Data;
using Bluedit.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bluedit.Entities;
using System.Security.Claims;

namespace Bluedit.Controllers
{
    [Authorize]
    public class CommentController : BaseApiController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CommentController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("{identifier}/{slug}")]
        public async Task<ActionResult<CommentDto>> CreateComment(string identifier, string slug, CommentCreationDto commentCreationDto)
        {
            var post = await context.Posts
                .FirstOrDefaultAsync(post => post.Identifier == identifier && slug == post.Slug);

            var username = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = await context.Users.FirstOrDefaultAsync(user => user.Username == username);

            var comment = new Comment
            {
                Body = commentCreationDto.Body,
                User = user,
                Post = post
            };

            context.Comments.Add(comment);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
