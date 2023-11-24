using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// These model files create a framework inside the code which matches the framework of our database's schema, Think of each of these model files as the individual tables
// These models aren't limited to being reflections of our database tables but they work for what we're doing

namespace Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Required]
        [Column("pid")]
        public int Pid { get; set; } = default(int);

        [Required]
        [Column("sid")]
        public string Sid { get; set; } = null!;

        [Required]
        [Column("name")]
        public string Name { get; set; } = null!;

        [Required]
        [Column("description")]
        public string Description { get; set; } = null!;

        [Required]
        [Column("image")]
        public string Image { get; set; } = null!;

        [Required]
        [Column("category")]
        public int Category { get; set; } = default(int);

        [Required]
        [Column("price")]
        public float Price { get; set; } = default(float);

        [Required]
        [Column("stock")]
        public int Stock { get; set; } = default(int);

        [Required]
        [Column("sales")]
        public int Sales { get; set; } = default(int);

        [Required]
        [Column("rating")]
        public float Rating { get; set; } = default(float);

        [Required]
        [Column("clicked")]
        public int Clicked { get; set; } = default(int);

    }
}