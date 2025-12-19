using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurs_db.Models
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        [Column("review_id")]
        public Guid ReviewId { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        [Column("rating")]
        [Range(1, 5)] // Вбудована валідація даних
        public int Rating { get; set; }

        [Column("comment")]
        public string Comment { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Навігаційні властивості для JOIN операцій
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}