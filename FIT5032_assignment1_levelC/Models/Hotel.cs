namespace FIT5032_Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            Feedbacks = new HashSet<Feedback>();
            Rooms = new HashSet<Room>();
        }

        [Key]
        public int Hotel_id { get; set; }

        [Required]
        public string Hotel_name { get; set; }

        [Required]
        public string City { get; set; }

        public int Location_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public int Total_room_num { get; set; }

        public int Available_num { get; set; }

        [Column(TypeName = "date")]
        public DateTime Available_date { get; set; }

        public int Rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual Location Location1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
