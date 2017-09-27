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
    public class NotaMapping:EntityTypeConfiguration<Nota>
    {
        public NotaMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.Puntaje)
                .IsRequired();

            this.Property(r => r.TipoNota)
                .HasMaxLength(50)
               .IsRequired();

            this.Property(r => r.MatriculaFk)
               .IsOptional();
            //table
            this.ToTable("Nota");

            //Relaciones
            this.HasOptional(r => r.Matricula)
                .WithMany(m=>m.Notas)
                .HasForeignKey(r => r.MatriculaFk)
                .WillCascadeOnDelete(false);
        }
    }
}
