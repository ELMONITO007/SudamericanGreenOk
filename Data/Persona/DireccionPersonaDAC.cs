using Entities.Personas;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class DireccionPersonaDAC : DataAccessComponent, IRepository2<DireccionPersona>
    {
        public DireccionPersona ALoad(IDataReader entity)
        {
            DireccionPersona direccionPersona = new DireccionPersona();
            direccionPersona.persona.Id = GetDataValue<int>(entity, "DNI");
            direccionPersona.direccion.Id = GetDataValue<int>(entity, "ID_Direccion");
            return direccionPersona;
        }

        public DireccionPersona Create(DireccionPersona entity)
        {

            const string SQL_STATEMENT = "insert into DireccionPersona(DNI,ID_Direccion)values(@name,@ID_Direccion)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.persona.Id);
                db.AddInParameter(cmd, "@ID_Direccion", DbType.Int32, entity.direccion.Id);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "delete DireccionPersona  where id=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
        public void Delete(int dni,int direccion)
        {
            const string SQL_STATEMENT = "delete DireccionPersona  where DNI=@Id and ID_direccion=@direccion";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, dni);
                db.AddInParameter(cmd, "@direccion", DbType.Int32, direccion);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<DireccionPersona> Read()
        {
            const string SQL_STATEMENT = "select * from DireccionPersona as dp join Persona as p on p.DNI=dp.DNI join Direccion as d on d.ID_Direccion=dp.ID_Direccion where d.activo=1 and p.Activo=1";

            List<DireccionPersona> result = new List<DireccionPersona>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        DireccionPersona roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public DireccionPersona ReadBy(int id)
        {
            throw new NotImplementedException();
        }
        public List< DireccionPersona> ReadByPersona(int id)
        {

            const string SQL_STATEMENT = "select * from DireccionPersona as dp join Persona as p on p.DNI=dp.DNI join Direccion as d on d.ID_Direccion=dp.ID_Direccion where d.activo=1 and p.Activo=1 and p.DNI=@Id";

            List<DireccionPersona> result = new List<DireccionPersona>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        DireccionPersona roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }
        public DireccionPersona ReadBy(int id,int Id_direccion)
        {
            const string SQL_STATEMENT = "select * from DireccionPersona as dp join Persona as p on p.DNI=dp.DNI join Direccion as d on d.ID_Direccion=dp.ID_Direccion where d.activo=1 and p.Activo=1 and p.DNI=@Id and d.Id_Direccion=@Id_direccion";

        DireccionPersona result = new DireccionPersona();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.AddInParameter(cmd, "@Id_direccion", DbType.Int32, Id_direccion);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        result = ALoad(dr);
                     
                    }
                }
            }
            return result;
        }

        public void Update(DireccionPersona entity)
        {
            throw new NotImplementedException();
        }

        public DireccionPersona ReadBy(string id)
        {
            throw new NotImplementedException();
        }
    }
}
