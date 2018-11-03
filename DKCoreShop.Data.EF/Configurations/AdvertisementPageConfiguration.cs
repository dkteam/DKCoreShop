using DKCoreShop.Data.EF.Extensions;
using DKCoreShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DKCoreShop.Data.EF.Configurations
{
    public class AdvertisementPageConfiguration : DbEntityConfiguration<AdvertisementPage>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementPage> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
        }
    }
}