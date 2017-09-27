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
    public class EstadoSalonMapping:EntityTypeConfiguration<EstadoSalon>
    {
        public EstadoSalonMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.NroMatriculados)
                .IsRequired();

            this.Property(r => r.Turno)
               .IsRequired();

            this.Property(r => r.HoraIni)
                .IsRequired();
            this.Property(r => r.HoraFin)
                .IsRequired();
            this.Property(r => r.Estado)
                .IsRequired();

            //table
            this.ToTable("EstadoSalon");

            //Relaciones
            this.HasRequired(r => r.Salon)
                .WithMany(r=>r.EstadoSalones)
                .HasForeignKey(r => r.SalonFk)
                .WillCascadeOnDelete(false);

            this.HasRequired(r => r.Horario)
                .WithMany()
                .HasForeignKey(r => r.HorarioFk)
                .WillCascadeOnDelete(false);
        }
    }
}
