using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// These model files create a framework inside the code which matches the framework of our database's schema, Think of each of these model files as the individual tables
// These models aren't limited to being reflections of our database tables but they work for what we're doing

namespace Models
{
    [Table("cart_product")]
    public class Cart_Product
    {
        [Required]
        [Column("email")]
        public int cart_id { get; set; } = default(int);

        [Required]
        [Column("password")]
        public int product_id { get; set; } = default(int);
    }
}