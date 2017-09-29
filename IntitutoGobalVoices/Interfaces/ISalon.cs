using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface ISalon
    {
        //void AumentarNroMatriculados(int horarioId);
        EstadoSalon ObtenerEstadoSalonByHorarioId(int horarioId);
        void ActualizarEstadoSalon(EstadoSalon estadoSalon);
        List<Salon> ObtenerSalonPorCriterio(string criterio, int page = 1);
        Salon ObtenerSalonById(int id);
        void RegistrarSalon(Salon salon);
        void UpdateSalon(Salon salon);
        void EliminarSalon(int id);
        
        
        
     
    }
}

