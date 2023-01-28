using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rent_A_Car
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [Column("id")]
        public long Id { get; private set; }
        [Column("brand")]
        public string Brand { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("is_booked")]
        public bool IsBooked { get; set; }
    }
}
