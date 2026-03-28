using IdentityService.DTOs;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILogger<AuthController> _logger;
        private UserManager<ApplicationUser> _usermanager;
        private TokenService _tokenservice;

        public AuthController(ILogger<AuthController> logger, UserManager<ApplicationUser> userManager, TokenService tokenService)
        {
            _logger = logger;
            _usermanager = userManager;
            _tokenservice = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName
            };

            var result = await _usermanager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                _logger.LogInformation("Could not Register");
                return BadRequest(result.Errors);
            }

            _logger.LogInformation("Registered Successfully");
            // Assign role
            await _usermanager.AddToRoleAsync(user, dto.Role);

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _usermanager.FindByEmailAsync(dto.Email);

            if (user == null || !await _usermanager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized("Invalid credentials");

            var roles = await _usermanager.GetRolesAsync(user);

            var token = _tokenservice.CreateToken(user, roles);

            return Ok(new { token });
        }
    }
}

