using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BD;
using Interfaces;
using Entidades;
using System.Data.Entity;


namespace Repository
{
    public class MatriculaRepository:MasterRepository,IMatricula
    {

        public void RegistrarMatricula(Matricula matricula)
        {
            context.Matriculas.Add(matricula);
            context.SaveChanges();
        }

        public List<MatriculaDto> ObtenerMatriculas(string criterio, int page =1)
        {
            var query = from matricul in context.Matriculas
                        join person in context.Personas on matricul.PersonaFk equals person.Id
                        join horari in context.Horarios on matricul.HorarioFk equals horari.Id
                        join cicl in context.Ciclos on horari.CicloFk equals cicl.Id
                        join niv in context.Nivels on cicl.NivelFk equals niv.Id
                        join estadoSalo in context.EstadoSalons on horari.Id equals estadoSalo.HorarioFk
                        join salo in context.Salons on estadoSalo.SalonFk equals salo.Id
                        where person.TipoFk ==1
                        select new MatriculaDto()
                        {
                            Id = matricul.Id,
                            FechaMatricula = matricul.FechaRegistro,

                            Nombres = person.Nombres,
                            ApellidoPaterno = person.ApellidoPaterno,
                            ApellidoMaterno = person.ApellidoMaterno,
                            NroDocumento = person.NroDocumento,
                            Direccion = person.Direccion,
                            Celular = person.Celular,
                            Telefono = person.Telefono,
                            Email = person.Email,
                            FechaNacimiento = person.FechaNacimiento,
                            Genero = person.Genero,
                            EstadoElim = person.EstadoElim,

                            IdHorario = horari.Id,
                            Turno = horari.Turno,
                            Dias = horari.Dias,
                            HoraIni = horari.HoraIni,
                            HoraFin = horari.HoraFin,
                            FechaIni = horari.FechaIni,
                            FechaFin = horari.FechaFin,

                            IdNivel = niv.Id,
                            NombreN = niv.Nombre,

                            IdCiclo = cicl.Id,
                            NombreC = cicl.Nombre,

                            IdSalon = salo.Id,
                            NombreS = salo.Nombre,
                            Capacidad = salo.Capacidad

                        };
            if (!String.IsNullOrEmpty(criterio))
            {
                query = from m in query
                        where m.ApellidoPaterno + " " + m.ApellidoMaterno == criterio || m.NroDocumento == criterio
                        select m;
            }
            int posicion = (page - 1) * 20;
            return query.OrderBy(o => o.Id).Skip(posicion).Take(20).ToList();
           
        }

