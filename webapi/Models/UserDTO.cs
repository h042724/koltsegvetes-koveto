﻿using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class UserDTO : LoginUserDTO  
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<string> Roles { get; set; } 

    }
}