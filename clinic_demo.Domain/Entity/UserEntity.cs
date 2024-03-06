using System.ComponentModel.DataAnnotations;
using clinic_demo.Domain.Enum;

namespace clinic_demo.Domain.Entity
{
    public class UserEntity
    {
        public int UserId{ get; set; }      
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }
    }
}
