using System.ComponentModel.DataAnnotations;

namespace UserService.Data.DTOs
{
    public class SignInUserDTO
    {
        [Required(ErrorMessage = "Username is Required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }
    }
}
