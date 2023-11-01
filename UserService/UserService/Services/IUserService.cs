using UserService.Data.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        public Task<bool> SignIn(User user);
        public Task<bool> LogOut(User user);
        public Task<User> Login(User user);
        public Task<User> GetUser(string userName);
    }
}
