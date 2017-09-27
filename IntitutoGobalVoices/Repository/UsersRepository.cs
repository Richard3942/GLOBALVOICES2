using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;

namespace Repository
{
    public class UsersRepository:MasterRepository,IUsers
    {
        public Users ObtenerUserByUserName(string userName)
        {
            var query = from u in context.Userses where u.Username == userName select u;
            return query.FirstOrDefault();
        }

    }
}
