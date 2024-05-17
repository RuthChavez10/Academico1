using Academico.Datos;
using Academico.Entidades;
using Academico.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Negocio
{
    public class EstudianteNegocio : IEstudianteRepositorio

    {
        AcademicoContextoBD db = new AcademicoContextoBD();

        public void Actualizar(Estudiante estudiante)
        {
            db.Entry(estudiante).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Agregar(Estudiante estudiante)
        {
            db.estudiante.Add(estudiante);
            db.SaveChanges();
        }

        public List<Estudiante> ListarEstudiantes()
        {
            var query = from x in db.estudiante
                        orderby x.Id
                        select x;
            return query.ToList();
            
        }

        public List<Estudiante> ListarEstudiantesxNombre(string nombre)
        {
            var query = from x in db.estudiante
                        where x.Nombres.Contains(nombre)
                        select x;
            return query.ToList();
        }

        public Estudiante Buscar(int id)
        {
            var Busqueda = db.estudiante.Find(id);
            return Busqueda;
        }
    }
}
