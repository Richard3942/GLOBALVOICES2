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
     
    }
}

