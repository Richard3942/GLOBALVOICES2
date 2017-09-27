using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BD.Mapping
{
    public class UsersMapping:EntityTypeConfiguration<Users>
    {

        public UsersMapping()
        {
            this.HasKey(r => r.Id);

            //propiedades
            this.Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r => r.Username)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.Password)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(r => r.FirstName)
                .HasMaxLength(50)
                .IsOptional();

            this.Property(r => r.LastName)
                .HasMaxLength(50)
                .IsOptional();


            this.Property(r => r.Email)
                .HasMaxLength(50)
                .IsOptional();
            //table
            this.ToTable("Users");

            //Relaciones
          
        }
    }
}
