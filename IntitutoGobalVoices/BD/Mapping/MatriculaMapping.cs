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
    public class MatriculaMapping:EntityTypeConfiguration<Matricula>
    {
        public MatriculaMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.NroVoucher)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.FechaRegistro)
                .IsRequired();

            this.Property(c => c.NroMatricula)
                .IsRequired();

            this.Property(r => r.TipoMatricula)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.Estado)
                .IsRequired();

        //table
            this.ToTable("Matricula");

            //Relaciones
            this.HasRequired(r => r.Horario)
                .WithMany(h=>h.Matriculas)
                .HasForeignKey(r => r.HorarioFk)
                .WillCascadeOnDelete(false);

            this.HasRequired(r => r.Persona)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(r => r.PersonaFk)
                .WillCascadeOnDelete(false);



        }
    }
}
