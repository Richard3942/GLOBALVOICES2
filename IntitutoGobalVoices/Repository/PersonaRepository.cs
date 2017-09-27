using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entidades;
using Interfaces;
using System.Data.Entity;

namespace Repository
{
    public class PersonaRepository:MasterRepository,IPersona
    {

        public List<Persona> ObtenerPersonas(string criterio, int page=1)
        {
            var query = from p in context.Personas where p.TipoFk == 1 select p;
            if (criterio != "" && criterio != null && criterio != string.Empty)
            {
                query = from p in query where ( p.ApellidoPaterno +" "+ p.ApellidoMaterno == criterio)  || p.NroDocumento==criterio  select p;
            }
            query = from pa in query where pa.EstadoElim != true select pa;

            int posicion = (page - 1)*20;
            return query.OrderBy(o=>o.Id).Skip(posicion).Take(20).ToList();
        }
        public int ObtenerNroRegistros()
        {
            string criterio = "";
            var query = from p in context.Personas where p.TipoFk == 1 select p;
            if (criterio != "" && criterio != null && criterio != string.Empty)
            {
                query = from p in query where (p.ApellidoPaterno + " " + p.ApellidoMaterno == criterio) || p.NroDocumento == criterio select p;
            }
            query = from pa in query where pa.EstadoElim != true select pa;
            return query.Count();
        }
        public void UpdatePersona(Persona persona)//CAMBIARLO
        {
            if (persona.Ubigeo != null )
                context.Entry(persona.Ubigeo).State = EntityState.Modified;   

            context.Entry(persona).State = EntityState.Modified;
            context.SaveChanges();

        }
        public Persona ObtenerPersonaProNroDoc(string nrodoc)
        {
            var query = from p in context.Personas where p.NroDocumento == nrodoc select p;
            return query.FirstOrDefault();
        }
        public Persona ObtenerPersonaById(int id)
        {
            var query = from p in context.Personas.Include("Ubigeo") where p.Id == id select p;
            return query.SingleOrDefault();
        }
        public void RegistrarPersona(Persona persona)
        {
            context.Personas.Add(persona);
            context.SaveChanges();
        }
        public void EliminarPersona(int id)
        {
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Entry(persona).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }



    }
}
