using Rent_A_Car.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Rent_A_Car
{
    public partial class BookedCar
    {
        [Key]
        public int BookCarId { get; set; }
        public string UserId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }

        public virtual Car Car { get; set; }

    }
}