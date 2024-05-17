using Academico.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Datos
{
    public class AcademicoContextoBD : DbContext
    {

        public AcademicoContextoBD() : base("CadenaConexion1")
        
        { 
        
        }


        public virtual DbSet<Estudiante> estudiante { get; set; }

    }
}
