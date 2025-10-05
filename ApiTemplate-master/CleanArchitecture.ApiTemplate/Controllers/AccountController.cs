using BrainHope.Services.DTO.Authentication.SignIn;
using BrainHope.Services.DTO.Authentication.SingUp;
using CleanArchitecture.DataAccess.Models;
using CleanArchitecture.Services.DTOs.Responses;
using CleanArchitecture.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthService _authServices;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IAuthService authServices)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _authServices = authServices;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authServices.RegisterUserAsync(registerUser);

            if (!response.IsSuccess)
                return BadRequest(response.Message ?? "User could not be created");

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] SignInDTO signInDTO)
        {
            var user = await _userManager.FindByEmailAsync(signInDTO.Email);
            if (user == null)
                return Unauthorized(new Response { IsSuccess = false, Message = "User not found.", Status = "Error" });

            var passwordValid = await _userManager.CheckPasswordAsync(user, signInDTO.Password);
            if (!passwordValid)
                return Unauthorized(new Response { IsSuccess = false, Message = "Invalid credentials.", Status = "Error" });

            var tokenResponse = await _authServices.GetJwtTokenAsync(user);
            if (!tokenResponse.IsSuccess)
                return StatusCode(StatusCodes.Status500InternalServerError, tokenResponse);

            return Ok(tokenResponse);
        }
    }
}
