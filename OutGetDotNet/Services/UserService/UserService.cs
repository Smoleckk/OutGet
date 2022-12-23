using Microsoft.EntityFrameworkCore;
using OutGetDotNet.Data;
using OutGetDotNet.Models;

namespace OutGetDotNet.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<User>>> GetUsers()
        {
            var response = new ServiceResponse<List<User>>();

            response.Success = true;
            response.Message = "Successfully get users";
            response.Data = await _context.Users.ToListAsync();

            return response;
        }
        public async Task<ServiceResponse<User>> GetUser(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<User>>> AddUser(User user)
        {
            var response = new ServiceResponse<List<User>>();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Message = "Successfully get users";
            response.Data = await _context.Users.ToListAsync(); ;
            return response;
        }

        public async Task<ServiceResponse<List<User>>> UpdateUser(User user)
        {
            var response = new ServiceResponse<List<User>>();
            var dbUser = await _context.Users.FindAsync(user.Id);
            if (dbUser == null)
            {
                response.Success = false;
                response.Message = "Update fail, User not found";
            }
            dbUser.Name = user.Name;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Place = user.Place;

            await _context.SaveChangesAsync();

            response.Message = "Update successfully";
            response.Data = await _context.Users.ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<List<User>>> DeleteUser(int Id)
        {
            var response = new ServiceResponse<List<User>>();
            var dbUser = await _context.Users.FindAsync(Id);
            if (dbUser == null)
            {
                response.Success = false;
                response.Message = "Remove fail, User not found";
            }

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();

            response.Message = "Remove successfully";
            response.Data = await _context.Users.ToListAsync();

            return response;
        }
    }
}
