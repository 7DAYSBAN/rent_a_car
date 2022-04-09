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
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public DateTime StartDay { get; set; }
        [Required]
        public DateTime EndDay { get; set; }
        public virtual Car Car { get; set; }
        public string CarModelDetails{ get; set; }

    }
}