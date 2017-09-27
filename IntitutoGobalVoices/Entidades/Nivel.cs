﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nivel
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }

        public List<Ciclo> Ciclos { get; set; }
    }
}
