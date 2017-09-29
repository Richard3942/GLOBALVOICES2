using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface ICiclo
    {
        List<Ciclo> ObtenerCiclosPorNivelId(int nivelId);
        List<Ciclo> ObtenerCiclosPorCriterio(string criterio, int page = 1);
        void RegistrarCiclo(Ciclo ciclo);
        Ciclo ObtenerCicloById(int id);
        void UpdateCiclo(Ciclo ciclo);

        void EliminarCiclo(int id);
    }
}
