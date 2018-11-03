using DKCoreShop.Data.Enums;
using DKCoreShop.Data.Interfaces;
using DKCoreShop.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKCoreShop.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public decimal OriginalPrice { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { set; get; }

        [StringLength(255)]
        public string Tags { set; get; }

        [StringLength(255)]
        public string Unit { get; set; }

        [StringLength(255)]
        public string SeoPageTitle { get; set; }

        [Column(TypeName = "varchar(255)")]
        [StringLength(255)]
        public string SeoAlias { get; set; }

        [StringLength(255)]
        public string SeoKeywords { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }
    }
}