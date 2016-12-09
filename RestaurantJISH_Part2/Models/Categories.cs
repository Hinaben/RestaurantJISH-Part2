namespace RestaurantJISH_Part2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categories()
        {
            FoodItems = new HashSet<menus>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CategoryId { get; set; }

        public int RestaurantId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public virtual Restaurants Restaurant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<menus> FoodItems { get; set; }
    }
}
