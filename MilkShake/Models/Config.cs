using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilkShake.Models
{
    [Table("milkshake_config", Schema = "public")]
    public class MilkshakeConfig
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("max_shakes_per_order")]
        [Required]
        [Display(Name = "Max Shakes Per Order")]
        public int MaxShakesPerOrder { get; set; }

        [Column("discount1_min_shakes")]
        [Required]
        [Display(Name = "Discount 1 Min Shakes")]
        public int Discount1MinShakes { get; set; }

        [Column("discount1_min_orders")]
        [Required]
        [Display(Name = "Discount 1 Min Orders")]
        public int Discount1MinOrders { get; set; }

        [Column("discount2_min_shakes")]
        [Required]
        [Display(Name = "Discount 2 Min Shakes")]
        public int Discount2MinShakes { get; set; }

        [Column("discount2_min_orders")]
        [Required]
        [Display(Name = "Discount 2 Min Orders")]
        public int Discount2MinOrders { get; set; }

        [Column("discount3_min_shakes")]
        [Required]
        [Display(Name = "Discount 3 Min Shakes")]
        public int Discount3MinShakes { get; set; }

        [Column("discount3_min_orders")]
        [Required]
        [Display(Name = "Discount 3 Min Orders")]
        public int Discount3MinOrders { get; set; }
    }
}