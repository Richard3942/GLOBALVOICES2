using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entidades;
using Interfaces;

namespace Repository
{
    public class CicloRepository:MasterRepository,ICiclo
    {


        public List<Ciclo> ObtenerCiclosPorNivelId(int nivelId)
        {
            var query = from c in context.Ciclos where c.NivelFk == nivelId select c;
            return query.ToList();

        }
    }
}
