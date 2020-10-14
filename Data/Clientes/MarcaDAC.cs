using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Data
{
    public class MarcaDAC : DataAccessComponent, IRepository2<Marca>
    {
        public Marca ALoad(IDataReader entity)
        {
            Marca marca = new Marca();
            marca.Id = GetDataValue<int>(entity, "ID_Marca");
            marca.marca=GetDataValue<string>(entity, "Marca");
            throw new NotImplementedException();
        }

        public Marca Create(Marca entity)
        {
            const string SQL_STATEMENT = "insert into marca(marca,activo)values(@marca,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@marca", DbType.String, entity.marca);

                

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Marca set Activo=0 where id_Marca=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Marca> Read()
        {
            const string SQL_STATEMENT = "select * form Marca where  activo=1";

            List<Marca> result = new List<Marca>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Marca roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public Marca ReadBy(int id)
        {
            const string SQL_STATEMENT = "select * from Marca where  activo=1 and id_Marca=@Id";
            Marca roles = null;

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

        public Marca ReadBy(string id)
        {
            const string SQL_STATEMENT = "select * from Marca where  activo=1 and Marca=@Id";
            Marca roles = null;

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

        public void Update(Marca entity)
        {
            const string SQL_STATEMENT = "update Marca set Marca=@Marca where id_Marca=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@marca", DbType.String, entity.marca);

                db.AddInParameter(cmd, "@Id", DbType.String, entity.Id);
                db.ExecuteScalar(cmd);
            }

        }
    }
}
