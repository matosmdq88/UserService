using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Data.Models;

namespace UserService.Services
{
    public class UserServices : IUserService
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }
        public Task<User> Login(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SignIn(User user)
        {
            try
            {
                User validUser = GetUser(user.Username).Result;
                if(validUser != null)
                {
                    throw new Exception("Username already used.");
                }
                _context.Users.Add(user);
                var rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // TODO need to see why i can manage exception better...
                return false;
            }
        }

        public Task<bool> LogOut(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string userName)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == userName);
                return user;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
