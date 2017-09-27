using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IUbigeo
    {
        List<Pais> ObtenerTodosPaises();
        void RegistrarUbigeo(Ubigeo ubigeo);
        Ubigeo ObtenerUbigeoById(int id);
        void UpdateUbigeo(Ubigeo ubigeo);
    }
}
