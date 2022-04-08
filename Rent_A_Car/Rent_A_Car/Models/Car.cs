using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Rent_A_Car
{
    public class Car
    {
        public Car()
        {
           // FullCarInfo = Model + " " + Brand + "/ " + PricePerDay.ToString();
            BookedCars = new HashSet<BookedCar>();
        }

        [Key]
        
        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int CarYear { get; set; }
     //   public string FullCarInfo { get; set; } 
        public string Description { get; set; }
        [Required]
        [Range(0, 999.99)]
        public decimal PricePerDay { get; set; }

        public bool IsBooked = false;

        public virtual ICollection<BookedCar> BookedCars { get; set; }
    }
}
