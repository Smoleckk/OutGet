using OutGetDotNet.Models;
using OutGetDotNet.ModelsDto;

namespace OutGetDotNet.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<User>> Register(UserDto request);
        Task<ServiceResponse<string>> Login(UserDto request);

    }
}
