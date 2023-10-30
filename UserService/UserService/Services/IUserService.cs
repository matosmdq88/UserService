using UserService.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        public User SignIn(User user);
        public bool SignOut(User user);
        public User Loggin(User user);
    }
}
