using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Rent_A_Car.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Password { get; set; }
        public string UserName2 { get; set; }
        public string Egn { get; set; }
        public string UserPhone { get; set; }
        public string Emaill { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }      
}
