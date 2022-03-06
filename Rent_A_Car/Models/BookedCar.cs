using System;
using System.Collections.Generic;

#nullable disable

namespace Rent_A_Car
{
    public partial class BookedCar
    {
        public int BookCarId { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
