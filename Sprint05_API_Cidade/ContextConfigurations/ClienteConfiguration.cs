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

            builder.Property<Guid>("ID").IsRequired();
            builder.Property<string>("NOME").IsRequired();
            builder.Property<DateTime>("DATA_NASC")
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            builder.Property<Guid>("CIDADE_ID").IsRequired();
            builder.Property<string>("CEP").IsRequired();
            builder.Property<string>("LOGRADOURO").IsRequired();
            builder.Property<string>("BAIRRO").IsRequired();

            builder.HasKey("ID", "CIDADE_ID");

            builder.HasOne(ci => ci.Cidade)
                .WithMany(cl => cl.Clientes)
                .HasForeignKey(ci => ci.CidadeId);
        }
    }
}
