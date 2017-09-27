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
    public class HorarioMapping:EntityTypeConfiguration<Horario>
    {
        public HorarioMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.Turno)
                .IsRequired();

            this.Property(r => r.HoraIni)
               .IsRequired();

            this.Property(r => r.HoraFin)
               .IsRequired();

            this.Property(r => r.Dias)
                .HasMaxLength(50)
               .IsRequired();

            this.Property(r => r.FechaIni)
               .IsRequired();

            this.Property(r => r.FechaFin)
               .IsRequired();

            //table
            this.ToTable("Horario");

            //Relaciones
            this.HasRequired(r => r.Ciclo)
                .WithMany(c=>c.Horarios)
                .HasForeignKey(r => r.CicloFk)
                .WillCascadeOnDelete(false);
        }
    }
}
