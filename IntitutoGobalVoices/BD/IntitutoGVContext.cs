using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Mapping;
using Entidades;

namespace BD
{
    public class IntitutoGVContext : DbContext
    {
        static IntitutoGVContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IntitutoGVContext>());
        }

        public IntitutoGVContext()
            : base("Name=IntitutoGVContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Nivel> Nivels { get; set; }
        public DbSet<Ciclo> Ciclos { get; set; }
        public DbSet<EstadoDocente> EstadoDocentes { get; set; }
        public DbSet<EstadoSalon> EstadoSalons { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Users> Userses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UbigeoMapping());
            modelBuilder.Configurations.Add(new TipoMapping());
            modelBuilder.Configurations.Add(new PersonaMapping());
            modelBuilder.Configurations.Add(new NivelMapping());
            modelBuilder.Configurations.Add(new CicloMapping());
            modelBuilder.Configurations.Add(new EstadoDocenteMapping());
            modelBuilder.Configurations.Add(new EstadoSalonMapping());
            modelBuilder.Configurations.Add(new HorarioMapping());
            modelBuilder.Configurations.Add(new SalonMapping());
            modelBuilder.Configurations.Add(new MatriculaMapping());
            modelBuilder.Configurations.Add(new AsistenciaMapping());
            modelBuilder.Configurations.Add(new NotaMapping());
            modelBuilder.Configurations.Add(new PaisMapping());
            modelBuilder.Configurations.Add(new UsersMapping());
        }
    }
}
