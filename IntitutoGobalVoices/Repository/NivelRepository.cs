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
    public class NivelRepository:MasterRepository,INivel
    {


        public List<Nivel> ObtenerTodosNiveles()
        {
            var query = from n in context.Nivels select n;
            return query.ToList();
        }

        public void RegistrarNivel(Nivel nivel)
        {
            context.Nivels.Add(nivel);
            context.SaveChanges();
        }
        public void EliminarNivel(int id)
        {
            var nivel = context.Nivels.Find(id);
            if (nivel != null)
            {
                context.Entry(nivel).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Nivel ObtenerNivelById(int id)
        {
            var query = from p in context.Nivels where p.Id == id select p;
            return query.SingleOrDefault();
        }


        public void UpdateNivel(Nivel nivel)
        {
            if (nivel != null)
                context.Entry(nivel).State = EntityState.Modified;
            context.SaveChanges();
        }


        public List<Nivel> ObtenerNivelesPorCriterio(string criterio, int page = 1)
        {
            var query = from p in context.Nivels  select p;
            if (criterio != "" && criterio != null && criterio != string.Empty)
            {
                query = from p in query where (p.Nombre.Contains(criterio)) select p;
            }

            return query.ToList();
        }
    }
}
