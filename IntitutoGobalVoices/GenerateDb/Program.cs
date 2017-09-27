using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entidades;

namespace GenerateDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var ubigeo = new Ubigeo()
            {
                Ciudad = "Cajamarca",
                Pais = "PERÚ"
            };
            //tipo de persona 


            var _context = new IntitutoGVContext();
            Console.WriteLine("Creando BD");
            _context.Ubigeos.Add(ubigeo);
            _context.SaveChanges();

            Console.WriteLine("Base de datos creada ");
            Console.ReadLine();
        }
    }
}
