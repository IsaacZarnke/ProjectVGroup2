using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// These model files create a framework inside the code which matches the framework of our database's schema, Think of each of these model files as the individual tables
// These models aren't limited to being reflections of our database tables but they work for what we're doing

namespace Models
{
    [Table("user_purchases")]
    public class UserPurchases
    {
        [Key]
        [Required]
        [Column("userId")]
        public int UserId { get; set; } = default(int);

        [Required]
        [Column("categoryShopped")]
        public int CategoryShopped { get; set; } = default(int);

        [Key]
        [Required]
        [Column("frequencyShopped")]
        public int FrequencyShopped { get; set; } = default(int);

        [Required]
        [Column("avgProductPrice")]
        public float AvgProductPrice { get; set; } = default(float);
    }
}
