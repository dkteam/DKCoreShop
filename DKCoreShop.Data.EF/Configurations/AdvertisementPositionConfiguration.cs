using DKCoreShop.Data.EF.Extensions;
using DKCoreShop.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DKCoreShop.Data.EF.Configurations
{
    public class AdvertisementPositionConfiguration : DbEntityConfiguration<AdvertisementPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementPosition> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
            // etc.
        }
    }
}