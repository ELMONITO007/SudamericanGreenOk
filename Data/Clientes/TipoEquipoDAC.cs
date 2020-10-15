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
    public class TipoEquipoDAC : DataAccessComponent, IRepository2<TipoEquipo>
    {
        public TipoEquipo ALoad(IDataReader entity)
        {
            TipoEquipo marca = new TipoEquipo();
            marca.Id = GetDataValue<int>(entity, "ID_TipoEquipo");
            marca.tipoEquipo = GetDataValue<string>(entity, "TipoEquipo");
            marca.descripcion = GetDataValue<string>(entity, "descripcion");
            return marca;
        }

        public TipoEquipo Create(TipoEquipo entity)
        {
            const string SQL_STATEMENT = "insert into TipoEquipo(TipoEquipo,descripcion,activo)values(@TipoEquipo,@descripcion,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@tipoEquipo", DbType.String, entity.tipoEquipo);

                db.AddInParameter(cmd, "@descripcion", DbType.String, entity.descripcion);

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update TipoEquipo set Activo=0 where id_TipoEquipo=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<TipoEquipo> Read()
        {
            const string SQL_STATEMENT = "select * from TipoEquipo where  activo=1";

            List<TipoEquipo> result = new List<TipoEquipo>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoEquipo roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public TipoEquipo ReadBy(int id)
        {
            const string SQL_STATEMENT = "select * from TipoEquipo where  activo=1 and id_TipoEquipo=@Id";
            TipoEquipo roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = ALoad(dr);
                    }
                }
            }
            return roles;
        }

        public TipoEquipo ReadBy(string id)
        {
            const string SQL_STATEMENT = "select * from TipoEquipo where  activo=1 and TipoEquipo=@Id";
            TipoEquipo roles = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        roles = ALoad(dr);
                    }
                }
            }
            return roles;
        }

        public void Update(TipoEquipo entity)
        {
            const string SQL_STATEMENT = "update TipoEquipo set TipoEquipo=@TipoEquipo,descripcion=@descripcion  where id_TipoEquipo=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, entity.Id);
                db.AddInParameter(cmd, "@TipoEquipo", DbType.String, entity.tipoEquipo);
                db.AddInParameter(cmd, "@descripcion", DbType.String, entity.descripcion);

                db.ExecuteScalar(cmd);
            }
        }
    }
}
