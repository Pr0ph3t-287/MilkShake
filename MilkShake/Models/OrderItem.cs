using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilkShake.Models
{
    [Table("order_items", Schema = "public")]
    public class OrderItem
    {
        [Key]
        [Column("order_item_id")]
        public int OrderItemId { get; set; }

        [Required]
        [Column("order_id")]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("price", TypeName = "numeric(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Column("created_at")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedAt { get; set; }
    }
}
