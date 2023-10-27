using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace WebApp1.Areas.Identity.Pages.Account
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IUserStore<ApiUser> _userStore;
        private readonly IUserEmailStore<ApiUser> _emailStore;
        private readonly ILogger<RegisterController> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterController(
            UserManager<ApiUser> userManager,
            IUserStore<ApiUser> userStore,
            SignInManager<ApiUser> signInManager,
            ILogger<RegisterController> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }
        public class SignUpModel
        {
            [Required]
            [PersonalData]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }
            [Required]
            [PersonalData]
            [Display(Name = "LastName")]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> OnPostAsync([FromBody] SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApiUser { FirstName = signUpModel.FirstName, 
                                         LastName = signUpModel.LastName,
                                         Email = signUpModel.Email };

                await _userStore.SetUserNameAsync(user, signUpModel.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, signUpModel.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, signUpModel.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Accepted();
                }
            }

            return Unauthorized();
        }

        private IUserEmailStore<ApiUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApiUser>)_userStore;
        }
    }
}
