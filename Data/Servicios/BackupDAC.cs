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
    public class BackupDAC :DataAccessComponent,  IRepository<Backups>
    {

        private Backups Load(IDataReader dr)
        {
            Backups backups = new Backups();
            backups.Id = GetDataValue<int>(dr, "ID_Backup");
            backups.Fecha = GetDataValue<string>(dr, "fecha");
            backups.Nombre = GetDataValue<string>(dr, "Nombre");
          

            return backups;
        }

        public Backups Create(Backups entity)
        {
            const string SQL_STATEMENT = "insert into Backups(Nombre,Fecha)values(@Nombre,@Fecha) ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
               
                db.AddInParameter(cmd, "@Nombre", DbType.String, entity.Nombre);

                db.AddInParameter(cmd, "@Fecha", DbType.String, entity.Fecha);
        
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Backup set Activo=0 where id=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Backups> Read()
        {
            const string SQL_STATEMENT = "SELECT * FROM[GreenElectric].[dbo].[Backup] where Activo = 1";

            List<Backups> result = new List<Backups>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Backups backups = Load(dr);
                        result.Add(backups);
                    }

                }
            }
            return result;
        }

        public Backups ReadBy(int id)
        {
            const string SQL_STATEMENT = "select * from Backup where activo=1 and id=@Id";
            Backups backups = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        backups = Load(dr);
                    }
                }
            }
            return backups;
        }
        public Backups ReadBy(string id)
        {
            const string SQL_STATEMENT = "select * from Backup where activo=1 and id=@Id";
            Backups backups = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        backups = Load(dr);
                    }
                }
            }
            return backups;
        }
        public void Update(Backups entity)
        {
            throw new NotImplementedException();
        }
    }
}
