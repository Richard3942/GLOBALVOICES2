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
    public class AsistenciaMapping:EntityTypeConfiguration<Asistencia>
    {
        public AsistenciaMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.Asistio)
                .IsRequired();

            this.Property(r => r.Fecha)
                .IsRequired();


            this.Property(r => r.MatriculaFk)
                .IsOptional();

            //table
            this.ToTable("Asistencia");

            //Relaciones
            this.HasOptional(r => r.Matricula)
                .WithMany(m=>m.Asistencias)
                .HasForeignKey(r => r.MatriculaFk)
                .WillCascadeOnDelete(false);
        }
    }
}
