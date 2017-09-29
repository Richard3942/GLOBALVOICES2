using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entidades;
using Interfaces;
using System.Data.Entity;

namespace Repository
{
    public class CicloRepository:MasterRepository,ICiclo
    {
        public List<Ciclo> ObtenerCiclosPorNivelId(int nivelId)
        {
            var query = from c in context.Ciclos where c.NivelFk == nivelId select c;
            return query.ToList();
        }

        public List<Ciclo> ObtenerCiclosPorCriterio(string criterio, int page = 1)
        {
            var query = from p in context.Ciclos.Include("Nivel") select p;
            if (criterio != "" && criterio != null && criterio != string.Empty)
            {
                query = from p in query where (p.Nombre.Contains(criterio)) select p;
            }

            return query.ToList();
        }
        public void RegistrarCiclo(Ciclo ciclo)
        {
            context.Ciclos.Add(ciclo);
            context.SaveChanges();
        }
        public Ciclo ObtenerCicloById(int id)
        {
            var query = from c in context.Ciclos where c.Id == id select c;
            return query.SingleOrDefault();
        }

        public void UpdateCiclo(Ciclo ciclo)
        {
            if (ciclo != null)
                context.Entry(ciclo).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void EliminarCiclo(int id)
        {
            var ciclo = context.Ciclos.Find(id);
            if (ciclo != null)
            {
                context.Entry(ciclo).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
