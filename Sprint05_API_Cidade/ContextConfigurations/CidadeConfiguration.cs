using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Sprint05_API_Cidade
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("CIDADE");

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Estado).IsRequired();
        }
    }
}
