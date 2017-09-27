using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BD.Mapping
{
    public class NivelMapping:EntityTypeConfiguration<Nivel>
    {
        public NivelMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.Nombre)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.Descripcion)
                .HasMaxLength(50)
                .IsOptional();
            //table
            this.ToTable("Nivel");

            //Relaciones

        }
    }
}
