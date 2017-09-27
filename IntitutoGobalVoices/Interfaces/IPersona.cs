using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IPersona
    {
        List<Persona> ObtenerPersonas(string criterio, int page = 1);
        void UpdatePersona(Persona persona);
        Persona ObtenerPersonaProNroDoc(string nrodoc);
        Persona ObtenerPersonaById(int id);
        void RegistrarPersona(Persona persona);
        void EliminarPersona(int id);
        int ObtenerNroRegistros();

    }
}
