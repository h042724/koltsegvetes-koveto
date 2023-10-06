using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace webapi.LoginController
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginController> _logger;  

        public LoginController(SignInManager<IdentityUser> signInManager, ILogger<LoginController> logger, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        //[BindProperty]
        public InputModel Input { get; set; }
        //public IList<AuthenticationScheme> ExternalLogins { get; set; }
        //public string ReturnUrl { get; set; }
        //[TempData]
        //public string ErrorMessage { get; set; }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        /*public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }*/

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> OnPostAsync([FromBody] InputModel inputModel)
        {

            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(inputModel.Email, inputModel.Password, inputModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var identity = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, inputModel.Email)
                    }, "Custom");

                    HttpContext.User = new ClaimsPrincipal(identity);

                    _logger.LogInformation("User logged in.");
                    var user = await _userManager.FindByEmailAsync(inputModel.Email);
                    return Ok(user);
                }

                if (result.RequiresTwoFactor)
                {
                    _logger.LogWarning("User account RequiresTwoFactor.");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return StatusCode(401, "[\n \"Invalid Log In\" \n]");
                }
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
