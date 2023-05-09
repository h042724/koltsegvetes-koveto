using System.Security.Claims;
using webapi.Models;

namespace webapi.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken(LoginUserDTO userDTO);

    }
}
