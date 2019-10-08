namespace FIT5032_Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            Hotels = new HashSet<Hotel>();
        }

        [Key]
        public int Location_id { get; set; }

        [Required]
        public string Location_name { get; set; }

        [DisplayFormat(DataFormatString = "{0:###.########}")]
        [Column(TypeName = "numeric")]
        public decimal Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:###.########}")]
        [Column(TypeName = "numeric")]
        public decimal Longitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
