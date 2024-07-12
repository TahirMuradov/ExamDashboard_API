using Exam_Dashboard.Api.DTOs.AuthDTOs;
using Exam_Dashboard.Api.FluentValidation.AuthDTOValidtor;
using Exam_Dashboard.Api.Models;
using Exam_Dashboard.Api.Security.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Security;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exam_Dashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }
        [HttpPost("[action]")]
        public async Task< IActionResult> Register(RegisterDTO registerDTO)
        {
            RegisterDTOValidator validations = new RegisterDTOValidator();
            var validationResult = validations.Validate(registerDTO);
            if (!validationResult.IsValid) return BadRequest(validationResult);
            User user = new()
            {
                FirstName = registerDTO.Firstname,
                LastName = registerDTO.Lastname,
                Email = registerDTO.Email,
                UserName = registerDTO.Firstname + registerDTO.Lastname + Guid.NewGuid().ToString().Substring(0, 5),


            };

            var result= await _userManager.CreateAsync(user,registerDTO.ConfirmPassword);
            return result.Succeeded?           
                          Ok(result):
            BadRequest(result);
            
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var validation = new LoginDTOValidator();
            var resultValidator = validation.Validate(loginDTO);
            if (!resultValidator.IsValid) return BadRequest(resultValidator);
         
      

            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            if (user == null)
                user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user is null)
                return NotFound("User Is NotFound");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, true);
            var roles = await _userManager.GetRolesAsync(user);

            if (result.Succeeded)
            {
                Token token = await _tokenService.CreateAccessTokenAsync(user, roles.ToList());
                var response = await _tokenService.UpdateRefreshTokenAsync(refreshToken: token.RefreshToken, user);
                if (response==null)
                {
                    return Unauthorized();
                  
                }
            return Ok(token) ;
            }
            return BadRequest();
        }

      
  

    }
}
