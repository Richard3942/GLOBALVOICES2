using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entidades;
using System.Data.Entity;
namespace Repository
{
    public class SalonRepository:MasterRepository,ISalon
    {
        public EstadoSalon ObtenerEstadoSalonByHorarioId(int horarioId)
        {
            var query = from s in context.EstadoSalons.Include("Salon") where s.HorarioFk == horarioId select s;
            return query.SingleOrDefault();
        }

        public void ActualizarEstadoSalon(EstadoSalon estadoSalon)
        {
            context.Entry(estadoSalon).State = EntityState.Modified;   
            context.SaveChanges();
        }

        public List<Salon> ObtenerSalonPorCriterio(string criterio, int page = 1)
        {
            var query = from p in context.Salons select p;
            if (criterio != "" && criterio != null && criterio != string.Empty)
            {
                query = from p in query where (p.Nombre.Contains(criterio)) select p;
            }
            return query.ToList();
        }

        public Salon ObtenerSalonById(int id)
        {
            var query = from p in context.Salons where p.Id == id select p;
            return query.SingleOrDefault();
        }


        public void RegistrarSalon(Salon salon)
        {
            context.Salons.Add(salon);
            context.SaveChanges();
        }

        public void UpdateSalon(Salon salon)
        {
            if (salon != null)
                context.Entry(salon).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void EliminarSalon(int id)
        {
            var salon = context.Salons.Find(id);
            if (salon != null)
            {
                context.Entry(salon).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
