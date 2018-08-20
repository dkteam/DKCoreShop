using DKCoreShop.Infrastructure.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKCoreShop.Data.Entities
{
    [Table("AdvertisementPages")]
    public class AdvertisementPage : DomainEntity<string>
    {
        public string Name { get; set; }

        public virtual ICollection<AdvertisementPosition> AdvertistmentPositions { get; set; }
    }
}