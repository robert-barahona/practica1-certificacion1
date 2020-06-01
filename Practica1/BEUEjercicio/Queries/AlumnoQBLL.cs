using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queries
{
    public static class AlumnoQBLL
    {
        //QBLL Query Bussiness Logic Layer
        //Capa de Lógica del Negocio - Consultas - Solo lecturas
        public static List<Alumno> GetAlumnos()
        {
            Entities db = new Entities(); //Instancia del contexto
            return db.Alumno.ToList(); //SQL -> SELECT * From dbo.Alumno
            //return db.Alumno.Where(x => x.sexo == "M").ToList();
            //Los métodos del EntityFramework se denomina Linq y la evaluación de condiciones Lambda
        }

        public static List<Alumno> GetAlumnos(string criterio)
        {
            //Ejemplo: criterio = 'vela'
            //Posibles resultados => Vela, Velasco, Velazquez..., ...vela..
            Entities db = new Entities();
            return db.Alumno.Where(x => x.apellidos.ToLower().Contains(criterio)).ToList(); 
        }

        public static Alumno GetAlumno(int id)
        {
            Entities db = new Entities();
            return db.Alumno.FirstOrDefault(x => x.idalumno == id);
        }

        public static Alumno GetAlumno(string cedula)
        {
            Entities db = new Entities();
            return db.Alumno.FirstOrDefault(x => x.cedula == cedula);
        }
    }
}
