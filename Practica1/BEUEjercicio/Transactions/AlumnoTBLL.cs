using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    class AlumnoTBLL
    {
        //TBLL Query Bussiness Logic Layer
        //Capa de Lógica del Negocio - Transacciones - Escritura

        private Entities context;
        public Alumno alumno { get; set } //Alumno activo

        public AlumnoTBLL(bool wiithContext) {
            if (wiithContext)
            {
                context = new Entities();
            }
        }

        public void Get(int id)
        {
            alumno = context.Alumno.Find(id);
        }

        public void Create(Alumno a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Alumno.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Update()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Delete()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
