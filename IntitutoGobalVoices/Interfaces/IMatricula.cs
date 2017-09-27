using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IMatricula
    {              
        List<MatriculaDto> ObtenerMatriculas(string criterio,int page);
        MatriculaDto ObtenerMatriculaDtoById(int id);
        Matricula ObtenerMatriculaById(int id);
        Matricula ObtenerSoloMatriculaById(int id);
        void UpdateMatricula(Matricula matricula);
        void RegistrarMatricula(Matricula matricula);
        bool EstaMatriculado(int id);
        bool EstaMatriculadoEnEstePeriodo_Ciclo(int idPersona);
        int ObtenerNroRegistros();
    }
}
