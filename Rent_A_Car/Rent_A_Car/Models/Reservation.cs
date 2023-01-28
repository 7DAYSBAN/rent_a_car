using Rent_A_Car.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_A_Car
{
    [Table("Reservation")]
    public partial class Reservation
    {
        [Key]
        [Column("id")]
        public virtual long Id { get; private set; }

        [Column("start_day")]
        public virtual DateTime StartDay { get; set; }

        [Column("end_day")]
        public virtual DateTime EndDay { get; set; }

        [Column("state")]
        public virtual string State { get; set; }

        [Column("status")]
        public virtual string Status { get; set; }

        [Column("user")]       
        public virtual string ClientName { get; set; }

        [Column("car_id")]       
        public virtual long CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }
    }
}