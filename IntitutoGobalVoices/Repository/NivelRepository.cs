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
    public class NivelRepository:MasterRepository,INivel
    {


        public List<Nivel> ObtenerTodosNiveles()
        {
            var query = from n in context.Nivels select n;
            return query.ToList();
        }
    }
}
