using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using System.Data.Entity;





namespace Repository
{
    public class UbigeoRepository:MasterRepository,IUbigeo
    {


        public List<Pais> ObtenerTodosPaises()
        {
            var query = from p in context.Paises select p;
            return query.ToList();

        }


        public void RegistrarUbigeo(Ubigeo ubigeo)
        {
            context.Ubigeos.Add(ubigeo);
            context.SaveChanges();

        }


        public Ubigeo ObtenerUbigeoById(int id)
        {
            var query = from u in context.Ubigeos where u.Id == id select u;
            return query.SingleOrDefault();
        }
        public void UpdateUbigeo(Ubigeo ubigeo)
        {
            if (ubigeo != null)
            {
                context.Entry(ubigeo).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


    }
}
