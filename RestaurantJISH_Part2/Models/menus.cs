namespace RestaurantJISH_Part2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class menus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int foodId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public string foodName { get; set; }

        public double price { get; set; }

        [Required]
        public string briefDescription { get; set; }

        [Required]
        public string ingredients { get; set; }

        [Required]
        [StringLength(50)]
        public string foodImage { get; set; }

        public virtual Categories Category { get; set; }
    }
}
