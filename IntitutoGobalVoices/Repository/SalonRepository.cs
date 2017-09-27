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


    }
}
