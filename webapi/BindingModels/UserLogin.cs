using System.ComponentModel.DataAnnotations;

namespace webapi.BindingModels
{
	public class UserLogin
	{
        [Required]
        public string Username { get; set; }
		[Required]
		public string Password { get; set; }
    }
}
