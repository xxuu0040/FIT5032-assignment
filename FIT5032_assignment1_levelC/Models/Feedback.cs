namespace FIT5032_Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Booking_id { get; set; }

        public int Hotel_id { get; set; }

        [Required]
        public string Hotel_name { get; set; }

        public int Score { get; set; }

        public string User_id { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Hotel Hotel { get; set; }

    }
}
