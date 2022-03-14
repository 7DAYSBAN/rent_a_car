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
            BookedCars = new HashSet<BookedCar>();
        }

        [Key]
        public int CarId { get; set; }
        public int CarBrandId { get; set; }
        public int CarYear { get; set; }
        public string Description { get; set; }
        public decimal PricaPerDay { get; set; }

        public virtual CarBrand CarBrand { get; set; }
        public virtual ICollection<BookedCar> BookedCars { get; set; }
    }
}
