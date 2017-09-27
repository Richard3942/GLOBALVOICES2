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
    public class PaisMapping:EntityTypeConfiguration<Pais>
    {
        public PaisMapping()
        {
            this.HasKey(r => r.Codigo);

            //propiedades
            this.Property(r => r.Codigo);


            this.Property(r => r.Descripcion)
                .HasMaxLength(50)
                .IsRequired();

            //table
            this.ToTable("Pais");

            //Relaciones
        }
    }
}
