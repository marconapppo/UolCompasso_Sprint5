using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Sprint05_API_Cidade
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.Property(ci => ci.Id).IsRequired();
            builder.Property(ci => ci.Nome).IsRequired();
            builder.Property(ci => ci.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DATA_NASC")
                .HasDefaultValueSql("getdate()");
            builder.Property(ci => ci.CidadeId)
                .IsRequired()
                .HasColumnName("CIDADE_ID");
            builder.Property(ci => ci.Cep).IsRequired();
            builder.Property(ci => ci.Logradouro).IsRequired();
            builder.Property(ci => ci.Bairro).IsRequired();

            //builder.HasKey(ci => ci.Id);
            //builder.HasKey("ID", "CIDADE_ID");

            builder.HasOne(ci => ci.Cidade)
                .WithMany(cl => cl.Clientes)
                .HasForeignKey(ci => ci.CidadeId)
                .HasPrincipalKey(ci => ci.Id);
        }
    }
}
