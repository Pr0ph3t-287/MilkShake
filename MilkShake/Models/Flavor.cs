using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilkShake.Models
{
    [Table("flavors", Schema = "public")]
    public class Flavor
    {
        [Key]
        [Column("flavor_id")]
        public int FlavorId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price", TypeName = "numeric(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}