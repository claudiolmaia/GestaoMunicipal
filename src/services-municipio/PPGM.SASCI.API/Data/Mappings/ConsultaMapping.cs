using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PPGM.SASCI.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGM.SASCI.API.Data.Mappings
{
    public class ConsultaMapping : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasColumnName("cpf")
                .HasColumnType("varchar(11)");

            builder.Property(c => c.Medico)
                .IsRequired()
                .HasColumnName("medico")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Unidade)
                .IsRequired()
                .HasColumnName("unidade")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Consultorio)
                .IsRequired()
                .HasColumnName("consultorio")
                .HasColumnType("int");

            builder.Property(c => c.DataConsulta)
                .IsRequired()
                .HasColumnName("data_consulta")
                .HasColumnType("datetime");
        }
    }
}
