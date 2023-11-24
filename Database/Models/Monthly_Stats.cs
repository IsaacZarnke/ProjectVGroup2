using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// These model files create a framework inside the code which matches the framework of our database's schema, Think of each of these model files as the individual tables
// These models aren't limited to being reflections of our database tables but they work for what we're doing

namespace Models
{
    [Table("monthly_stats")]
    public class MonthlyStats
    {
        [Key]
        [Required]
        [Column("month")]
        public DateTime Month { get; set; } = default(DateTime);

        [Required]
        [Column("clicks")]
        public int Clicks { get; set; } = default(int);

        [Required]
        [Column("conversions")]
        public int Conversions { get; set; } = default(int);
    }
}