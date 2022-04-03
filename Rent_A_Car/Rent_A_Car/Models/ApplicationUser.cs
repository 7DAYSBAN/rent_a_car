using Microsoft.AspNetCore.Identity;

namespace Rent_A_Car.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Password { get; set; }
        public string Egn { get; set; }
        public string UserPhone { get; set; }
        public string Emaill { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }
    }
    
    
}
