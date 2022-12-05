using AutoMapper;
using Bluedit.Data;
using Bluedit.Dtos;
using Bluedit.Entities;
using Bluedit.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Bluedit.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly TokenService tokenService;

        public AuthController(ApplicationDbContext context, IMapper mapper, TokenService tokenService)
        {
            this.context = context;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserRegisterDto userRegisterDto)
        {
            var emailExists = await context.Users.AnyAsync(user => user.Email == userRegisterDto.Email.ToLower());
            if (emailExists) return BadRequest("User with that email already exists");

            var usernameExists = await context.Users.AnyAsync(user => user.Username == userRegisterDto.Username.ToLower());
            if (usernameExists) return BadRequest("User with that username already exists");

            var user = new User
            {
                Email = userRegisterDto.Email,
                Username = userRegisterDto.Username,
                PasswordHash = PasswordManager.HashPassword(userRegisterDto.Password, out byte[] salt),
                Salt = salt,
            };

            context.Users.Add(user);

            if (await context.SaveChangesAsync() > 0)
            {
                return Ok(mapper.Map<UserDto>(user));
            }

            return StatusCode(500);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto userRegisterDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(context => context.Email == userRegisterDto.Email);

            if (user == null) return BadRequest("User does not exist");

            if (PasswordManager.VerifyPassword(userRegisterDto.Password, user.PasswordHash, user.Salt))
            {
                Response.Cookies.Append("X-Access-Token", tokenService.GenerateToken(user.Username), new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });

                var userDto = mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
            return Unauthorized();
        }
    }
}
