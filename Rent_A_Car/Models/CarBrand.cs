using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Rent_A_Car
{
    public partial class CarBrand
    {
        public CarBrand()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        public int CarBrandId { get; set; }
        public string CarBrandName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
