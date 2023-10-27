using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class ApiUser : IdentityUser
    {

        [PersonalData, Required, StringLength(20)]
        public string FirstName { get; set; }

        [PersonalData, Required, StringLength(20)]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
