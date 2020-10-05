using Entities;
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
    public class TipoPersonaDAC : DataAccessComponent, IRepository<TipoPersona>
    {
        private TipoPersona LoadRoles(IDataReader dr)
        {
            TipoPersona tipoPersona = new TipoPersona();
            tipoPersona.Id = GetDataValue<int>(dr, "Id");
            tipoPersona.tipoPersona = GetDataValue<string>(dr, "ID_TipoPersona");
            return tipoPersona;
        }

        public TipoPersona Create(TipoPersona entity)
        {
            const string SQL_STATEMENT = "insert into TipoPersona(tipoPersona,activo)values(@tipoPersona,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@tipoPersona", DbType.String, entity.tipoPersona);

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update TipoPersona set Activo=0 where id=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
    

        public List<TipoPersona> Read()
        {
            const string SQL_STATEMENT = "select * from  TipoPersona where activo=1";

            List<TipoPersona> result = new List<TipoPersona>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoPersona roles = LoadRoles(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

    
        public TipoPersona ReadBy(int id)
        {
            const string SQL_STATEMENT = "select * from  TipoPersona where activo=1 and id_TipoPersona=@Id";
            TipoPersona roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = LoadRoles(dr);
                    }
                }
            }
            return roles;
        }

        public TipoPersona ReadBy(String id)
        {

            const string SQL_STATEMENT = "select   * from TipoPersona where TipoPersona=@Id and activo=1";
            TipoPersona roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = LoadRoles(dr);
                    }
                }
            }
            return roles;
        }


        public void Update(TipoPersona entity)
        {
            const string SQL_STATEMENT = "update TipoPersona set TipoPersona=@name where id_TipoPersona=@id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@name", DbType.String, entity.tipoPersona);
                db.AddInParameter(cmd, "@id", DbType.String, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
    
}
