using BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MasterRepository
    {
        private IntitutoGVContext _context;

        protected MasterRepository()
        {
            if (_context == null)
                _context = new IntitutoGVContext();
        }

        protected IntitutoGVContext context
        {
            get { return _context; }
        }



    }
}
