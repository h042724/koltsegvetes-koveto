using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.LoginController
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<LoginController> _logger;  

        public LoginController(SignInManager<ApiUser> signInManager, ILogger<LoginController> logger, UserManager<ApiUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }
        public class LoginModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> OnPostAsync([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var identity = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, loginModel.Email)
                    }, "Custom");

                    HttpContext.User = new ClaimsPrincipal(identity);

                    _logger.LogInformation("User logged in.");
                    var user = await _userManager.FindByEmailAsync(loginModel.Email);
                    return Ok(user);
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return StatusCode(401, "[\n \"Invalid Log In\" \n]");
                
            }
            return StatusCode(401, "[\n \"Email or Password cant be empty\" \n]");
        }

        [HttpPost]
        [Route("getUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            if (User.Identity.Name is not null)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                return Ok(user);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            return Ok();
        }
    }
}
