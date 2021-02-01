using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations {
    public class ResultConsumeApiExternalConfiguration :IEntityTypeConfiguration<ResultConsumeApiExternal> {
        public void Configure(EntityTypeBuilder<ResultConsumeApiExternal> builder) {

            builder.HasKey(s => s.ID);
            builder.Property(r => r.Country);

            builder.Property(s => s.CountryCode)
                 .HasMaxLength(2)
                .IsRequired();

            builder.Property(s => s.Province);

            builder.Property(s => s.City);

            builder.Property(s => s.CityCode);

            builder.Property(s => s.Lat)
               .IsRequired();

            builder.Property(s => s.Lon)
               .IsRequired();

            builder.Property(s => s.Confirmed)
                .IsRequired();

            builder.Property(s => s.Deaths)
                .IsRequired();

            builder.Property(s => s.Recovered)
               .IsRequired();

            builder.Property(s => s.Active)
               .IsRequired();

            builder.Property(s => s.Date)
             .IsRequired();
        }
    }
}
