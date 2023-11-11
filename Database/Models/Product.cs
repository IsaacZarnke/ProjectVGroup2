using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// These model files create a framework inside the code which matches the framework of our database's schema, Think of each of these model files as the individual tables
// These models aren't limited to being reflections of our database tables but they work for what we're doing

namespace Models
{
    [Table("category")]
    public class Product
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; } = default(int);

        [Required]
        [Column("name")]
        public string Name { get; set; } = null!;

        [Required]
        [Column("stats")]
        public string Stats { get; set; } = null!;
    }
}