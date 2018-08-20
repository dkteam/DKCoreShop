using DKCoreShop.Infrastructure.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKCoreShop.Data.Entities
{
    [Table("AdvertisementPositions")]
    public class AdvertisementPosition : DomainEntity<string>
    {
        [StringLength(20)]
        public string PageId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [ForeignKey("PageId")]
        public virtual AdvertisementPage AdvertistmentPage { get; set; }

        public virtual ICollection<Advertisement> Advertistments { get; set; }
    }
}