        public int ObtenerNroRegistros()
        {
            string criterio = "";
            var query = from matricul in context.Matriculas
                        join person in context.Personas on matricul.PersonaFk equals person.Id
                        join horari in context.Horarios on matricul.HorarioFk equals horari.Id
                        join cicl in context.Ciclos on horari.CicloFk equals cicl.Id
                        join niv in context.Nivels on cicl.NivelFk equals niv.Id
                        join estadoSalo in context.EstadoSalons on horari.Id equals estadoSalo.HorarioFk
                        join salo in context.Salons on estadoSalo.SalonFk equals salo.Id
                        where person.TipoFk == 1
                        select new MatriculaDto()
                        {
                            Id = matricul.Id,
                            FechaMatricula = matricul.FechaRegistro,

                            Nombres = person.Nombres,
                            ApellidoPaterno = person.ApellidoPaterno,
                            ApellidoMaterno = person.ApellidoMaterno,
                            NroDocumento = person.NroDocumento,
                            Direccion = person.Direccion,
                            Celular = person.Celular,
                            Telefono = person.Telefono,
                            Email = person.Email,
                            FechaNacimiento = person.FechaNacimiento,
                            Genero = person.Genero,
                            EstadoElim = person.EstadoElim,

                            IdHorario = horari.Id,
                            Turno = horari.Turno,
                            Dias = horari.Dias,
                            HoraIni = horari.HoraIni,
                            HoraFin = horari.HoraFin,
                            FechaIni = horari.FechaIni,
                            FechaFin = horari.FechaFin,

                            IdNivel = niv.Id,
                            NombreN = niv.Nombre,

                            IdCiclo = cicl.Id,
                            NombreC = cicl.Nombre,

                            IdSalon = salo.Id,
                            NombreS = salo.Nombre,
                            Capacidad = salo.Capacidad

                        };
            if (!String.IsNullOrEmpty(criterio))
            {
                query = from m in query
                        where m.ApellidoPaterno + " " + m.ApellidoMaterno == criterio || m.NroDocumento == criterio
                        select m;
            }

            return query.Count();
        }
        public MatriculaDto ObtenerMatriculaDtoById(int id)
        {
            var query = from matricul in context.Matriculas
                        join person in context.Personas on matricul.PersonaFk equals person.Id
                        join horari in context.Horarios on matricul.HorarioFk equals horari.Id
                        join cicl in context.Ciclos on horari.CicloFk equals cicl.Id
                        join niv in context.Nivels on cicl.NivelFk equals niv.Id
                        join estadoSalo in context.EstadoSalons on horari.Id equals estadoSalo.HorarioFk
                        join salo in context.Salons on estadoSalo.SalonFk equals salo.Id
                        where person.TipoFk == 1 && matricul.Id==id
                        select new MatriculaDto()
                        {
                            Id = matricul.Id,
                            Nombres = person.Nombres,
                            ApellidoPaterno = person.ApellidoPaterno,
                            ApellidoMaterno = person.ApellidoMaterno,
                            NroDocumento = person.NroDocumento,
                            Direccion = person.Direccion,
                            Celular = person.Celular,
                            Telefono = person.Telefono,
                            Email = person.Email,
                            FechaNacimiento = person.FechaNacimiento,
                            Genero = person.Genero,
                            EstadoElim = person.EstadoElim,

                            IdHorario = horari.Id,
                            Turno = horari.Turno,
                            Dias = horari.Dias,
                            HoraIni = horari.HoraIni,
                            HoraFin = horari.HoraFin,
                            FechaIni = horari.FechaIni,
                            FechaFin = horari.FechaFin,

                            IdNivel = niv.Id,
                            NombreN = niv.Nombre,

                            IdCiclo = cicl.Id,
                            NombreC = cicl.Nombre,

                            IdSalon = salo.Id,
                            NombreS = salo.Nombre,
                            Capacidad = salo.Capacidad

                        };


            return query.SingleOrDefault();
        }


        public Matricula ObtenerMatriculaById(int id)
        {
            var query =
                from m in
                    context.Matriculas.Include("Persona")
                        .Include("Persona.Ubigeo")
                        .Include("Persona.Tipo")
                        .Include("Horario")
                        .Include("Horario.Ciclo")
                        .Include("Horario.Ciclo.Nivel")
                where m.Id == id
                select m;
            return query.SingleOrDefault();
        }

        public Matricula ObtenerSoloMatriculaById(int id)
        {
            var query =
                from m in
                    context.Matriculas

                where m.Id == id
                select m;
            return query.FirstOrDefault();
        }

        public void UpdateMatricula(Matricula viewModel)
        {
            var matriculaToUpdate = ObtenerSoloMatriculaById(viewModel.Id);

            ActualizarDatosMatricula(matriculaToUpdate, viewModel);

            context.Entry(matriculaToUpdate).State = EntityState.Modified;
             
            context.SaveChanges();
        }

        private void ActualizarDatosMatricula(Matricula matriculaToUpdate, Matricula viewModel)
        {
            matriculaToUpdate.NroVoucher = viewModel.NroVoucher;
            matriculaToUpdate.FechaRegistro = DateTime.Now;
            matriculaToUpdate.NroMatricula = 1;
            matriculaToUpdate.TipoMatricula = viewModel.TipoMatricula;
            matriculaToUpdate.Estado = false;
            matriculaToUpdate.HorarioFk = viewModel.HorarioFk;
            matriculaToUpdate.PersonaFk = viewModel.PersonaFk;
        }

        public bool EstaMatriculado(int id)
        {
            var query = from m in context.Matriculas where m.PersonaFk == id select m;
            var quer = query.ToList();
            if (quer.Capacity!=0)
            {
                return true;
                
            }
            return false;
        }


        public bool EstaMatriculadoEnEstePeriodo_Ciclo(int idPersona)
        {
            var matricul = from m in context.Matriculas where m.PersonaFk == idPersona select m;
            var matriculas = matricul.ToList();

            if (matriculas.Count != 0)
            {
                foreach (var matricula in matriculas)
                {
                    var hor = from h in context.Horarios where h.Id == matricula.HorarioFk select h;
                    var horario = hor.SingleOrDefault();
                    if (horario != null)
                    {
                        if (DateTime.Now > horario.FechaIni && DateTime.Now < horario.FechaFin)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
