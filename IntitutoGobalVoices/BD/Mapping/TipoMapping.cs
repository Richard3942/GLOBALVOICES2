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
    public class TipoMapping:EntityTypeConfiguration<Tipo>
    {
        public TipoMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.Ocupacion)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.Descripcion)
                .HasMaxLength(50)
                .IsOptional();

            //table
            this.ToTable("Tipo");

            //Relaciones
            //this.HasRequired(r => r.Habitacion)
            //    .WithMany()
            //    .HasForeignKey(r => r.HabitacionId)
            //    .WillCascadeOnDelete(true);
        }
    }
}
