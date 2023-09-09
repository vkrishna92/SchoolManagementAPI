using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Common.Dtos;
using Core.Common.Interfaces;
using Core.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var userDb = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userDb != null)
                return BadRequest(new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Message = "Email address already exists." });
            var user = new IdentityUser
            {               
                PhoneNumber = registerDto.Phone,                
                Email = registerDto.Email,
                UserName = registerDto.Email
            };
            var res = await _userManager.CreateAsync(user, registerDto.Password);
            if (!res.Succeeded)
                return BadRequest(new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Message = "User registration failed." });
            var loginRes =  await _userManager.CheckPasswordAsync(user, registerDto.Password);
            var userDto = new UserDto
            {
                DisplayName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return BadRequest("Invalid username or password.");
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (result)
            {
                // Generate and return a JWT token or other authentication response
                // You can use a library like System.IdentityModel.Tokens.Jwt to create JWT tokens                
                var token = _tokenService.CreateToken(user);
                return Ok(new { token });
                //return Ok(new { message = "Login successful" });
            }            

            return BadRequest("Invalid username or password.");
        }


    }
}
