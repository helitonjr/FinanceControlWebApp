using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HJR.FinanceControl.WebApp.Models;

namespace HJR.FinanceControl.WebApp.Data.Mappings
{
    public class ContaPagarMap : IEntityTypeConfiguration<ContaAPagar>
    {
        public void Configure(EntityTypeBuilder<ContaAPagar> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(c => c.Documento)
                .IsRequired();

            builder.Property(c => c.DescricaoDocumento)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Fornecedor)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.DataVencimento)
                .IsRequired();

            builder.Property(c => c.ValorTotal)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(c => c.Situacao)
                .HasColumnType("char(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.ToTable("ContasAPagar");
        }
    }
}