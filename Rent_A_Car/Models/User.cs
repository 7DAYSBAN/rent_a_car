using System;
using System.Collections.Generic;

#nullable disable

namespace Rent_A_Car
{
    public partial class User
    {
        public User()
        {
            BookedCars = new HashSet<BookedCar>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Egn { get; set; }
        public string UserPhone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BookedCar> BookedCars { get; set; }
    }
}
