﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Entidades
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Num_doc { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }

    }
}
