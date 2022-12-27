using Microsoft.IdentityModel.Tokens;
using OutGetDotNet.Data;
using OutGetDotNet.Models;
using OutGetDotNet.ModelsDto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
namespace OutGetDotNet.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public AuthService(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<ServiceResponse<User>> Register(UserDto request)
        {
            var response = new ServiceResponse<User>();
            //var dbUser = await _context.Users.Where(i => i.Name == request.Username);
            var dbUser = await _context.Users.FirstOrDefaultAsync(i => i.Name == request.Username);
            if (dbUser != null)
            {
                response.Success = false;
                response.Message = "User exist";
                return response;
            }

            User user = new User();

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Name = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user;
            response.Message = "Successfully register users";
            return response;
        }

        public async Task<ServiceResponse<string>> Login(UserDto request)
        {
            var response = new ServiceResponse<string>();
            var dbUser = await _context.Users.FirstOrDefaultAsync(i => i.Name == request.Username);
            if (dbUser == null)
            {
                response.Success = false;
                response.Message = "Update fail, User not found";
                return response;
            }
            if (!VerifyPasswordHash(request.Password, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong credentials";
                return response;

            }
            string token = CreateToken(dbUser);
            response.Success = true;
            response.Data = token;
            response.Message = "Successfull login";
            return response;
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }

        }
    }
}
