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
    public class PersonaMapping:EntityTypeConfiguration<Persona>
    {
        public PersonaMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.Nombres)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.ApellidoPaterno)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.ApellidoMaterno)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.NroDocumento)
                .HasMaxLength(25)
                .IsRequired();

            this.Property(r => r.Direccion)
                .HasMaxLength(100)
                .IsOptional();

            this.Property(r => r.Celular)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(r => r.Telefono)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(r => r.Email)
                .HasMaxLength(100)
                .IsOptional();

            this.Property(r => r.FechaNacimiento)
                .IsRequired();

            this.Property(r => r.Genero)
                .IsRequired();


            this.Property(r => r.EstadoElim)
                .IsRequired();


            //table
            this.ToTable("Persona");

            //Relaciones
            this.HasRequired(r => r.Tipo)
                .WithMany(r=>r.Personas)
                .HasForeignKey(r => r.TipoFk)
                .WillCascadeOnDelete(false);

            this.HasRequired(r => r.Ubigeo)
                .WithMany(r=>r.Personas)
                .HasForeignKey(r => r.UbigeoFk)
                .WillCascadeOnDelete(false);
        }
    }
}
