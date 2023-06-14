using HRMS.Domain.Identity;
using HRMS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterVM registerVM, string roleName = "User")
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest("Model is Invalid");
                }

                ApplicationUser user = new ApplicationUser
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email,
                    PhoneNumber = registerVM.PhoneNumber

                };

                IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return BadRequest("User not created");
                }

                ApplicationRole applicationRole = await _roleManager.FindByNameAsync(roleName);

                if (applicationRole == null)
                {
                    applicationRole = new ApplicationRole { Name = roleName };
                    await _roleManager.CreateAsync(applicationRole);
                }

                await _userManager.AddToRoleAsync(user, applicationRole.Name);

                return Ok("User created Successfully");



            } catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInVM signInVM)
        {
            var user = await GetUserByUserNameOrEmail(signInVM.EmailOrUserName);

            if (user == null)
            {
                return BadRequest("user not Found");
            }
           

            var result =  await _signInManager.PasswordSignInAsync(user, signInVM.Password, signInVM.RememberMe, lockoutOnFailure: false);
            
            if(!result.Succeeded)
            {
               return Ok("Invalid Password");
            }

            var token = GenerateJwtToken(user);
            if (token == null)
            {
                return BadRequest("Token not generated");
            }

            return Ok(new { token });
        }

        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok("SignOut");
        }

        private async Task<ApplicationUser> GetUserByUserNameOrEmail(string emailOrUserName)
        {
            return emailOrUserName.Contains("@")
                ? await _userManager.FindByEmailAsync(emailOrUserName)
                : await _userManager.FindByNameAsync(emailOrUserName);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePasswordVM)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(changePasswordVM.Email);
            IdentityResult result = await _userManager.ChangePasswordAsync(user, changePasswordVM.CurrentPassword, changePasswordVM.NewPassword);
            
            return Ok("Success");
        }


        [HttpPost("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            return Ok(user);
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:TokenExpirationMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires : expires,
                signingCredentials : creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
