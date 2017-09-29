using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface INivel
    {
        List<Nivel> ObtenerTodosNiveles();
        void RegistrarNivel(Nivel nivel);
        void EliminarNivel(int id);
        Nivel ObtenerNivelById(int id);
        void UpdateNivel(Nivel nivel);
        List<Nivel> ObtenerNivelesPorCriterio(string criterio, int page = 1);
    }
}
