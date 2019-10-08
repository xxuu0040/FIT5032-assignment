namespace FIT5032_Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Booking_id { get; set; }

        public int Room_id { get; set; }

        public int Hotel_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Checkin_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime Checkout_date { get; set; }

        [Required]
        [StringLength(50)]
        public string User_id { get; set; }

        public virtual Room Room { get; set; }

        public virtual Feedback Feedback { get; set; }
    }
}
