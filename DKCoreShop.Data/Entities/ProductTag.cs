using DKCoreShop.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKCoreShop.Data.Entities
{
    [Table("ProductTags")]
    public class ProductTag : DomainEntity<int>
    {
        public int ProductId { get; set; }

        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string TagId { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}