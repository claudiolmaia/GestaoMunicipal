using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PPGM.STUR.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGM.STUR.API.Data.Mappings
{
    public class IptuMapping : IEntityTypeConfiguration<Iptu>
    {
        public void Configure(EntityTypeBuilder<Iptu> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasColumnName("cpf")
                .HasColumnType("varchar(11)");

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnName("logradouro")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnName("numero")
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnName("bairro")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnName("cidade")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.UF)
                .IsRequired()
                .HasColumnName("uf")
                .HasColumnType("char(2)");

            builder.Property(c => c.CEP)
                .IsRequired()
                .HasColumnName("cep")
                .HasColumnType("varchar(9)");

            builder.Property(c => c.Exercicio)
                .IsRequired()
                .HasColumnName("exercicio")
                .HasColumnType("char(4)");

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasColumnName("valor")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.IsPago)
                .IsRequired()
                .HasColumnName("is_pago")
                .HasColumnType("boolean");

            builder.Property(c => c.DataVencimento)
                .IsRequired()
                .HasColumnName("data_vencimento")
                .HasColumnType("datetime");
        }
    }
}
