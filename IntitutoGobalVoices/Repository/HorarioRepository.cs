using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;

namespace Repository
{
    public class HorarioRepository:MasterRepository,IHorario
    {

        public List<HorarioDto> ObtenerHorariosPorCicloIdAndTurno(int cicloId, bool turno)
        {
            var query = from estadoSalo in context.EstadoSalons
                        join horari in context.Horarios on estadoSalo.HorarioFk equals horari.Id
                        join salo in context.Salons on estadoSalo.SalonFk equals salo.Id

                        where horari.CicloFk == cicloId && horari.Turno == turno //&& horari.FechaIni.Month == DateTime.Now.Month && horari.FechaFin.Month == DateTime.Now.Month
                        select new HorarioDto() { Id = horari.Id, Dias = horari.Dias, HoraIni = horari.HoraIni, HoraFin = horari.HoraFin, Salon = salo.Nombre };

            return query.ToList();

        }
        public Horario ObtenerHorarioById(int id)
        {
            var query = from h in context.Horarios where h.Id == id select h;
            return query.SingleOrDefault();
        }

    }
}
