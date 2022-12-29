using OutGetDotNet.Models;
using OutGetDotNet.ModelsDto;

namespace OutGetDotNet.Services.UserService
{
    public interface IUserService
    {
        string getMyName();
        string getMyRole();
        Task<ServiceResponse<List<User>>> GetUsers();
        Task<ServiceResponse<List<UserName>>> GetUsersName();
        Task<ServiceResponse<User>> GetUser(int Id);
        Task<ServiceResponse<List<User>>> AddUser(User user);
        Task<ServiceResponse<List<User>>> UpdateUser(User user);
        Task<ServiceResponse<List<User>>> DeleteUser(int Id);
    }
}
