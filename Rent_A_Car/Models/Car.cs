using System;
using System.Collections.Generic;

#nullable disable

namespace Rent_A_Car
{
    public partial class Car
    {
        public Car()
        {
            BookedCars = new HashSet<BookedCar>();
        }

        public int CarId { get; set; }
        public int CarBrandId { get; set; }
        public int CarYear { get; set; }
        public string Description { get; set; }
        public decimal PricaPerDay { get; set; }

        public virtual CarBrand CarBrand { get; set; }
        public virtual ICollection<BookedCar> BookedCars { get; set; }
    }
}
