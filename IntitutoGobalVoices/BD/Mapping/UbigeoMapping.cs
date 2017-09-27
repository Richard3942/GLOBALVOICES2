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
    public class UbigeoMapping:EntityTypeConfiguration<Ubigeo>
    {
        public UbigeoMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.Pais)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.Ciudad)
                .HasMaxLength(50)
                .IsRequired();

            //table
            this.ToTable("Ubigeo");

            //Relaciones

        }
    }
}
